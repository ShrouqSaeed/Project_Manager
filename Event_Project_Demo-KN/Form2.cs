using System;
using System.Windows.Forms;

namespace Event_Project_Demo_KN
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void btnQuiz_Click(object sender, EventArgs e)
        {
            // Multiforms: Opening Subprogram 1
            Form3 quizForm = new Form3();
            quizForm.ShowDialog();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Multiforms: Opening Subprogram 2
            Form4 addForm = new Form4();
            addForm.ShowDialog();
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            // Multiforms: Opening Subprogram 3
            Form5 settingsForm = new Form5();
            settingsForm.ShowDialog();
        }
    }
}
