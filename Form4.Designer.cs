namespace Event_Project
{
    partial class Form4
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
            txtNewAnswer = new TextBox();
            btnBrowse = new Button();
            btnSave = new Button();
            lblPath = new Label();
            label1 = new Label();
            label2 = new Label();
            SuspendLayout();
            // 
            // txtNewAnswer
            // 
            txtNewAnswer.Location = new Point(187, 207);
            txtNewAnswer.Name = "txtNewAnswer";
            txtNewAnswer.Size = new Size(339, 27);
            txtNewAnswer.TabIndex = 0;
            // 
            // btnBrowse
            // 
            btnBrowse.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnBrowse.Location = new Point(205, 259);
            btnBrowse.Name = "btnBrowse";
            btnBrowse.Size = new Size(134, 56);
            btnBrowse.TabIndex = 1;
            btnBrowse.Text = "Browse Image:";
            btnBrowse.UseVisualStyleBackColor = true;
            btnBrowse.Click += btnBrowse_Click;
            // 
            // btnSave
            // 
            btnSave.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSave.Location = new Point(359, 259);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(130, 56);
            btnSave.TabIndex = 2;
            btnSave.Text = "Save to DB";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // lblPath
            // 
            lblPath.BorderStyle = BorderStyle.Fixed3D;
            lblPath.Location = new Point(187, 123);
            lblPath.Name = "lblPath";
            lblPath.Size = new Size(339, 35);
            lblPath.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(95, 124);
            label1.Name = "label1";
            label1.Size = new Size(90, 20);
            label1.TabIndex = 4;
            label1.Text = "Image Path:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(121, 207);
            label2.Name = "label2";
            label2.Size = new Size(64, 20);
            label2.TabIndex = 5;
            label2.Text = "Answer:";
            // 
            // Form4
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(lblPath);
            Controls.Add(btnSave);
            Controls.Add(btnBrowse);
            Controls.Add(txtNewAnswer);
            Name = "Form4";
            Text = "Add New Sign";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtNewAnswer;
        private Button btnBrowse;
        private Button btnSave;
        private Label lblPath;
        private Label label1;
        private Label label2;
    }
}
