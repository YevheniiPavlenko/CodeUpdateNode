using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Forms.ComponentModel.Com2Interop;
using System.Xml.Linq;
using AllClass;

namespace ConfigWindowsFormsControlLib
{
  
    partial class XElementJobForList
    {
        private PropertyXElementJob cxPropertyXElementJob = new PropertyXElementJob();
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
            this.tableLayoutPanelXElementJobs = new System.Windows.Forms.TableLayoutPanel();
            this.textBox_Value_DirOutput = new System.Windows.Forms.TextBox();
            this.label_Text_DirInput = new System.Windows.Forms.Label();
            this.label_Text_DirOutput = new System.Windows.Forms.Label();
            this.textBox_Value_DirInput = new System.Windows.Forms.TextBox();
            this.buttonDirInput = new System.Windows.Forms.Button();
            this.buttonDirOutput = new System.Windows.Forms.Button();
            this.tableLayoutPanelXElementJobs.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanelXElementJobs
            // 
            this.tableLayoutPanelXElementJobs.ColumnCount = 5;
            this.tableLayoutPanelXElementJobs.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanelXElementJobs.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanelXElementJobs.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanelXElementJobs.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanelXElementJobs.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tableLayoutPanelXElementJobs.Controls.Add(this.textBox_Value_DirOutput, 3, 3);
            this.tableLayoutPanelXElementJobs.Controls.Add(this.label_Text_DirInput, 1, 1);
            this.tableLayoutPanelXElementJobs.Controls.Add(this.label_Text_DirOutput, 1, 3);
            this.tableLayoutPanelXElementJobs.Controls.Add(this.textBox_Value_DirInput, 3, 1);
            this.tableLayoutPanelXElementJobs.Controls.Add(this.buttonDirInput, 4, 1);
            this.tableLayoutPanelXElementJobs.Controls.Add(this.buttonDirOutput, 4, 3);
            this.tableLayoutPanelXElementJobs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelXElementJobs.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.tableLayoutPanelXElementJobs.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelXElementJobs.Name = "tableLayoutPanelXElementJobs";
            this.tableLayoutPanelXElementJobs.RowCount = 5;
            this.tableLayoutPanelXElementJobs.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanelXElementJobs.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelXElementJobs.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanelXElementJobs.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelXElementJobs.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanelXElementJobs.Size = new System.Drawing.Size(602, 102);
            this.tableLayoutPanelXElementJobs.TabIndex = 0;
            // 
            // textBox_Value_DirOutput
            // 
            this.textBox_Value_DirOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_Value_DirOutput.Location = new System.Drawing.Point(188, 59);
            this.textBox_Value_DirOutput.Multiline = true;
            this.textBox_Value_DirOutput.Name = "textBox_Value_DirOutput";
            this.textBox_Value_DirOutput.Size = new System.Drawing.Size(379, 30);
            this.textBox_Value_DirOutput.TabIndex = 4;
            // 
            // label_Text_DirInput
            // 
            this.label_Text_DirInput.AutoSize = true;
            this.label_Text_DirInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Text_DirInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_Text_DirInput.Location = new System.Drawing.Point(13, 10);
            this.label_Text_DirInput.Name = "label_Text_DirInput";
            this.label_Text_DirInput.Size = new System.Drawing.Size(159, 36);
            this.label_Text_DirInput.TabIndex = 1;
            this.label_Text_DirInput.Text = "Наименование исходящей директории";
            this.label_Text_DirInput.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_Text_DirOutput
            // 
            this.label_Text_DirOutput.AutoSize = true;
            this.label_Text_DirOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Text_DirOutput.Location = new System.Drawing.Point(13, 56);
            this.label_Text_DirOutput.Name = "label_Text_DirOutput";
            this.label_Text_DirOutput.Size = new System.Drawing.Size(159, 36);
            this.label_Text_DirOutput.TabIndex = 2;
            this.label_Text_DirOutput.Text = "Наименование директории назначяения\r\n";
            this.label_Text_DirOutput.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox_Value_DirInput
            // 
            this.textBox_Value_DirInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_Value_DirInput.Location = new System.Drawing.Point(188, 13);
            this.textBox_Value_DirInput.Multiline = true;
            this.textBox_Value_DirInput.Name = "textBox_Value_DirInput";
            this.textBox_Value_DirInput.Size = new System.Drawing.Size(379, 30);
            this.textBox_Value_DirInput.TabIndex = 3;
            // 
            // buttonDirInput
            // 
            this.buttonDirInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonDirInput.Location = new System.Drawing.Point(573, 13);
            this.buttonDirInput.Name = "buttonDirInput";
            this.buttonDirInput.Size = new System.Drawing.Size(26, 30);
            this.buttonDirInput.TabIndex = 5;
            this.buttonDirInput.Text = "...";
            this.buttonDirInput.UseVisualStyleBackColor = true;
            this.buttonDirInput.Click += new System.EventHandler(this.buttonDir_Click);
            // 
            // buttonDirOutput
            // 
            this.buttonDirOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonDirOutput.Location = new System.Drawing.Point(573, 59);
            this.buttonDirOutput.Name = "buttonDirOutput";
            this.buttonDirOutput.Size = new System.Drawing.Size(26, 30);
            this.buttonDirOutput.TabIndex = 6;
            this.buttonDirOutput.Text = "...";
            this.buttonDirOutput.UseVisualStyleBackColor = true;
            this.buttonDirOutput.Click += new System.EventHandler(this.buttonDir_Click);
            // 
            // XElementJobForList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanelXElementJobs);
            this.Name = "XElementJobForList";
            this.Size = new System.Drawing.Size(602, 102);
            this.tableLayoutPanelXElementJobs.ResumeLayout(false);
            this.tableLayoutPanelXElementJobs.PerformLayout();
            this.ResumeLayout(false);

        }

        public void SetValue (PropertyXElementJob xElemrntJob)
        {
            cxPropertyXElementJob.Set(xElemrntJob._Id, xElemrntJob._DirInput, xElemrntJob._DirOutput);
            textBox_Value_DirInput.Text = xElemrntJob._DirInput;
            textBox_Value_DirOutput.Text = xElemrntJob._DirOutput;
        }

        private Button buttonDirInput;
        private Button buttonDirOutput;

        public PropertyXElementJob Value { 
            get { return cxPropertyXElementJob; }
            set { cxPropertyXElementJob = value; }
        }

        private TableLayoutPanel tableLayoutPanelXElementJobs;
        private TextBox textBox_Value_DirOutput;
        private Label label_Text_DirInput;
        private Label label_Text_DirOutput;
        private TextBox textBox_Value_DirInput;

        public void SetValue (XElement xElementJob)
        {
            cxPropertyXElementJob.Set(Convert.ToInt32(xElementJob.Attribute("Id").Value), xElementJob.Attribute("dirPatchInput").Value, xElementJob.Attribute("dirPatchOutput").Value);
            textBox_Value_DirInput.Text = xElementJob.Attribute("dirPatchInput").Value;
            textBox_Value_DirOutput.Text = xElementJob.Attribute("dirPatchOutput").Value;
        }

        #endregion
    }
}
