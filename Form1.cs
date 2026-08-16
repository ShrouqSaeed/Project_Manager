using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace Event_Project
{
    public partial class Form1 : Form
    {
        public class HubProject
        {
            public int Id { get; set; } // Added DB ID
            public string Name { get; set; }
            public string ExePath { get; set; }
        }

        private List<HubProject> projectsList = new List<HubProject>();
        private string connectionString = DatabaseHelper.ConnectionString;

        public Form1()
        {
            InitializeComponent();
            //this.Load += Form1_Load;
            
            //btnAdd.Click += BtnAdd_Click;
            //btnRun.Click += BtnRun_Click;
            //btnDelete.Click += BtnDelete_Click;
            //lstProjects.SelectedIndexChanged += LstProjects_SelectedIndexChanged;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadProjectsFromDB();
        }

        private void LoadProjectsFromDB()
        {
            projectsList.Clear();
            lstProjects.Items.Clear();

            // Always add internal form first
            var internalProject = new HubProject { Id = 0, Name = "Sign Language App (Internal)", ExePath = "INTERNAL_FORM2" };
            projectsList.Add(internalProject);
            lstProjects.Items.Add(internalProject.Name);

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT Id, Name, ExePath FROM Projects";
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var proj = new HubProject
                            {
                                Id = reader.GetInt32(0),
                                Name = reader.GetString(1),
                                ExePath = reader.GetString(2)
                            };
                            projectsList.Add(proj);
                            lstProjects.Items.Add(proj.Name);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading from database: " + ex.Message);
            }
        }

        

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if (TryGetValidExePath(out string selectedPath))
            {
                string defaultName = Path.GetFileNameWithoutExtension(selectedPath);

                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        string query = "INSERT INTO Projects (Name, ExePath) VALUES (@Name, @Path)";
                        using (SqlCommand cmd = new SqlCommand(query, connection))
                        {
                            cmd.Parameters.AddWithValue("@Name", defaultName);
                            cmd.Parameters.AddWithValue("@Path", selectedPath);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    MessageBox.Show("External Project successfully added to SQL Database!");
                    LoadProjectsFromDB(); // Refresh UI
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Database Error: " + ex.Message);
                }
            }
        }

        private void BtnRun_Click(object sender, EventArgs e)
        {
            if (lstProjects.SelectedIndex == -1) return;

            var selectedProj = projectsList[lstProjects.SelectedIndex];
            try
            {
                if (selectedProj.ExePath == "INTERNAL_FORM2")
                {
                    new Form2().ShowDialog();
                }
                else
                {
                    Process.Start(new ProcessStartInfo { FileName = selectedProj.ExePath, UseShellExecute = true });
                }
            }
            catch (Exception ex) { MessageBox.Show("Run Error: " + ex.Message); }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (lstProjects.SelectedIndex == -1) return;

            var proj = projectsList[lstProjects.SelectedIndex];
            if (proj.ExePath == "INTERNAL_FORM2")
            {
                MessageBox.Show("Cannot delete the internal application!");
                return;
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "DELETE FROM Projects WHERE Id = @Id";
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@Id", proj.Id);
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Deleted successfully!");
                LoadProjectsFromDB(); // Refresh
                lblName.Text = "Project Name:";
                txtExePath.Clear();
            }
            catch (Exception ex) { MessageBox.Show("Database Delete Error: " + ex.Message); }
        }
        private bool TryGetValidExePath(out string path)
        {
            path = string.Empty;
            using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "Executable Files (*.exe)|*.exe" })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    path = ofd.FileName;
                    return true;
                }
            }
            return false;
        }
        private void LstProjects_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstProjects.SelectedIndex != -1)
            {
                var selectedProj = projectsList[lstProjects.SelectedIndex];
                lblName.Text = selectedProj.Name;
                txtExePath.Text = selectedProj.ExePath == "INTERNAL_FORM2" ? "Built-in Application" : selectedProj.ExePath;
            }
        }
    }
}
          