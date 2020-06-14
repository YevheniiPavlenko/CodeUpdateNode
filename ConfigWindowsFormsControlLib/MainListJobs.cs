using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Runtime.CompilerServices;

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
         
        }

        public void Save(PropertyXElementJob propertyXElementJobSave)
        {
            List<PropertyXElementJob> PropertyXElementJobTemplate = new List<PropertyXElementJob>();

            foreach (PropertyXElementJob propertyXElementJobTemp in ProprtyXElementJobFMain)
            {
                if (propertyXElementJobTemp._Id == propertyXElementJobSave._Id) { PropertyXElementJobTemplate.Add(propertyXElementJobSave); }
                else  { PropertyXElementJobTemplate.Add(propertyXElementJobTemp); }
            }

            this.Items = PropertyXElementJobTemplate;
        }

        public void Remove(PropertyXElementJob propertyXElementJobRemove)
        {
            List<PropertyXElementJob> PropertyXElementJobTemplate = new List<PropertyXElementJob>();

            foreach (PropertyXElementJob propertyXElementJobTemp in ProprtyXElementJobFMain)
            {
                //if (propertyXElementJobTemp == propertyXElementJobRemove) { ProprtyXElementJobFMain.Remove(propertyXElementJobTemp); }
                if (propertyXElementJobTemp != propertyXElementJobRemove)
                {
                    PropertyXElementJobTemplate.Add(propertyXElementJobTemp);
                }
            }

            this.Items = PropertyXElementJobTemplate;
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

                this.Controls.Clear();

                int pointDrawPos = 10;

                GroupBox groupBoxTemplate;
                FlowLayoutPanel flowLayoutPanelTamplate  = new FlowLayoutPanel();
                Button cxbutton_Delete;
                Button cxbutton_Save;

                flowLayoutPanelTamplate.Location = this.Location;
                flowLayoutPanelTamplate.Size = this.Size;
                flowLayoutPanelTamplate.Dock = DockStyle.Fill;

                XElementJobForList elementJobForListTemplate = new XElementJobForList();
                foreach (PropertyXElementJob xProprtyXElementJobAttachControl in ProprtyXElementJobFMain)
                {
                    groupBoxTemplate = new GroupBox();
                    elementJobForListTemplate = new XElementJobForList();

                    elementJobForListTemplate.SetValue(xProprtyXElementJobAttachControl);
                    elementJobForListTemplate.Name = @"XElementJobForList_" + xProprtyXElementJobAttachControl._Id.ToString();

                    elementJobForListTemplate.Top = 40;
                    elementJobForListTemplate.Left = 10;

                    groupBoxTemplate.Name = @"groupBox_" + xProprtyXElementJobAttachControl._Id.ToString();
                    groupBoxTemplate.Width = elementJobForListTemplate.Size.Width + 20;
                    groupBoxTemplate.Height = elementJobForListTemplate.Size.Height + 60;
                    groupBoxTemplate.Text = "Задание № " + elementJobForListTemplate.Value._Id.ToString();
                    groupBoxTemplate.Top = pointDrawPos;
                    groupBoxTemplate.Left = 10;

                    cxbutton_Delete = new Button();
                    cxbutton_Delete.Name = "Button_" + xProprtyXElementJobAttachControl._Id.ToString();
                    cxbutton_Delete.Text = "Удалить задание";
                    cxbutton_Delete.Top = 15;
                    cxbutton_Delete.Size = new Size(120, 24);
                    cxbutton_Delete.Left = elementJobForListTemplate.Location.X + elementJobForListTemplate.Width - cxbutton_Delete.Width - 10 - elementJobForListTemplate.Margin.Right;
                    cxbutton_Delete.Click += Cxbutton_Delete_Click;

                    cxbutton_Save = new Button();
                    cxbutton_Save.Name = "Button_" + xProprtyXElementJobAttachControl._Id.ToString();
                    cxbutton_Save.Text = "Сохранить задание";
                    cxbutton_Save.Top = 15;
                    cxbutton_Save.Size = new Size(120, 24);
                    cxbutton_Save.Left = elementJobForListTemplate.Location.X + elementJobForListTemplate.Width - cxbutton_Save.Width*2 - 10*2 - elementJobForListTemplate.Margin.Right;
                    cxbutton_Save.Click += Cxbutton_Save_Click;

                    groupBoxTemplate.Controls.Add(cxbutton_Delete);
                    groupBoxTemplate.Controls.Add(cxbutton_Save);
                    groupBoxTemplate.Controls.Add(elementJobForListTemplate);

                    pointDrawPos += elementJobForListTemplate.Height + 20;

                    flowLayoutPanelTamplate.Controls.Add(groupBoxTemplate);
                }

                flowLayoutPanelTamplate.AutoScroll = true;

                this.Controls.Add(flowLayoutPanelTamplate);
            }
        }

        public void RefreshList() { 
        
        }

        private void Cxbutton_Save_Click(object sender, EventArgs e)
        {
            Control xcontrolTemplate;
            try { xcontrolTemplate = (Button)sender; }
            catch { return; }

            if (xcontrolTemplate.Parent.Controls["XElementJobForList_" + xcontrolTemplate.Name.Split('_')[1]] != null)
            {
                this.Save(((XElementJobForList)(xcontrolTemplate.Parent.Controls["XElementJobForList_" + xcontrolTemplate.Name.Split('_')[1]])).Value);
            }
        }

        private void Cxbutton_Delete_Click(object sender, EventArgs e)
        {
            Control xcontrolTemplate;
            try { xcontrolTemplate = (Button)sender; }
            catch { return; }

            if (xcontrolTemplate.Parent.Controls["XElementJobForList_" + xcontrolTemplate.Name.Split('_')[1]] != null)
            {
                this.Remove(((XElementJobForList)(xcontrolTemplate.Parent.Controls["XElementJobForList_" + xcontrolTemplate.Name.Split('_')[1]])).Value);
                xcontrolTemplate.Parent.Controls.Remove(xcontrolTemplate.Parent.Controls["XElementJobForList_" + xcontrolTemplate.Name.Split('_')[1]]);
            }

            //Form.ActiveForm.Text += '*';
            //Form.ActiveForm.Show();
           
        }
    }
}