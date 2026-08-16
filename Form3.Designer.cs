namespace Event_Project
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
            lblScore = new Label();
            btnOption1 = new Button();
            btnOption2 = new Button();
            btnOption3 = new Button();
            btnOption4 = new Button();
            btnNext = new Button();
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
            // lblScore
            // 
            lblScore.BorderStyle = BorderStyle.Fixed3D;
            lblScore.Font = new Font("Segoe UI Black", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblScore.Location = new Point(240, 345);
            lblScore.Name = "lblScore";
            lblScore.Size = new Size(264, 35);
            lblScore.TabIndex = 3;
            lblScore.TextAlign = ContentAlignment.MiddleCenter;
            lblScore.Text = "Score: 0";
            // 
            // btnOption1
            // 
            btnOption1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnOption1.Location = new Point(240, 235);
            btnOption1.Name = "btnOption1";
            btnOption1.Size = new Size(125, 45);
            btnOption1.TabIndex = 4;
            btnOption1.Text = "Option 1";
            btnOption1.UseVisualStyleBackColor = true;
            btnOption1.Click += OptionButton_Click;
            // 
            // btnOption2
            // 
            btnOption2.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnOption2.Location = new Point(379, 235);
            btnOption2.Name = "btnOption2";
            btnOption2.Size = new Size(125, 45);
            btnOption2.TabIndex = 5;
            btnOption2.Text = "Option 2";
            btnOption2.UseVisualStyleBackColor = true;
            btnOption2.Click += OptionButton_Click;
            // 
            // btnOption3
            // 
            btnOption3.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnOption3.Location = new Point(240, 287);
            btnOption3.Name = "btnOption3";
            btnOption3.Size = new Size(125, 45);
            btnOption3.TabIndex = 6;
            btnOption3.Text = "Option 3";
            btnOption3.UseVisualStyleBackColor = true;
            btnOption3.Click += OptionButton_Click;
            // 
            // btnOption4
            // 
            btnOption4.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnOption4.Location = new Point(379, 287);
            btnOption4.Name = "btnOption4";
            btnOption4.Size = new Size(125, 45);
            btnOption4.TabIndex = 7;
            btnOption4.Text = "Option 4";
            btnOption4.UseVisualStyleBackColor = true;
            btnOption4.Click += OptionButton_Click;
            // 
            // btnNext
            // 
            btnNext.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnNext.Location = new Point(310, 395);
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(120, 35);
            btnNext.TabIndex = 8;
            btnNext.Text = "Skip / Next";
            btnNext.UseVisualStyleBackColor = true;
            btnNext.Click += btnNext_Click;
            // 
            // Form3
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(740, 450);
            Controls.Add(btnNext);
            Controls.Add(btnOption1);
            Controls.Add(btnOption2);
            Controls.Add(btnOption3);
            Controls.Add(btnOption4);
            Controls.Add(lblScore);
            Controls.Add(pbSign);
            Name = "Form3";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quiz Game - MCQ";
            ((System.ComponentModel.ISupportInitialize)pbSign).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pbSign;
        private Label lblScore;
        private Button btnOption1;
        private Button btnOption2;
        private Button btnOption3;
        private Button btnOption4;
        private Button btnNext;
    }
}
