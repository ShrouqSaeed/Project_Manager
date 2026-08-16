using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Event_Project_Demo_KN
{
    public partial class Form5 : Form
    {
        // OOP Concept: A class to represent a translation entry
        public class TranslationEntry
        {
            public string Word { get; set; }
            public string GifFile { get; set; }
        }

        // Arrays Concept: Small database array
        private TranslationEntry[] dictionaryDatabase = new TranslationEntry[5];

        public Form5()
        {
            InitializeComponent();
            SetupDatabase();
            
            // Wire up the button click event
            btnTranslate.Click += BtnTranslate_Click;
        }

        private void SetupDatabase()
        {
            // Adding dummy data to the array (Note: Indexes start at 0)
            dictionaryDatabase[0] = new TranslationEntry { Word = "hello", GifFile = "gifs\\hello.gif" };
            dictionaryDatabase[1] = new TranslationEntry { Word = "thank you", GifFile = "gifs\\thank_you.gif" };
            dictionaryDatabase[2] = new TranslationEntry { Word = "please", GifFile = "gifs\\please.gif" };
            dictionaryDatabase[3] = new TranslationEntry { Word = "yes", GifFile = "gifs\\yes.gif" };
            dictionaryDatabase[4] = new TranslationEntry { Word = "no", GifFile = "gifs\\no.gif" };

            // Loops concept: Pre-filling a ListBox so the user knows what words are available
            foreach (var entry in dictionaryDatabase)
            {
                if (lstWords != null) // Safety check in case you didn't add the ListBox
                {
                    lstWords.Items.Add(entry.Word);
                }
            }
        }

        private void BtnTranslate_Click(object sender, EventArgs e)
        {
            // Parsing / Data prep concept
            string inputWord = txtWord.Text.Trim().ToLower();
            
            // Condition concept (if string is empty)
            if (string.IsNullOrEmpty(inputWord))
            {
                MessageBox.Show("Please enter a word to translate.", "Warning");
                return;
            }

            bool found = false;
            string targetGifPath = "";

            // Loops and Conditions concepts
            for (int i = 0; i < dictionaryDatabase.Length; i++)
            {
                if (dictionaryDatabase[i].Word == inputWord)
                {
                    found = true;
                    // Ensure the gifs folder exists at runtime!
targetGifPath = Path.Combine(Application.StartupPath, dictionaryDatabase[i].GifFile);
                    break; // stop searching once found
                }
            }

            // Exception Handling concept
            try
            {
                if (found)
                {
                    // PictureBox concept: Automatically plays the GIF!
                    pbGif.ImageLocation = targetGifPath;
                }
                else
                {
                    // Clear the picture box and inform the user
                    pbGif.Image = null; 
                    MessageBox.Show("Word not found in the dictionary.", "Not Found");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while loading the GIF: " + ex.Message, "Error");
            }
        }
    }
}
