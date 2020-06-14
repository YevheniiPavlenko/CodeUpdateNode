using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AllClass;
using ConfigClassLib;

namespace ConfigWindowsForms
{
    public partial class WorkFoJobs : Form
    {
        //Task xtask = new Task();

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
            стартToolStripMenuItem.Enabled = true;
            стопToolStripMenuItem.Enabled = false;
        }

        private void CopyFileDir(PropertyXElementJob propertyXElementJobTemplate)
        {
            DirectoryInfo cxDirInputInfo = new DirectoryInfo(propertyXElementJobTemplate._DirInput);
            FileInfo[] xListFiles = cxDirInputInfo.GetFiles("*", SearchOption.AllDirectories);
            MessageBox.Show($"В каталоге '{propertyXElementJobTemplate._DirInput}\n Найдено файлов: {xListFiles.Length.ToString()}\n");
        }

        private string CopyFileDirMess(PropertyXElementJob propertyXElementJobTemplate)
        {
            DirectoryInfo cxDirInputInfo = new DirectoryInfo(propertyXElementJobTemplate._DirInput);
            FileInfo[] xListFiles = cxDirInputInfo.GetFiles("*", SearchOption.AllDirectories);
            return "В каталоге '" + propertyXElementJobTemplate._DirInput + "'\n Найдено файлов: " + xListFiles.Length.ToString() + "\n";
        }

        private void стартToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<PropertyXElementJob> propertyXElementJobsList = new List<PropertyXElementJob>();
            List<string> vs_list = new List<string>();
            string Mess = "";

            propertyXElementJobsList = ConfigSMB.getInfo_XElemetJobForListAll();
            foreach(PropertyXElementJob xPropertyXElementJobTemplate in propertyXElementJobsList)
            {
                vs_list.Add(CopyFileDirMess(xPropertyXElementJobTemplate));
                Mess += CopyFileDirMess(xPropertyXElementJobTemplate) + "\n";
            }
            MessageBox.Show($"{ Mess }");
        }
    }
}
