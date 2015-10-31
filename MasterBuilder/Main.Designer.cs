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
            this.panel1 = new System.Windows.Forms.Panel();
            this.updateNTButton = new System.Windows.Forms.Button();
            this.updateWPILibButton = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.releaseNTButton = new System.Windows.Forms.Button();
            this.releaseWPILibButton = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.updateNTButton);
            this.panel1.Controls.Add(this.updateWPILibButton);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 66);
            this.panel1.TabIndex = 0;
            // 
            // updateNTButton
            // 
            this.updateNTButton.Location = new System.Drawing.Point(4, 34);
            this.updateNTButton.Name = "updateNTButton";
            this.updateNTButton.Size = new System.Drawing.Size(193, 23);
            this.updateNTButton.TabIndex = 1;
            this.updateNTButton.Text = "Update NetworkTables Submodule";
            this.updateNTButton.UseVisualStyleBackColor = true;
            this.updateNTButton.Click += new System.EventHandler(this.updateNTButton_Click);
            // 
            // updateWPILibButton
            // 
            this.updateWPILibButton.Location = new System.Drawing.Point(4, 4);
            this.updateWPILibButton.Name = "updateWPILibButton";
            this.updateWPILibButton.Size = new System.Drawing.Size(193, 23);
            this.updateWPILibButton.TabIndex = 0;
            this.updateWPILibButton.Text = "Update WPILib Submodule";
            this.updateWPILibButton.UseVisualStyleBackColor = true;
            this.updateWPILibButton.Click += new System.EventHandler(this.updateWPILibButton_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.button3);
            this.panel2.Controls.Add(this.releaseWPILibButton);
            this.panel2.Controls.Add(this.releaseNTButton);
            this.panel2.Location = new System.Drawing.Point(152, 178);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 100);
            this.panel2.TabIndex = 1;
            // 
            // releaseNTButton
            // 
            this.releaseNTButton.Location = new System.Drawing.Point(4, 4);
            this.releaseNTButton.Name = "releaseNTButton";
            this.releaseNTButton.Size = new System.Drawing.Size(193, 23);
            this.releaseNTButton.TabIndex = 0;
            this.releaseNTButton.Text = "Build NetworkTables NuGet";
            this.releaseNTButton.UseVisualStyleBackColor = true;
            // 
            // releaseWPILibButton
            // 
            this.releaseWPILibButton.Location = new System.Drawing.Point(3, 33);
            this.releaseWPILibButton.Name = "releaseWPILibButton";
            this.releaseWPILibButton.Size = new System.Drawing.Size(193, 23);
            this.releaseWPILibButton.TabIndex = 0;
            this.releaseWPILibButton.Text = "button1";
            this.releaseWPILibButton.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(3, 62);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(193, 23);
            this.button3.TabIndex = 0;
            this.button3.Text = "button1";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(664, 356);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Main";
            this.Text = "Master WPILib Release Builder";
            this.Load += new System.EventHandler(this.Main_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button updateNTButton;
        private System.Windows.Forms.Button updateWPILibButton;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button releaseWPILibButton;
        private System.Windows.Forms.Button releaseNTButton;
    }
}

