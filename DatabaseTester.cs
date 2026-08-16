using System;
using Microsoft.Data.SqlClient;

namespace Event_Project
{
    public static class DatabaseTester
    {
        public static void RunTests()
        {
            Console.WriteLine("=== Starting Database Verification Test ===");
            try
            {
                // 1. Ensure DB & Tables are created
                Console.WriteLine("Step 1: Running DatabaseHelper.EnsureDatabaseCreated...");
                DatabaseHelper.EnsureDatabaseCreated();
                Console.WriteLine("Success: Database and Tables created/verified.");

                // 2. Test Connection
                Console.WriteLine($"Step 2: Connecting using string: {DatabaseHelper.ConnectionString}");
                using (SqlConnection con = new SqlConnection(DatabaseHelper.ConnectionString))
                {
                    con.Open();
                    Console.WriteLine("Success: Connected to the database.");

                    // 3. Test insert into Projects table
                    Console.WriteLine("Step 3: Testing Insert into [Projects]...");
                    string dummyProjName = "Test Project - " + DateTime.Now.ToString("yyyyMMddHHmmss");
                    string dummyProjPath = @"C:\Test\test.exe";
                    string insertProjSql = "INSERT INTO Projects (Name, ExePath) VALUES (@Name, @Path); SELECT SCOPE_IDENTITY();";
                    int newProjId;
                    using (SqlCommand cmd = new SqlCommand(insertProjSql, con))
                    {
                        cmd.Parameters.AddWithValue("@Name", dummyProjName);
                        cmd.Parameters.AddWithValue("@Path", dummyProjPath);
                        newProjId = Convert.ToInt32(cmd.ExecuteScalar());
                    }
                    Console.WriteLine($"Success: Inserted dummy project. Generated ID: {newProjId}");

                    // 4. Test read from Projects table
                    Console.WriteLine("Step 4: Testing Select from [Projects]...");
                    string selectProjSql = "SELECT Name, ExePath FROM Projects WHERE Id = @Id";
                    using (SqlCommand cmd = new SqlCommand(selectProjSql, con))
                    {
                        cmd.Parameters.AddWithValue("@Id", newProjId);
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr.Read())
                            {
                                string name = dr.GetString(0);
                                string path = dr.GetString(1);
                                if (name == dummyProjName && path == dummyProjPath)
                                {
                                    Console.WriteLine("Success: Selected and verified project matching inserted data.");
                                }
                                else
                                {
                                    throw new Exception("Mismatch in selected project data!");
                                }
                            }
                            else
                            {
                                throw new Exception("Could not retrieve inserted project!");
                            }
                        }
                    }

                    // 5. Test insert into Signs table
                    Console.WriteLine("Step 5: Testing Insert into [Signs]...");
                    string dummySignAns = "TestAnswer - " + DateTime.Now.ToString("yyyyMMddHHmmss");
                    string dummySignPath = "gifs/test.gif";
                    string insertSignSql = "INSERT INTO Signs (Answer, GifPath) VALUES (@Ans, @Path); SELECT SCOPE_IDENTITY();";
                    int newSignId;
                    using (SqlCommand cmd = new SqlCommand(insertSignSql, con))
                    {
                        cmd.Parameters.AddWithValue("@Ans", dummySignAns);
                        cmd.Parameters.AddWithValue("@Path", dummySignPath);
                        newSignId = Convert.ToInt32(cmd.ExecuteScalar());
                    }
                    Console.WriteLine($"Success: Inserted dummy sign. Generated ID: {newSignId}");

                    // 6. Test read from Signs table
                    Console.WriteLine("Step 6: Testing Select from [Signs]...");
                    string selectSignSql = "SELECT Answer, GifPath FROM Signs WHERE Id = @Id";
                    using (SqlCommand cmd = new SqlCommand(selectSignSql, con))
                    {
                        cmd.Parameters.AddWithValue("@Id", newSignId);
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr.Read())
                            {
                                string ans = dr.GetString(0);
                                string path = dr.GetString(1);
                                if (ans == dummySignAns && path == dummySignPath)
                                {
                                    Console.WriteLine("Success: Selected and verified sign matching inserted data.");
                                }
                                else
                                {
                                    throw new Exception("Mismatch in selected sign data!");
                                }
                            }
                            else
                            {
                                throw new Exception("Could not retrieve inserted sign!");
                            }
                        }
                    }

                    // 7. Cleanup
                    Console.WriteLine("Step 7: Cleaning up test data...");
                    string deleteProjSql = "DELETE FROM Projects WHERE Id = @Id";
                    using (SqlCommand cmd = new SqlCommand(deleteProjSql, con))
                    {
                        cmd.Parameters.AddWithValue("@Id", newProjId);
                        cmd.ExecuteNonQuery();
                    }
                    string deleteSignSql = "DELETE FROM Signs WHERE Id = @Id";
                    using (SqlCommand cmd = new SqlCommand(deleteSignSql, con))
                    {
                        cmd.Parameters.AddWithValue("@Id", newSignId);
                        cmd.ExecuteNonQuery();
                    }
                    Console.WriteLine("Success: Test data deleted successfully.");
                }

                Console.WriteLine("=== All tests passed successfully! ===");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"!!! Test Failed: {ex.Message}");
                Console.WriteLine(ex.StackTrace);
                throw;
            }
        }
    }
}
