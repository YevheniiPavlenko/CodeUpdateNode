using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AllClass;
using ConfigClassLib;

namespace ConfigWindowsForms
{
    public partial class ConfigCopSMB : Form
    {
        public ConfigCopSMB()
        {
            InitializeComponent();
            mainListJobs1.Items = ConfigSMB.getInfo_XElemetJobForListAll();
        }

        //public void RefreshConfigSMB(List<PropertyXElementJob> xListpropertyXElementJobsTemplate)
        //{
        //    ConfigSMB.RemoveAllJobsForConfigSMBXML();
        //    ConfigSMB.AddJobsForConfigSMBXML_forPropertyXElementJob(mainListJobs1.Items);
        //    mainListJobs1.Items = ConfigSMB.getInfo_XElemetJobForListAll();
        //}
    }
}
