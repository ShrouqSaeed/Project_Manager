using System;
using System.Windows.Forms;
using Microsoft.Data.SqlClient; // Required for SQL Server

namespace Event_Project_Demo_KN
{
    public partial class Form4 : Form
    {
        // Replace this string with the actual path found in Server Explorer properties!
        private string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\kerol\OneDrive\Documents\EventProjectDB.mdf;Integrated Security=True;Connect Timeout=30";

        public Form4() { InitializeComponent(); }

        private bool TryGetGif(out string gifPath)
        {
            gifPath = "";
            using (OpenFileDialog ofd = new OpenFileDialog()) 
            {
                ofd.Filter = "GIF Images (*.gif)|*.gif";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    gifPath = ofd.FileName;
                    return true;
                }
            }
            return false;
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            if (TryGetGif(out string path))
            {
                lblPath.Text = path;
            }
        }

        // Database Integration Concept (ADO.NET)
        private void SaveSignToDatabase(string answer, string path)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "INSERT INTO Signs (Answer, GifPath) VALUES (@Answer, @GifPath)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Using parameters prevents SQL Injection!
                        command.Parameters.AddWithValue("@Answer", answer);
                        command.Parameters.AddWithValue("@GifPath", path);

                        command.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Saved to SQL Database successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database Error: " + ex.Message);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNewAnswer.Text) || lblPath.Text == "Path...")
            {
                MessageBox.Show("Fill all fields!");
                return;
            }

            SaveSignToDatabase(txtNewAnswer.Text, lblPath.Text);
            
            txtNewAnswer.Clear();
            lblPath.Text = "Path...";
        }
    }
}
