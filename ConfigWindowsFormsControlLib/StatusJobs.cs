using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using AllClass;
using System.IO;
using System.Xml.XPath;

namespace ConfigWindowsFormsControlLib
{
    public partial class StatusJobs : UserControl
    {
        private PropertyStatusJob propertyStatusFJob = new PropertyStatusJob();
        private Task xtask;
        CancellationTokenSource cts;

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


        public FileInfo[] FindFilePatch(string FindMask = "*")
        {
            DirectoryInfo cxDirInputInfo = new DirectoryInfo(propertyStatusFJob._DirInput);
            FileInfo[] xListFiles = cxDirInputInfo.GetFiles(FindMask, SearchOption.AllDirectories);

            return xListFiles;
        }

        public void SetValue(PropertyXElementJob xPropertyXElementJobTemp)
        {
            propertyStatusFJob._Id = xPropertyXElementJobTemp._Id;
            propertyStatusFJob._DirInput = xPropertyXElementJobTemp._DirInput;
            propertyStatusFJob._DirOutput = xPropertyXElementJobTemp._DirOutput;
            FindFiles();
            GetValueToUserControl();
        }


        public void InitTaskStatus_Backup(CancellationToken cancellationToken)
        {
            FileInfo[] fileInfosTemplate = FindFilePatch();
            progressBar_Proces.Maximum = 100;

            this.Invoke(new Action(() =>
            {
                progressBar_Proces.Maximum = fileInfosTemplate.Count();
            }));

            string FileName;
            string AldPachDir;
            string OldFillName;

            int xInt_CountWorkFiles = 0;
            foreach (FileInfo xfileInfo in fileInfosTemplate)
            {
                FileName = xfileInfo.Name;
                AldPachDir = xfileInfo.FullName.Substring(propertyStatusFJob._DirInput.Length + 1, Path.GetDirectoryName(xfileInfo.FullName).Length - propertyStatusFJob._DirInput.Length);

                if (AldPachDir == null) { AldPachDir = ""; }
                OldFillName = Path.Combine(this.propertyStatusFJob._DirOutput + @"\\" + AldPachDir + @"\\", FileName);
                OldFillName.Replace(@"\\\\", @"\\");

                if (!Directory.Exists(Path.GetDirectoryName(OldFillName))) { Directory.CreateDirectory(Path.GetDirectoryName(OldFillName)); }

                try { File.Copy(xfileInfo.FullName, OldFillName, true); }
                catch { };
                
                xInt_CountWorkFiles++;

                this.Invoke(new Action(() =>
                {
                    label_CountFiles.Text = xInt_CountWorkFiles.ToString() + @" / " + fileInfosTemplate.Count();
                    progressBar_Proces.Value = xInt_CountWorkFiles;
                })); 
                //progressBar_Proces.Value = Convert.ToInt32((fileInfosTemplate.Count() / xInt64_CountWorkFiles) * 100);
                //Проверяет не завершена ли операция
                cancellationToken.ThrowIfCancellationRequested();
            }
        }

        //public async void Status_Task()
        //{
        //    //await xtask;
        //    label_Status.Text = TaskValue.Status.ToString();
        //}

        public  void Start_Task()
        {
            xtask.Start();
            label_Status.Text = TaskValue.Status.ToString();
//            Status_Task();
        }

        public void Stop_Task()
        {
            cts.Cancel();
            label_CountFiles.Text = propertyStatusFJob._CountFiles.ToString();
            label_Status.Text = TaskValue.Status.ToString();
        }

        public void GetValueToUserControl()
        {
            label_PatchInput.Text = "Исходящяя директория:\n" + propertyStatusFJob._DirInput;
            label_PatchOutput.Text = "Директория назначения:\n" + propertyStatusFJob._DirOutput;
            label_CountFiles.Text = propertyStatusFJob._CountFiles.ToString();

            cts = new CancellationTokenSource();
            xtask = new Task(() => InitTaskStatus_Backup(cts.Token), cts.Token);

            label_Status.Text = TaskValue.Status.ToString();
        }
    }
}
