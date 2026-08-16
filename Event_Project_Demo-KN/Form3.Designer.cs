namespace Event_Project_Demo_KN
{
    partial class Form3
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
            pbSign = new PictureBox();
            txtGuess = new TextBox();
            btnSubmit = new Button();
            lblScore = new Label();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)pbSign).BeginInit();
            SuspendLayout();
            // 
            // pbSign
            // 
            pbSign.Location = new Point(240, 41);
            pbSign.Name = "pbSign";
            pbSign.Size = new Size(264, 169);
            pbSign.SizeMode = PictureBoxSizeMode.StretchImage;
            pbSign.TabIndex = 0;
            pbSign.TabStop = false;
            // 
            // txtGuess
            // 
            txtGuess.Location = new Point(240, 256);
            txtGuess.Name = "txtGuess";
            txtGuess.Size = new Size(264, 27);
            txtGuess.TabIndex = 1;
            // 
            // btnSubmit
            // 
            btnSubmit.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSubmit.Location = new Point(310, 289);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.Size = new Size(104, 40);
            btnSubmit.TabIndex = 2;
            btnSubmit.Text = "Submit";
            btnSubmit.UseVisualStyleBackColor = true;
            btnSubmit.Click += btnSubmit_Click;
            // 
            // lblScore
            // 
            lblScore.BorderStyle = BorderStyle.Fixed3D;
            lblScore.Font = new Font("Segoe UI Black", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblScore.Location = new Point(122, 258);
            lblScore.Name = "lblScore";
            lblScore.Size = new Size(112, 25);
            lblScore.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(240, 233);
            label2.Name = "label2";
            label2.Size = new Size(104, 20);
            label2.TabIndex = 5;
            label2.Text = "Guess the GIF:";
            // 
            // Form3
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label2);
            Controls.Add(lblScore);
            Controls.Add(btnSubmit);
            Controls.Add(txtGuess);
            Controls.Add(pbSign);
            Name = "Form3";
            Text = "Quiz Game";
            ((System.ComponentModel.ISupportInitialize)pbSign).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pbSign;
        private TextBox txtGuess;
        private Button btnSubmit;
        private Label lblScore;
        private Label label2;
    }
}