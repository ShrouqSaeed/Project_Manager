using System;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;

namespace Event_Project
{
    public partial class Form3 : Form
    {
        DatabaseHelper db = new DatabaseHelper();

        Random randomizer = new Random();

        string correctAns = "";

        int currentScore = 0;

        List<string> defaultDistractors = new List<string>()
        {
            "Hello",
            "Thank you",
            "Yes",
            "No",
            "Please",
            "Sorry",
            "Good morning",
            "Goodbye",
            "Help",
            "Love",
            "Friend",
            "Family",
            "Happy",
            "Sad"
        };

        public Form3()
        {
            InitializeComponent();

            pbSign.SizeMode = PictureBoxSizeMode.Zoom;

            NextQuestion();
        }

        void NextQuestion()
        {
            ResetButtonStyles();

            SetButtonsEnabled(true);

            var data = db.GetRandom();

            if (data.Answer == null || data.GifPath == null)
            {
                lblScore.Text = "Please add signs first!";

                MessageBox.Show("No signs in database!");
                return;
            }

            correctAns = data.Answer;

            try
            {
                string fullPath;

                if (Path.IsPathRooted(data.GifPath))
                {
                    fullPath = data.GifPath;
                }
                else
                {
                    fullPath = Path.Combine(Application.StartupPath, data.GifPath);
                }

                pbSign.ImageLocation = fullPath;
            }
            catch
            {
                MessageBox.Show("Image not found!");
            }

            List<string> choices = db.GetChoices(correctAns, 3);

            List<string> filteredDefaults = defaultDistractors.Where(x => x != correctAns && !choices.Contains(x)).ToList();

            filteredDefaults = filteredDefaults.OrderBy(x => randomizer.Next()).ToList();

            while (choices.Count < 3 && filteredDefaults.Count > 0)
            {
                choices.Add(filteredDefaults[0]);

                filteredDefaults.RemoveAt(0);
            }

            choices.Add(correctAns);

            choices = choices.OrderBy(x => randomizer.Next()).ToList();

            if (choices.Count < 4)
            {
                MessageBox.Show("Not enough choices!");
                return;
            }

            btnOption1.Text = choices[0];
            btnOption2.Text = choices[1];
            btnOption3.Text = choices[2];
            btnOption4.Text = choices[3];

            lblScore.Text = "Score: " + currentScore;
        }

        void ResetButtonStyles()
        {
            Button[] buttons =
            {
                btnOption1,
                btnOption2,
                btnOption3,
                btnOption4
            };

            foreach (Button btn in buttons)
            {
                btn.BackColor = SystemColors.Control;
            }
        }

        void HighlightCorrectButton()
        {
            Button[] buttons =
            {
                btnOption1,
                btnOption2,
                btnOption3,
                btnOption4
            };

            foreach (Button btn in buttons)
            {
                if (btn.Text == correctAns)
                {
                    btn.BackColor = Color.LightGreen;
                }
            }
        }

        void SetButtonsEnabled(bool enabled)
        {
            btnOption1.Enabled = enabled;
            btnOption2.Enabled = enabled;
            btnOption3.Enabled = enabled;
            btnOption4.Enabled = enabled;
        }

        private void OptionButton_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;

            string selectedAnswer = clickedButton.Text;

            SetButtonsEnabled(false);

            if (selectedAnswer == correctAns)
            {
                clickedButton.BackColor = Color.LightGreen;

                currentScore += 10;

                lblScore.Text = "Score: " + currentScore;

                System.Media.SystemSounds.Asterisk.Play();

                MessageBox.Show("Correct! +10");

                if (currentScore >= 100)
                {
                    MessageBox.Show("You Win!");
                }
            }
            else
            {
                clickedButton.BackColor = Color.LightPink;

                HighlightCorrectButton();

                System.Media.SystemSounds.Hand.Play();

                MessageBox.Show("Wrong! Correct Answer: " + correctAns);
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            NextQuestion();
        }
    }
}