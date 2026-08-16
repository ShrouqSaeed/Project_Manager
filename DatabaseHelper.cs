using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Data.SqlClient;

namespace Event_Project
{
    public class DatabaseHelper
    {
        public static readonly string DbPath = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
            "EventProjectDB.mdf"
        );

        public static readonly string ConnectionString = $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={DbPath};Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True";

        private readonly string conStr = ConnectionString;

        public static void EnsureDatabaseCreated()
        {
            try
            {
                string dbDir = Path.GetDirectoryName(DbPath);
                if (!Directory.Exists(dbDir))
                {
                    Directory.CreateDirectory(dbDir);
                }

                if (!File.Exists(DbPath))
                {
                    // Connect to master database on LocalDB to create our database file
                    string masterConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True";
                    using (SqlConnection con = new SqlConnection(masterConnectionString))
                    {
                        con.Open();
                        // Generate a unique registered database name to avoid conflicts
                        string dbName = "EventProjectDB_" + Guid.NewGuid().ToString("N");
                        string createDbSql = $"CREATE DATABASE [{dbName}] ON PRIMARY (NAME = [{dbName}_Data], FILENAME = '{DbPath}')";
                        using (SqlCommand cmd = new SqlCommand(createDbSql, con))
                        {
                            cmd.ExecuteNonQuery();
                        }
                        
                        // Immediately detach so we can connect to the physical MDF file directly via AttachDbFilename
                        string detachSql = $"EXEC sp_detach_db [{dbName}]";
                        using (SqlCommand cmd = new SqlCommand(detachSql, con))
                        {
                            cmd.ExecuteNonQuery();
                        }
                    }
                }

                // Now connect using our connection string and create tables if they do not exist
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    con.Open();

                    // 1. Create Projects Table
                    string createProjectsTable = @"
                        IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Projects]') AND type in (N'U'))
                        BEGIN
                            CREATE TABLE [dbo].[Projects] (
                                [Id]      INT            IDENTITY (1, 1) NOT NULL,
                                [Name]    NVARCHAR (100) NOT NULL,
                                [ExePath] NVARCHAR (MAX) NOT NULL,
                                PRIMARY KEY CLUSTERED ([Id] ASC)
                            );
                        END";
                    using (SqlCommand cmd = new SqlCommand(createProjectsTable, con))
                    {
                        cmd.ExecuteNonQuery();
                    }

                    // 2. Create Signs Table
                    string createSignsTable = @"
                        IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Signs]') AND type in (N'U'))
                        BEGIN
                            CREATE TABLE [dbo].[Signs] (
                                [Id]      INT            IDENTITY (1, 1) NOT NULL,
                                [Answer]  NVARCHAR (100) NOT NULL,
                                [GifPath] NVARCHAR (MAX) NOT NULL,
                                PRIMARY KEY CLUSTERED ([Id] ASC)
                            );
                        END";
                    using (SqlCommand cmd = new SqlCommand(createSignsTable, con))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                // Silence or log to debug
                System.Diagnostics.Debug.WriteLine("Database initialization error: " + ex.Message);
            }
        }

        public string? GetGif(string answer)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SELECT GifPath FROM Signs WHERE Answer=@a", con);
                    cmd.Parameters.AddWithValue("@a", answer);

                    var result = cmd.ExecuteScalar();
                    return result?.ToString();
                }
            }
            catch
            {
                return null;
            }
        }

        public void Insert(string answer, string path)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(
                    "INSERT INTO Signs (Answer, GifPath) VALUES (@a, @p)", con);

                cmd.Parameters.AddWithValue("@a", answer);
                cmd.Parameters.AddWithValue("@p", path);

                cmd.ExecuteNonQuery();
            }
        }

        public (string? Answer, string? GifPath) GetRandom()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(
                        "SELECT TOP 1 Answer, GifPath FROM Signs ORDER BY NEWID()", con);

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                            return (dr["Answer"]?.ToString(), dr["GifPath"]?.ToString());
                    }
                }
            }
            catch
            {
                // Fallback to null
            }
            return (null, null);
        }

        public List<string> GetChoices(string correctWord, int count)
        {
            List<string> choices = new List<string>();
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(
                        "SELECT DISTINCT TOP (@count) Answer FROM Signs WHERE Answer <> @correct ORDER BY NEWID()", con);
                    cmd.Parameters.AddWithValue("@count", count);
                    cmd.Parameters.AddWithValue("@correct", correctWord);

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            var val = dr["Answer"]?.ToString();
                            if (val != null) choices.Add(val);
                        }
                    }
                }
            }
            catch
            {
                // Fallback to empty list
            }
            return choices;
        }

        public string? Delete(string answer)
        {
            try
            {
                string? gifPath = GetGif(answer);
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("DELETE FROM Signs WHERE Answer=@a", con);
                    cmd.Parameters.AddWithValue("@a", answer);
                    cmd.ExecuteNonQuery();
                }
                return gifPath;
            }
            catch
            {
                return null;
            }
        }

        public List<string> GetAllWords()
        {
            List<string> words = new List<string>();
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SELECT DISTINCT Answer FROM Signs ORDER BY Answer ASC", con);
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            var val = dr["Answer"]?.ToString();
                            if (val != null) words.Add(val);
                        }
                    }
                }
            }
            catch
            {
                // Fallback to empty list
            }
            return words;
        }
    }
}
