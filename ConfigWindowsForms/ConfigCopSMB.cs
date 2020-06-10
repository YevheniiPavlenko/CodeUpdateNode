using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ConfigClassLib;

namespace ConfigWindowsForms
{
    public partial class ConfigCopSMB : Form
    {
        public ConfigCopSMB()
        {
            InitializeComponent();
        }

        private void ConfigCopSMB_Load(object sender, EventArgs e)
        {
            //ConfigSMB.CreateConfigSMBXML();

            //ConfigSMB.AddJobsForConfigSMBXML(@"C:\Users\Yevgenii.Pavlenko\source", @"C:\Users");
            //ConfigSMB.AddJobsForConfigSMBXML(@"C:\Users\Yevgenii.Pavlenko\source\repos\NodUpdater\ConfigWindowsForms\bin\Debug", @"C:\Users\Yevgenii.Pavlenko\source\repos\NodUpdater\ConfigWindowsForms\bin");

            //ConfigSMB.AddJobsForConfigSMBXML(@"C:\Users\Yevgenii.Pavlenko\source", @"C:\Users");

            //ConfigSMB.AddJobsForConfigSMBXML(@"C:\Users\Yevgenii.Pavlenko\source\repos\NodUpdater", @"C:\Users\Yevgenii.Pavlenko\source\repos");
            //ConfigSMB.RemoveJobsForConfigSMBXML(0);
            //ConfigSMB.RemoveJobsForConfigSMBXML(1);
            //ConfigSMB.RemoveJobsForConfigSMBXML(3);
            //List<int> xlist = new List<int> { 0, 1, 4, 6};
            //ConfigSMB.RemoveListJobsForConfigSMBXML(xlist, false);

            //ConfigSMB.RemoveJobsForConfigSMBXML(0);

            ConfigSMB.RemoveAllJobsForConfigSMBXML();
            //ConfigSMB.AddJobsForConfigSMBXML(@"C:\Users\Yevgenii.Pavlenko\source\repos\NodUpdater", @"C:\Users\Yevgenii.Pavlenko\source\repoiks", true);


        }
    }
}
