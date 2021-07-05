using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using AllClass;
using ConfigClassLib;
using ConfigWindowsFormsControlLib;

namespace ConfigWindowsForms
{
    public partial class WorkFoJobs : Form
    {
        bool xEnableMenu = false;
        //Task xtask = new Task();
        List<PropertyStatusJob> propertyStatusJobsLIst = new List<PropertyStatusJob>();

        public WorkFoJobs()
        {
            InitializeComponent();
        }

        private void закрытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void списокЗаданийToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form xform = new ConfigCopSMB();
            xform.ShowDialog();
        }

        private void работаСЗаданиямиToolStripMenuItem_Paint(object sender, PaintEventArgs e)
        {
            if (xEnableMenu == false)
            {
                стартToolStripMenuItem.Enabled = true;
                стопToolStripMenuItem.Enabled = false;
            } else
            {
                стартToolStripMenuItem.Enabled = false;
                стопToolStripMenuItem.Enabled = true;
            }

        }

        //private void CopyFileDir(PropertyXElementJob propertyXElementJobTemplate)
        //{
        //    DirectoryInfo cxDirInputInfo = new DirectoryInfo(propertyXElementJobTemplate._DirInput);
        //    FileInfo[] xListFiles = cxDirInputInfo.GetFiles("*", SearchOption.AllDirectories);
        //    MessageBox.Show($"В каталоге '{propertyXElementJobTemplate._DirInput}\n Найдено файлов: {xListFiles.Length.ToString()}\n");
        //}

        //private string CopyFileDirMess(PropertyXElementJob propertyXElementJobTemplate)
        //{
        //    DirectoryInfo cxDirInputInfo = new DirectoryInfo(propertyXElementJobTemplate._DirInput);
        //    FileInfo[] xListFiles = cxDirInputInfo.GetFiles("*", SearchOption.AllDirectories);
        //    return "В каталоге '" + propertyXElementJobTemplate._DirInput + "'\n Найдено файлов: " + xListFiles.Length.ToString() + "\n";
        //}

        private void стартToolStripMenuItem_Click(object sender, EventArgs e)
        {
            xEnableMenu = true;

            if (this.Controls.Find("flowLayoutPanelTamplate1", true).Count() > 0)
            {
                foreach(Control controlTemplate in this.Controls.Find("flowLayoutPanelTamplate1", true)) { this.Controls.Remove(controlTemplate); }
            }

            FlowLayoutPanel flowLayoutPanelTamplate = new FlowLayoutPanel();
            flowLayoutPanelTamplate.Name = "flowLayoutPanelTamplate1";
            flowLayoutPanelTamplate.Location = this.Location;
            flowLayoutPanelTamplate.Size = this.Size;
            flowLayoutPanelTamplate.Dock = DockStyle.Fill;

            GroupBox groupBoxTemplate;
            StatusJobs StatusJobsTemplate;

            int pointDrawPos = 10 + menuStripWorkForJobs.Height + menuStripWorkForJobs.Top;
            flowLayoutPanelTamplate.Top = pointDrawPos;

            List<PropertyXElementJob> propertyXElementJobsList = new List<PropertyXElementJob>();
            propertyXElementJobsList = ConfigSMB.getInfo_XElemetJobForListAll();
            foreach (PropertyXElementJob xProprtyXElementJobAttachControl in propertyXElementJobsList)
            {
                groupBoxTemplate = new GroupBox();
                StatusJobsTemplate = new StatusJobs();

                StatusJobsTemplate.SetValue(xProprtyXElementJobAttachControl);
                StatusJobsTemplate.Name = @"StatusJobsTemplate_" + xProprtyXElementJobAttachControl._Id.ToString();
                StatusJobsTemplate.Top = 40;
                StatusJobsTemplate.Left = 10;

                groupBoxTemplate.Name = @"groupBox_" + xProprtyXElementJobAttachControl._Id.ToString();
                groupBoxTemplate.Width = StatusJobsTemplate.Size.Width + 20;
                groupBoxTemplate.Height = StatusJobsTemplate.Size.Height + 60;
                groupBoxTemplate.Text = "Задание № " + StatusJobsTemplate.Value._Id.ToString();
                groupBoxTemplate.Top = pointDrawPos;
                groupBoxTemplate.Left = 10;

                groupBoxTemplate.Controls.Add(StatusJobsTemplate);

                pointDrawPos += StatusJobsTemplate.Height + 20;

                StatusJobsTemplate.GetValueToUserControl();

                flowLayoutPanelTamplate.Controls.Add(groupBoxTemplate);
            }

            flowLayoutPanelTamplate.AutoScroll = true;
            this.panel1.Controls.Add(flowLayoutPanelTamplate);

            foreach (PropertyXElementJob xProprtyXElementJobAttachControl in propertyXElementJobsList)
            {
                Control[] ListFindControl = this.panel1.Controls.Find(@"StatusJobsTemplate_" + xProprtyXElementJobAttachControl._Id.ToString(), true);
                foreach(Control xcontrolTemp in ListFindControl)
                {
                    try { ((StatusJobs)(xcontrolTemp)).Start_Task(); }
                    catch { return; }
                    
                }
            }
        }

        private void стопToolStripMenuItem_Click(object sender, EventArgs e)
        {
            xEnableMenu = false;

            List<PropertyXElementJob> propertyXElementJobsList = new List<PropertyXElementJob>();
            propertyXElementJobsList = ConfigSMB.getInfo_XElemetJobForListAll();
            foreach (PropertyXElementJob xProprtyXElementJobAttachControl in propertyXElementJobsList)
            {
                Control[] ListFindControl = this.panel1.Controls.Find(@"StatusJobsTemplate_" + xProprtyXElementJobAttachControl._Id.ToString(), true);
                foreach (Control xcontrolTemp in ListFindControl)
                {
                    try { ((StatusJobs)(xcontrolTemp)).Stop_Task(); }
                    catch { return; }

                }
            }

            this.panel1.Controls.Clear();
        }
    }
}
