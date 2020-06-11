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
            this.xElementJobForList1 = new ConfigWindowsFormsControlLib.XElementJobForList();
            this.SuspendLayout();
            // 
            // xElementJobForList1
            // 
            this.xElementJobForList1.Location = new System.Drawing.Point(12, 23);
            this.xElementJobForList1.Name = "xElementJobForList1";
            this.xElementJobForList1.Size = new System.Drawing.Size(600, 100);
            this.xElementJobForList1.TabIndex = 0;
            // 
            // ConfigCopSMB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(627, 347);
            this.Controls.Add(this.xElementJobForList1);
            this.Name = "ConfigCopSMB";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.ConfigCopSMB_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ConfigWindowsFormsControlLib.XElementJobForList xElementJobForList1;
    }
}

