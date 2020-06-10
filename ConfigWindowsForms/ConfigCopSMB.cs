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
            ConfigSMB.CreateConfigSMBXML();
        }
    }
}
