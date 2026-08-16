using System;
using System.Windows.Forms;
using Microsoft.Data.SqlClient; 

namespace Event_Project
{
    public partial class Form4 : Form
    {
        
        private string connectionString = DatabaseHelper.ConnectionString;

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
            if (string.IsNullOrEmpty(txtNewAnswer.Text) || lblPath.Text == "Path..." || string.IsNullOrEmpty(lblPath.Text))
            {
                MessageBox.Show("Fill all fields!");
                return;
            }

            string sourcePath = lblPath.Text;
            string destDir = Path.Combine(Application.StartupPath, "gifs");
            if (!Directory.Exists(destDir))
                Directory.CreateDirectory(destDir);

            string fileName = Path.GetFileName(sourcePath);
            string destFile = Path.Combine(destDir, fileName);

            try
            {
                File.Copy(sourcePath, destFile, true);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error copying file: " + ex.Message);
                return;
            }

            string relativePath = Path.Combine("gifs", fileName);
            SaveSignToDatabase(txtNewAnswer.Text, relativePath);
            
            txtNewAnswer.Clear();
            lblPath.Text = "Path...";
        }
    }
}
