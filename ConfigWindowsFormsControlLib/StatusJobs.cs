using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AllClass;
using System.IO;

namespace ConfigWindowsFormsControlLib
{
    public partial class StatusJobs : UserControl
    {
        private PropertyStatusJob propertyStatusFJob = new PropertyStatusJob();
        private Task xtask;

        public StatusJobs()
        {
            InitializeComponent();
        }

        public Task TaskValue
        {
            get { return xtask; }
            set { xtask = value; }
        }

        public PropertyStatusJob Value { 
            get { label_Status.Text = TaskValue.Status.ToString(); return propertyStatusFJob; }
            set { propertyStatusFJob = value; }
        }

        public void FindFiles()
        {
            DirectoryInfo cxDirInputInfo = new DirectoryInfo(propertyStatusFJob._DirInput);
            FileInfo[] xListFiles = cxDirInputInfo.GetFiles("*", SearchOption.AllDirectories);
            propertyStatusFJob._CountFiles = xListFiles.Length;
        }

        public void SetValue(PropertyXElementJob xPropertyXElementJobTemp)
        {
            propertyStatusFJob._Id = xPropertyXElementJobTemp._Id;
            propertyStatusFJob._DirInput = xPropertyXElementJobTemp._DirInput;
            propertyStatusFJob._DirOutput = xPropertyXElementJobTemp._DirOutput;
            FindFiles();
            GetValueToUserControl();
        }

        public void GetValueToUserControl()
        {
            label_PatchInput.Text = "Исходящяя директория:\n" + propertyStatusFJob._DirInput;
            label_PatchOutput.Text = "Директория назначения:\n" + propertyStatusFJob._DirOutput;
            label_CountFiles.Text = propertyStatusFJob._CountFiles.ToString();
            label_Status.Text = TaskValue.Status.ToString();
        }
    }
}
