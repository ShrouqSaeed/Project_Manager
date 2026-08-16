namespace Event_Project_Demo_KN
{
    partial class Form2
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
            label1 = new Label();
            btnQuiz = new Button();
            btnAdd = new Button();
            btnSettings = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Black", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(160, 9);
            label1.Name = "label1";
            label1.Size = new Size(445, 46);
            label1.TabIndex = 0;
            label1.Text = "Sign Language App Menu";
            // 
            // btnQuiz
            // 
            btnQuiz.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnQuiz.Location = new Point(292, 110);
            btnQuiz.Name = "btnQuiz";
            btnQuiz.Size = new Size(167, 51);
            btnQuiz.TabIndex = 1;
            btnQuiz.Text = "1. Play Quiz";
            btnQuiz.UseVisualStyleBackColor = true;
            btnQuiz.Click += btnQuiz_Click;
            // 
            // btnAdd
            // 
            btnAdd.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAdd.Location = new Point(292, 196);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(167, 59);
            btnAdd.TabIndex = 2;
            btnAdd.Text = "2. Add New Sign";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnSettings
            // 
            btnSettings.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSettings.Location = new Point(292, 295);
            btnSettings.Name = "btnSettings";
            btnSettings.Size = new Size(167, 63);
            btnSettings.TabIndex = 3;
            btnSettings.Text = "3. Translate";
            btnSettings.UseVisualStyleBackColor = true;
            btnSettings.Click += btnSettings_Click;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnSettings);
            Controls.Add(btnAdd);
            Controls.Add(btnQuiz);
            Controls.Add(label1);
            Name = "Form2";
            Text = "Sign Language";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button btnQuiz;
        private Button btnAdd;
        private Button btnSettings;
    }
}