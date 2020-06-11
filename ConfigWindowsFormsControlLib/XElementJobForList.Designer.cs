using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Windows.Forms;

namespace ConfigWindowsFormsControlLib
{
    /// <summary>
    /// Структра которая нужна только для структуры Info_XElementJobForList
    /// </summary>
    public struct ProprtyXElementJob
    {
        public int Id;
        public string DirInput;
        public string DirOutput;

        public ProprtyXElementJob(int xId, string xDirInput, string xDirOutput)
        {
            Id = xId; DirInput = xDirInput; DirOutput = xDirOutput;
        }

        public void Set(int xId, string xDirInput, string xDirOutput) { Id = xId; DirInput = xDirInput; DirOutput = xDirOutput;}
    }

    /// <summary>
    /// Структура даных для пользовательского компонента XElementJobForList
    /// </summary>
    public struct Info_XElementJobForList
    {
        //private int cxCount;

        private int cxId;
        private string cxDirInput; 
        private string cxDirOutput;

        /// <summary>
        /// Функции и процедуры для работи с структурой
        /// </summary>
        #region OperationForStruct

        /// <summary>
        /// Получение иль назначение свойства Id
        /// </summary>
        public int Id
        {
            get { return cxId; }
            set { cxId = Id; }
        }

        /// <summary>
        /// Получение иль назначение свойства DirInput
        /// </summary>
        public string DirInput
        {
            get { return cxDirInput; }
            set { cxDirInput = DirInput; }
        }

        /// <summary>
        /// Получение иль назначение свойства DirOutput
        /// </summary>
        public string DirOutput
        {
            get { return cxDirOutput; }
            set { cxDirOutput = DirOutput; }
        }

        /// <summary>
        /// Получение иль назначение свойства всех свойств, через структуру Info_XElementJobForList, 
        /// где есть доступные свойства Id, DirInput, DirOutput
        /// </summary>
        public ProprtyXElementJob ListProperty
        {
            get {
                ProprtyXElementJob txPropertyXElement;
                txPropertyXElement.Id = cxId; txPropertyXElement.DirInput = cxDirInput; txPropertyXElement.DirOutput = cxDirOutput;
                return txPropertyXElement;
            }
            set { cxId = ListProperty.Id; cxDirInput = ListProperty.DirInput; cxDirOutput = ListProperty.DirOutput; }
        }

        #endregion

    }

    partial class XElementJobForList
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
            this.tableLayoutPanelXElementJobs = new System.Windows.Forms.TableLayoutPanel();
            this.textBox_Value_DirOutput = new System.Windows.Forms.TextBox();
            this.label_Id = new System.Windows.Forms.Label();
            this.label_Text_DirInput = new System.Windows.Forms.Label();
            this.label_Text_DirOutput = new System.Windows.Forms.Label();
            this.textBox_Value_DirInput = new System.Windows.Forms.TextBox();
            this.tableLayoutPanelXElementJobs.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanelXElementJobs
            // 
            this.tableLayoutPanelXElementJobs.ColumnCount = 7;
            this.tableLayoutPanelXElementJobs.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanelXElementJobs.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanelXElementJobs.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanelXElementJobs.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanelXElementJobs.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanelXElementJobs.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanelXElementJobs.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 12F));
            this.tableLayoutPanelXElementJobs.Controls.Add(this.textBox_Value_DirOutput, 5, 3);
            this.tableLayoutPanelXElementJobs.Controls.Add(this.label_Id, 1, 1);
            this.tableLayoutPanelXElementJobs.Controls.Add(this.label_Text_DirInput, 3, 1);
            this.tableLayoutPanelXElementJobs.Controls.Add(this.label_Text_DirOutput, 3, 3);
            this.tableLayoutPanelXElementJobs.Controls.Add(this.textBox_Value_DirInput, 5, 1);
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
            this.tableLayoutPanelXElementJobs.Size = new System.Drawing.Size(600, 100);
            this.tableLayoutPanelXElementJobs.TabIndex = 0;
            // 
            // textBox_Value_DirOutput
            // 
            this.textBox_Value_DirOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_Value_DirOutput.Location = new System.Drawing.Point(219, 58);
            this.textBox_Value_DirOutput.Multiline = true;
            this.textBox_Value_DirOutput.Name = "textBox_Value_DirOutput";
            this.textBox_Value_DirOutput.Size = new System.Drawing.Size(366, 29);
            this.textBox_Value_DirOutput.TabIndex = 4;
            // 
            // label_Id
            // 
            this.label_Id.AutoSize = true;
            this.label_Id.Cursor = System.Windows.Forms.Cursors.Default;
            this.label_Id.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Id.Location = new System.Drawing.Point(13, 10);
            this.label_Id.Name = "label_Id";
            this.label_Id.Size = new System.Drawing.Size(25, 35);
            this.label_Id.TabIndex = 0;
            this.label_Id.Text = "{label_Id}";
            this.label_Id.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Text_DirInput
            // 
            this.label_Text_DirInput.AutoSize = true;
            this.label_Text_DirInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Text_DirInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_Text_DirInput.Location = new System.Drawing.Point(54, 10);
            this.label_Text_DirInput.Name = "label_Text_DirInput";
            this.label_Text_DirInput.Size = new System.Drawing.Size(149, 35);
            this.label_Text_DirInput.TabIndex = 1;
            this.label_Text_DirInput.Text = "Наименование исходящей директории";
            this.label_Text_DirInput.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_Text_DirOutput
            // 
            this.label_Text_DirOutput.AutoSize = true;
            this.label_Text_DirOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Text_DirOutput.Location = new System.Drawing.Point(54, 55);
            this.label_Text_DirOutput.Name = "label_Text_DirOutput";
            this.label_Text_DirOutput.Size = new System.Drawing.Size(149, 35);
            this.label_Text_DirOutput.TabIndex = 2;
            this.label_Text_DirOutput.Text = "Наименование директории назначяения\r\n";
            this.label_Text_DirOutput.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox_Value_DirInput
            // 
            this.textBox_Value_DirInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_Value_DirInput.Location = new System.Drawing.Point(219, 13);
            this.textBox_Value_DirInput.Multiline = true;
            this.textBox_Value_DirInput.Name = "textBox_Value_DirInput";
            this.textBox_Value_DirInput.Size = new System.Drawing.Size(366, 29);
            this.textBox_Value_DirInput.TabIndex = 3;
            // 
            // XElementJobForList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanelXElementJobs);
            this.Name = "XElementJobForList";
            this.Size = new System.Drawing.Size(600, 100);
            this.tableLayoutPanelXElementJobs.ResumeLayout(false);
            this.tableLayoutPanelXElementJobs.PerformLayout();
            this.ResumeLayout(false);

        }

        public void SetValue (ProprtyXElementJob xElemrntJob)
        {
            label_Id.Text = xElemrntJob.Id.ToString();
            textBox_Value_DirInput.Text = xElemrntJob.DirInput;
            textBox_Value_DirOutput.Text = xElemrntJob.DirOutput;
        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelXElementJobs;
        private System.Windows.Forms.Label label_Id;
        private System.Windows.Forms.Label label_Text_DirInput;
        private System.Windows.Forms.Label label_Text_DirOutput;
        private System.Windows.Forms.TextBox textBox_Value_DirOutput;
        private System.Windows.Forms.TextBox textBox_Value_DirInput;
    }
}
