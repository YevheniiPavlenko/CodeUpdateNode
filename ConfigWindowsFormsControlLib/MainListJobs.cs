using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConfigWindowsFormsControlLib
{
    public partial class MainListJobs : UserControl
    {
        private List<PropertyXElementJob> ProprtyXElementJobFMain = new List<PropertyXElementJob>();

        public MainListJobs()
        {
            InitializeComponent();
        }

        private void MainListJobs_Load(object sender, EventArgs e)
        {
            //List<XElementJobForList> xElementJobForListControl;

            //foreach (ProprtyXElementJob xElementJobTemplate in getInfo_XElemetJobForListAll())
            //{

            //}
            ////xElementJobForListControl = 
            ////this.Controls.Add(new XElementJobForList());
        }
        public List<PropertyXElementJob> Items
        {
            get
            {
                return ProprtyXElementJobFMain;
            }
            set
            {
                ProprtyXElementJobFMain = value;

                //При присвоении нового списка ElementJobForLists, лучьше создать новый список элементов
                //и заполнить его.
                foreach (Control xControlTemplate in this.Controls.Find("XElementJobForList", true)) 
                { this.Controls.Remove(xControlTemplate); }

                //this.Controls.AddRange(xElementJobForListsFMain.ToArray());

                int pointDrawPos = 0;

                XElementJobForList elementJobForListTemplate = new XElementJobForList();
                foreach (PropertyXElementJob xProprtyXElementJobAttachControl in ProprtyXElementJobFMain)
                {
                    elementJobForListTemplate = new XElementJobForList();
                    elementJobForListTemplate.SetValue(xProprtyXElementJobAttachControl);
                    elementJobForListTemplate.Top = pointDrawPos;
                    pointDrawPos += elementJobForListTemplate.Height + 20;
                    
                    this.Controls.Add(elementJobForListTemplate);
                }
            }
        }
    }
}