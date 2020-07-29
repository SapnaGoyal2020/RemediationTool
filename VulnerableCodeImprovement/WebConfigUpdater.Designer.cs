namespace VulnerableCodeImprovement
{
    partial class WebConfigUpdater
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
            this.webConfigProgressBar = new System.Windows.Forms.ProgressBar();
            this.btn_Browse = new System.Windows.Forms.Button();
            this.txt_Browse = new System.Windows.Forms.TextBox();
            this.listView_Browse = new System.Windows.Forms.ListView();
            this.FileName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.FilePath = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btn_Process = new System.Windows.Forms.Button();
            this.lbl_message = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // webConfigProgressBar
            // 
            this.webConfigProgressBar.Location = new System.Drawing.Point(138, 304);
            this.webConfigProgressBar.Name = "webConfigProgressBar";
            this.webConfigProgressBar.Size = new System.Drawing.Size(434, 23);
            this.webConfigProgressBar.TabIndex = 0;
            // 
            // btn_Browse
            // 
            this.btn_Browse.Location = new System.Drawing.Point(569, 47);
            this.btn_Browse.Name = "btn_Browse";
            this.btn_Browse.Size = new System.Drawing.Size(75, 23);
            this.btn_Browse.TabIndex = 1;
            this.btn_Browse.Text = "Browse";
            this.btn_Browse.UseVisualStyleBackColor = true;
            this.btn_Browse.Click += new System.EventHandler(this.btn_Browse_Click);
            // 
            // txt_Browse
            // 
            this.txt_Browse.Location = new System.Drawing.Point(138, 49);
            this.txt_Browse.Name = "txt_Browse";
            this.txt_Browse.Size = new System.Drawing.Size(425, 20);
            this.txt_Browse.TabIndex = 2;
            // 
            // listView_Browse
            // 
            this.listView_Browse.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.FileName,
            this.FilePath});
            this.listView_Browse.HideSelection = false;
            this.listView_Browse.Location = new System.Drawing.Point(138, 75);
            this.listView_Browse.Name = "listView_Browse";
            this.listView_Browse.Size = new System.Drawing.Size(425, 97);
            this.listView_Browse.TabIndex = 3;
            this.listView_Browse.UseCompatibleStateImageBehavior = false;
            this.listView_Browse.View = System.Windows.Forms.View.Details;
            // 
            // FileName
            // 
            this.FileName.Text = "FileName";
            this.FileName.Width = 250;
            // 
            // FilePath
            // 
            this.FilePath.Text = "FilePath";
            this.FilePath.Width = 750;
            // 
            // btn_Process
            // 
            this.btn_Process.Location = new System.Drawing.Point(285, 178);
            this.btn_Process.Name = "btn_Process";
            this.btn_Process.Size = new System.Drawing.Size(75, 23);
            this.btn_Process.TabIndex = 4;
            this.btn_Process.Text = "Process";
            this.btn_Process.UseVisualStyleBackColor = true;
            this.btn_Process.Visible = false;
            this.btn_Process.Click += new System.EventHandler(this.btn_Process_Click);
            // 
            // lbl_message
            // 
            this.lbl_message.AutoSize = true;
            this.lbl_message.Location = new System.Drawing.Point(285, 353);
            this.lbl_message.Name = "lbl_message";
            this.lbl_message.Size = new System.Drawing.Size(65, 13);
            this.lbl_message.TabIndex = 5;
            this.lbl_message.Text = "lbl_message";
            this.lbl_message.Visible = false;
            // 
            // WebConfigUpdater
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lbl_message);
            this.Controls.Add(this.btn_Process);
            this.Controls.Add(this.listView_Browse);
            this.Controls.Add(this.txt_Browse);
            this.Controls.Add(this.btn_Browse);
            this.Controls.Add(this.webConfigProgressBar);
            this.Name = "WebConfigUpdater";
            this.Text = "WebConfigUpdater";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar webConfigProgressBar;
        private System.Windows.Forms.Button btn_Browse;
        private System.Windows.Forms.TextBox txt_Browse;
        private System.Windows.Forms.ListView listView_Browse;
        private System.Windows.Forms.ColumnHeader FileName;
        private System.Windows.Forms.ColumnHeader FilePath;
        private System.Windows.Forms.Button btn_Process;
        private System.Windows.Forms.Label lbl_message;
    }
}

