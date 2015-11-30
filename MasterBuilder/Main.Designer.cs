namespace MasterBuilder
{
    partial class Main
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
            this.LoadPackagesButton = new System.Windows.Forms.Button();
            this.UpdateSubmodulesButton = new System.Windows.Forms.Button();
            this.CheckForNewestUploadedNuGetButton = new System.Windows.Forms.Button();
            this.NTLabel = new System.Windows.Forms.Label();
            this.WPILibLabel = new System.Windows.Forms.Label();
            this.publishNTButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LoadPackagesButton
            // 
            this.LoadPackagesButton.Location = new System.Drawing.Point(386, 16);
            this.LoadPackagesButton.Name = "LoadPackagesButton";
            this.LoadPackagesButton.Size = new System.Drawing.Size(146, 23);
            this.LoadPackagesButton.TabIndex = 2;
            this.LoadPackagesButton.Text = "Load Newest Packages";
            this.LoadPackagesButton.UseVisualStyleBackColor = true;
            this.LoadPackagesButton.Click += new System.EventHandler(this.LoadPackagesButton_Click);
            // 
            // UpdateSubmodulesButton
            // 
            this.UpdateSubmodulesButton.Location = new System.Drawing.Point(13, 13);
            this.UpdateSubmodulesButton.Name = "UpdateSubmodulesButton";
            this.UpdateSubmodulesButton.Size = new System.Drawing.Size(205, 26);
            this.UpdateSubmodulesButton.TabIndex = 3;
            this.UpdateSubmodulesButton.Text = "Update Submodules";
            this.UpdateSubmodulesButton.UseVisualStyleBackColor = true;
            this.UpdateSubmodulesButton.Click += new System.EventHandler(this.UpdateSubmodulesButton_Click);
            // 
            // CheckForNewestUploadedNuGetButton
            // 
            this.CheckForNewestUploadedNuGetButton.Location = new System.Drawing.Point(13, 79);
            this.CheckForNewestUploadedNuGetButton.Name = "CheckForNewestUploadedNuGetButton";
            this.CheckForNewestUploadedNuGetButton.Size = new System.Drawing.Size(134, 32);
            this.CheckForNewestUploadedNuGetButton.TabIndex = 4;
            this.CheckForNewestUploadedNuGetButton.Text = "Check Nuget Versions";
            this.CheckForNewestUploadedNuGetButton.UseVisualStyleBackColor = true;
            this.CheckForNewestUploadedNuGetButton.Click += new System.EventHandler(this.CheckForNewestUploadedNuGetButton_Click);
            // 
            // NTLabel
            // 
            this.NTLabel.AutoSize = true;
            this.NTLabel.Location = new System.Drawing.Point(168, 79);
            this.NTLabel.Name = "NTLabel";
            this.NTLabel.Size = new System.Drawing.Size(35, 13);
            this.NTLabel.TabIndex = 5;
            this.NTLabel.Text = "label1";
            // 
            // WPILibLabel
            // 
            this.WPILibLabel.AutoSize = true;
            this.WPILibLabel.Location = new System.Drawing.Point(171, 105);
            this.WPILibLabel.Name = "WPILibLabel";
            this.WPILibLabel.Size = new System.Drawing.Size(35, 13);
            this.WPILibLabel.TabIndex = 6;
            this.WPILibLabel.Text = "label2";
            // 
            // publishNTButton
            // 
            this.publishNTButton.Location = new System.Drawing.Point(13, 154);
            this.publishNTButton.Name = "publishNTButton";
            this.publishNTButton.Size = new System.Drawing.Size(171, 23);
            this.publishNTButton.TabIndex = 7;
            this.publishNTButton.Text = "Publish Network Tables";
            this.publishNTButton.UseVisualStyleBackColor = true;
            this.publishNTButton.Click += new System.EventHandler(this.publishNTButton_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(664, 356);
            this.Controls.Add(this.publishNTButton);
            this.Controls.Add(this.WPILibLabel);
            this.Controls.Add(this.NTLabel);
            this.Controls.Add(this.CheckForNewestUploadedNuGetButton);
            this.Controls.Add(this.UpdateSubmodulesButton);
            this.Controls.Add(this.LoadPackagesButton);
            this.Name = "Main";
            this.Text = "Master WPILib Release Builder";
            this.Load += new System.EventHandler(this.Main_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button LoadPackagesButton;
        private System.Windows.Forms.Button UpdateSubmodulesButton;
        private System.Windows.Forms.Button CheckForNewestUploadedNuGetButton;
        private System.Windows.Forms.Label NTLabel;
        private System.Windows.Forms.Label WPILibLabel;
        private System.Windows.Forms.Button publishNTButton;
    }
}

