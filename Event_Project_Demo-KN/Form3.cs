using System;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Event_Project_Demo_KN
{
    public partial class Form3 : Form
    {
        // OOP Concept: Class to store the Quiz item
        public class SignItem 
        { 
            public string Answer { get; set; } 
            public string ImagePath { get; set; } 
        }

        // We use a List instead of a fixed Array to handle dynamic file counts dynamically
        private List<SignItem> signsDatabase = new List<SignItem>();
        
        private Random randomizer = new Random(); // Random numbers concept
        private string correctAns = "";
        private int currentScore = 0;

        public Form3()
        {
            InitializeComponent();
            LoadRealGifs();
            NextQuestion();
            
            // Wire the button if it isn't wired automatically
            // btnSubmit.Click += btnSubmit_Click; 
        }

        private void LoadRealGifs()
        {
            try
            {
                // File path concepts: Find the "gifs" folder next to the .exe
                string gifFolder = Path.Combine(Application.StartupPath, "gifs");

                // Check if directory exists
                if (!Directory.Exists(gifFolder))
                {
                    // If it doesn't exist, create it so the user can easily find where to drop files
                    Directory.CreateDirectory(gifFolder);
                    MessageBox.Show("A 'gifs' folder has been created in your Debug folder. Place your .gif files there to play!");
                    return;
                }

                // File Reading Concept: Get all GIF files inside that folder
                string[] files = Directory.GetFiles(gifFolder, "*.gif");
                
                // Loops concept
                foreach (string file in files)
                {
                    // E.g., if file = "C:\...\gifs\hello.gif", Word = "hello"
                    string wordAnswer = Path.GetFileNameWithoutExtension(file);

                    // Add to our list
                    signsDatabase.Add(new SignItem 
                    { 
                        Answer = wordAnswer, 
                        ImagePath = file 
                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load real GIFs: " + ex.Message);
            }
        }

        private void NextQuestion()
        {
            if (signsDatabase.Count == 0)
            {
                lblScore.Text = "Please put GIFs in the 'gifs' folder!";
                return;
            }

            // Generate a random number based on how many gifs we found
            int index = randomizer.Next(0, signsDatabase.Count);
            
            var selectedItem = signsDatabase[index]; 
            if (selectedItem != null)
            {
                correctAns = selectedItem.Answer;
                try 
                {
                    pbSign.ImageLocation = selectedItem.ImagePath;
                }
                catch { MessageBox.Show("Image missing!"); }
            }
            txtGuess.Clear();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(correctAns)) return;

            // Control flow (if-else) and String manipulation
            if (txtGuess.Text.Trim().ToLower() == correctAns.ToLower())
            {
                MessageBox.Show("Correct!", "Result");
                
                // Pass by reference
                UpdateScore(ref currentScore, 10);

                // Load the next GIF upon a true answer
                NextQuestion();
            }
            else
            {
                MessageBox.Show("Wrong! The correct answer is: " + correctAns, "Result");
            }

            // Data conversion (int to string)
            lblScore.Text = "Score: " + currentScore.ToString();
        }

        // Method using 'ref' keyword
        private void UpdateScore(ref int score, int addAmount)
        {
            score += addAmount;
        }
    }
}
