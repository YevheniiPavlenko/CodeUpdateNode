namespace ConfigWindowsFormsControlLib
{
    partial class StatusJobs
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label_PatchInput = new System.Windows.Forms.Label();
            this.label_PatchOutput = new System.Windows.Forms.Label();
            this.label_CountFiles = new System.Windows.Forms.Label();
            this.label_Status = new System.Windows.Forms.Label();
            this.progressBar_Proces = new System.Windows.Forms.ProgressBar();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.label_PatchInput, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label_PatchOutput, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.label_CountFiles, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.label_Status, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.progressBar_Proces, 3, 4);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(598, 158);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label_PatchInput
            // 
            this.label_PatchInput.AutoSize = true;
            this.label_PatchInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_PatchInput.Location = new System.Drawing.Point(23, 20);
            this.label_PatchInput.Name = "label_PatchInput";
            this.label_PatchInput.Size = new System.Drawing.Size(263, 49);
            this.label_PatchInput.TabIndex = 0;
            this.label_PatchInput.Text = "{label_PatchInput}";
            // 
            // label_PatchOutput
            // 
            this.label_PatchOutput.AutoSize = true;
            this.label_PatchOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_PatchOutput.Location = new System.Drawing.Point(312, 20);
            this.label_PatchOutput.Name = "label_PatchOutput";
            this.label_PatchOutput.Size = new System.Drawing.Size(263, 49);
            this.label_PatchOutput.TabIndex = 1;
            this.label_PatchOutput.Text = "{label_PatchOutput}";
            // 
            // label_CountFiles
            // 
            this.label_CountFiles.AutoSize = true;
            this.label_CountFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_CountFiles.Location = new System.Drawing.Point(312, 89);
            this.label_CountFiles.Name = "label_CountFiles";
            this.label_CountFiles.Size = new System.Drawing.Size(263, 24);
            this.label_CountFiles.TabIndex = 2;
            this.label_CountFiles.Text = "{label_CountFiles}";
            this.label_CountFiles.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Status
            // 
            this.label_Status.AutoSize = true;
            this.label_Status.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Status.Location = new System.Drawing.Point(23, 89);
            this.label_Status.Name = "label_Status";
            this.label_Status.Size = new System.Drawing.Size(263, 24);
            this.label_Status.TabIndex = 3;
            this.label_Status.Text = "{label_Status}";
            // 
            // progressBar_Proces
            // 
            this.progressBar_Proces.Dock = System.Windows.Forms.DockStyle.Fill;
            this.progressBar_Proces.Location = new System.Drawing.Point(312, 116);
            this.progressBar_Proces.Name = "progressBar_Proces";
            this.progressBar_Proces.Size = new System.Drawing.Size(263, 18);
            this.progressBar_Proces.TabIndex = 4;
            // 
            // StatusJobs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "StatusJobs";
            this.Size = new System.Drawing.Size(598, 158);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label_PatchInput;
        private System.Windows.Forms.Label label_PatchOutput;
        private System.Windows.Forms.Label label_CountFiles;
        private System.Windows.Forms.Label label_Status;
        private System.Windows.Forms.ProgressBar progressBar_Proces;
    }
}
