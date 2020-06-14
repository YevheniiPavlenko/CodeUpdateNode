namespace ConfigWindowsForms
{
    partial class WorkFoJobs
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
            this.statusStripWokForJobs = new System.Windows.Forms.StatusStrip();
            this.menuStripWorkForJobs = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.списокЗаданийToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.закрытьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.работаСЗаданиямиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.стартToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.стопToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.menuStripWorkForJobs.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStripWokForJobs
            // 
            this.statusStripWokForJobs.Location = new System.Drawing.Point(0, 428);
            this.statusStripWokForJobs.Name = "statusStripWokForJobs";
            this.statusStripWokForJobs.Size = new System.Drawing.Size(800, 22);
            this.statusStripWokForJobs.TabIndex = 0;
            this.statusStripWokForJobs.Text = "statusStrip1";
            // 
            // menuStripWorkForJobs
            // 
            this.menuStripWorkForJobs.AutoSize = false;
            this.menuStripWorkForJobs.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.menuStripWorkForJobs.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.работаСЗаданиямиToolStripMenuItem});
            this.menuStripWorkForJobs.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.menuStripWorkForJobs.Location = new System.Drawing.Point(0, 0);
            this.menuStripWorkForJobs.Name = "menuStripWorkForJobs";
            this.menuStripWorkForJobs.Size = new System.Drawing.Size(800, 24);
            this.menuStripWorkForJobs.TabIndex = 1;
            this.menuStripWorkForJobs.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.списокЗаданийToolStripMenuItem,
            this.toolStripMenuItem1,
            this.закрытьToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // списокЗаданийToolStripMenuItem
            // 
            this.списокЗаданийToolStripMenuItem.Name = "списокЗаданийToolStripMenuItem";
            this.списокЗаданийToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.списокЗаданийToolStripMenuItem.Text = "Список заданий";
            this.списокЗаданийToolStripMenuItem.Click += new System.EventHandler(this.списокЗаданийToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(159, 6);
            // 
            // закрытьToolStripMenuItem
            // 
            this.закрытьToolStripMenuItem.Name = "закрытьToolStripMenuItem";
            this.закрытьToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.закрытьToolStripMenuItem.Text = "Закрыть";
            this.закрытьToolStripMenuItem.Click += new System.EventHandler(this.закрытьToolStripMenuItem_Click);
            // 
            // работаСЗаданиямиToolStripMenuItem
            // 
            this.работаСЗаданиямиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.стартToolStripMenuItem,
            this.стопToolStripMenuItem});
            this.работаСЗаданиямиToolStripMenuItem.Name = "работаСЗаданиямиToolStripMenuItem";
            this.работаСЗаданиямиToolStripMenuItem.Size = new System.Drawing.Size(128, 20);
            this.работаСЗаданиямиToolStripMenuItem.Text = "Работа с заданиями";
            this.работаСЗаданиямиToolStripMenuItem.Paint += new System.Windows.Forms.PaintEventHandler(this.работаСЗаданиямиToolStripMenuItem_Paint);
            // 
            // стартToolStripMenuItem
            // 
            this.стартToolStripMenuItem.Name = "стартToolStripMenuItem";
            this.стартToolStripMenuItem.Size = new System.Drawing.Size(105, 22);
            this.стартToolStripMenuItem.Text = "Старт";
            this.стартToolStripMenuItem.Click += new System.EventHandler(this.стартToolStripMenuItem_Click);
            // 
            // стопToolStripMenuItem
            // 
            this.стопToolStripMenuItem.Name = "стопToolStripMenuItem";
            this.стопToolStripMenuItem.Size = new System.Drawing.Size(105, 22);
            this.стопToolStripMenuItem.Text = "Стоп";
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 404);
            this.panel1.TabIndex = 2;
            // 
            // WorkFoJobs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusStripWokForJobs);
            this.Controls.Add(this.menuStripWorkForJobs);
            this.MainMenuStrip = this.menuStripWorkForJobs;
            this.Name = "WorkFoJobs";
            this.Text = "WorkFoJobs";
            this.menuStripWorkForJobs.ResumeLayout(false);
            this.menuStripWorkForJobs.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStripWokForJobs;
        private System.Windows.Forms.MenuStrip menuStripWorkForJobs;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem закрытьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem списокЗаданийToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem работаСЗаданиямиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem стартToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem стопToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
    }
}