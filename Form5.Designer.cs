namespace Event_Project
{
    partial class Form5
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtWord = new TextBox();
            btnTranslate = new Button();
            pbGif = new PictureBox();
            lblTitle = new Label();
            lstWords = new ListBox();
            btnDelete = new Button();
            ((System.ComponentModel.ISupportInitialize)pbGif).BeginInit();
            SuspendLayout();
            // 
            // txtWord
            // 
            txtWord.Location = new Point(224, 242);
            txtWord.Name = "txtWord";
            txtWord.Size = new Size(242, 27);
            txtWord.TabIndex = 0;
            // 
            // btnTranslate
            // 
            btnTranslate.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnTranslate.Location = new Point(296, 285);
            btnTranslate.Name = "btnTranslate";
            btnTranslate.Size = new Size(105, 33);
            btnTranslate.TabIndex = 1;
            btnTranslate.Text = "Translate";
            btnTranslate.UseVisualStyleBackColor = true;
            btnTranslate.Click += BtnTranslate_Click;
            // 
            // pbGif
            // 
            pbGif.Location = new Point(224, 55);
            pbGif.Name = "pbGif";
            pbGif.Size = new Size(242, 120);
            pbGif.SizeMode = PictureBoxSizeMode.StretchImage;
            pbGif.TabIndex = 2;
            pbGif.TabStop = false;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.Location = new Point(224, 219);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(177, 20);
            lblTitle.TabIndex = 3;
            lblTitle.Text = "Type a word to translate:";
            // 
            // lstWords
            // 
            lstWords.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lstWords.FormattingEnabled = true;
            lstWords.Location = new Point(547, 15);
            lstWords.Name = "lstWords";
            lstWords.Size = new Size(186, 350);
            lstWords.TabIndex = 4;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.MistyRose;
            btnDelete.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDelete.ForeColor = Color.DarkRed;
            btnDelete.Location = new Point(547, 380);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(186, 45);
            btnDelete.TabIndex = 5;
            btnDelete.Text = "Delete Selected Word";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += BtnDelete_Click;
            // 
            // Form5
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnDelete);
            Controls.Add(lstWords);
            Controls.Add(lblTitle);
            Controls.Add(pbGif);
            Controls.Add(btnTranslate);
            Controls.Add(txtWord);
            Name = "Form5";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Translate Signs";
            ((System.ComponentModel.ISupportInitialize)pbGif).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtWord;
        private Button btnTranslate;
        private PictureBox pbGif;
        private Label lblTitle;
        private ListBox lstWords;
        private Button btnDelete;
    }
}
