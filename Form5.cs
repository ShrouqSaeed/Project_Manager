using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Event_Project
{
    public partial class Form5 : Form
    {
        private readonly DatabaseHelper db = new DatabaseHelper();

        public Form5()
        {
            InitializeComponent();

            LoadWordsFromDatabase();

            btnTranslate.Click += BtnTranslate_Click;

            lstWords.SelectedIndexChanged += LstWords_SelectedIndexChanged;

            btnDelete.Click += BtnDelete_Click;
        }

        private void LoadWordsFromDatabase()
        {
            lstWords.Items.Clear();

            List<string> words = db.GetAllWords();

            foreach (string word in words)
            {
                lstWords.Items.Add(word);
            }
        }

        private void LstWords_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstWords.SelectedItem != null)
            {
                txtWord.Text = lstWords.SelectedItem.ToString();

                TranslateWord(txtWord.Text);
            }
        }

        private void BtnTranslate_Click(object? sender, EventArgs e)
        {
            TranslateWord(txtWord.Text);
        }


        private void TranslateWord(string word)
        {
            string inputWord = word.Trim();

            if (inputWord == "")
            {
                MessageBox.Show("Enter word");
                return;
            }

            string path = db.GetGif(inputWord);

            if (path != null)
            {
                string fullPath = Path.Combine(Application.StartupPath, path);

                if (File.Exists(fullPath))
                {
                    pbGif.ImageLocation = fullPath;
                }
                else
                {
                    MessageBox.Show("GIF not found");
                }
            }
            else
            {
                pbGif.Image = null;

                MessageBox.Show("Word not found");
            }
        }

        private void BtnDelete_Click(object? sender, EventArgs e)
        {


            if (lstWords.SelectedItem == null)
            {
                MessageBox.Show("Select word first");
                return;
            }

            string selectedWord = lstWords.SelectedItem.ToString();

            pbGif.ImageLocation = null;
            pbGif.Image = null;

            GC.Collect();
            GC.WaitForPendingFinalizers();

            string path = db.Delete(selectedWord);

            if (path != null)
            {
                string fullPath = Path.Combine(Application.StartupPath, path);

                if (File.Exists(fullPath))
                {
                    File.Delete(fullPath);
                }
            }

            MessageBox.Show("Deleted");

            txtWord.Clear();

            LoadWordsFromDatabase();
        }
    }
}