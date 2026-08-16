namespace Event_Project_Demo_KN
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lstProjects = new ListBox();
            txtExePath = new TextBox();
            pbThumbnail = new PictureBox();
            gbDetails = new GroupBox();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            lblName = new Label();
            btnRun = new Button();
            btnDelete = new Button();
            btnAdd = new Button();
            ((System.ComponentModel.ISupportInitialize)pbThumbnail).BeginInit();
            gbDetails.SuspendLayout();
            SuspendLayout();
            // 
            // lstProjects
            // 
            lstProjects.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lstProjects.FormattingEnabled = true;
            lstProjects.Location = new Point(546, 31);
            lstProjects.Name = "lstProjects";
            lstProjects.Size = new Size(242, 395);
            lstProjects.TabIndex = 0;
            lstProjects.SelectedIndexChanged += LstProjects_SelectedIndexChanged;
            // 
            // txtExePath
            // 
            txtExePath.Location = new Point(29, 256);
            txtExePath.Multiline = true;
            txtExePath.Name = "txtExePath";
            txtExePath.ReadOnly = true;
            txtExePath.Size = new Size(440, 55);
            txtExePath.TabIndex = 1;
            // 
            // pbThumbnail
            // 
            pbThumbnail.Location = new Point(153, 26);
            pbThumbnail.Name = "pbThumbnail";
            pbThumbnail.Size = new Size(199, 108);
            pbThumbnail.SizeMode = PictureBoxSizeMode.StretchImage;
            pbThumbnail.TabIndex = 2;
            pbThumbnail.TabStop = false;
            // 
            // gbDetails
            // 
            gbDetails.Controls.Add(label4);
            gbDetails.Controls.Add(label3);
            gbDetails.Controls.Add(label2);
            gbDetails.Controls.Add(lblName);
            gbDetails.Controls.Add(pbThumbnail);
            gbDetails.Controls.Add(txtExePath);
            gbDetails.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            gbDetails.Location = new Point(3, 12);
            gbDetails.Name = "gbDetails";
            gbDetails.Size = new Size(512, 344);
            gbDetails.TabIndex = 3;
            gbDetails.TabStop = false;
            gbDetails.Text = "Project Card";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(29, 233);
            label4.Name = "label4";
            label4.Size = new Size(96, 20);
            label4.TabIndex = 6;
            label4.Text = "Project Path:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(29, 163);
            label3.Name = "label3";
            label3.Size = new Size(106, 20);
            label3.TabIndex = 5;
            label3.Text = "Project Name:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(91, 55);
            label2.Name = "label2";
            label2.Size = new Size(42, 20);
            label2.TabIndex = 4;
            label2.Text = "Icon:";
            // 
            // lblName
            // 
            lblName.BorderStyle = BorderStyle.Fixed3D;
            lblName.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblName.Location = new Point(29, 183);
            lblName.Name = "lblName";
            lblName.Size = new Size(440, 37);
            lblName.TabIndex = 3;
            lblName.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnRun
            // 
            btnRun.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnRun.Location = new Point(189, 377);
            btnRun.Name = "btnRun";
            btnRun.Size = new Size(166, 53);
            btnRun.TabIndex = 4;
            btnRun.Text = "Run Selected Project";
            btnRun.UseVisualStyleBackColor = true;
            btnRun.Click += BtnRun_Click;
            // 
            // btnDelete
            // 
            btnDelete.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDelete.Location = new Point(378, 377);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(155, 53);
            btnDelete.TabIndex = 5;
            btnDelete.Text = "Remove";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += BtnDelete_Click;
            // 
            // btnAdd
            // 
            btnAdd.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAdd.Location = new Point(20, 381);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(139, 49);
            btnAdd.TabIndex = 6;
            btnAdd.Text = "Add .exe Project";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += BtnAdd_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnAdd);
            Controls.Add(btnDelete);
            Controls.Add(btnRun);
            Controls.Add(gbDetails);
            Controls.Add(lstProjects);
            Name = "Form1";
            Text = "Project Manager";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pbThumbnail).EndInit();
            gbDetails.ResumeLayout(false);
            gbDetails.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private ListBox lstProjects;
        private TextBox txtExePath;
        private PictureBox pbThumbnail;
        private GroupBox gbDetails;
        private Label lblName;
        private Button btnRun;
        private Label label4;
        private Label label3;
        private Label label2;
        private Button btnDelete;
        private Button btnAdd;
    }
}
