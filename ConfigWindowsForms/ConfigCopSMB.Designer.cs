namespace ConfigWindowsForms
{
    partial class ConfigCopSMB
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfigCopSMB));
            this.mainListJobs1 = new ConfigWindowsFormsControlLib.MainListJobs();
            this.SuspendLayout();
            // 
            // mainListJobs1
            // 
            this.mainListJobs1.AutoScroll = true;
            this.mainListJobs1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainListJobs1.Location = new System.Drawing.Point(0, 0);
            this.mainListJobs1.Name = "mainListJobs1";
            this.mainListJobs1.Size = new System.Drawing.Size(627, 347);
            this.mainListJobs1.TabIndex = 0;
            // 
            // ConfigCopSMB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(627, 347);
            this.Controls.Add(this.mainListJobs1);
            this.Name = "ConfigCopSMB";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.ConfigCopSMB_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ConfigWindowsFormsControlLib.MainListJobs mainListJobs1;
    }
}

