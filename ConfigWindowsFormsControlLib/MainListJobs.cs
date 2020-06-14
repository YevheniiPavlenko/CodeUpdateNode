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
using AllClass;
using ConfigClassLib;

namespace ConfigWindowsFormsControlLib
{
    public partial class MainListJobs : UserControl
    {
        private List<PropertyXElementJob> ProprtyXElementJobFMain = new List<PropertyXElementJob>();

        public MainListJobs()
        {
            InitializeComponent();
        }

        #region Deleting
        /// <summary>
        /// Deleting
        /// </summary>
        //public void Remove(PropertyXElementJob propertyXElementJobRemove)
        //{
        //    List<PropertyXElementJob> PropertyXElementJobTemplate = new List<PropertyXElementJob>();

        //    foreach (PropertyXElementJob propertyXElementJobTemp in ProprtyXElementJobFMain)
        //    {
        //        //if (propertyXElementJobTemp == propertyXElementJobRemove) { ProprtyXElementJobFMain.Remove(propertyXElementJobTemp); }
        //        if (propertyXElementJobTemp != propertyXElementJobRemove)
        //        {
        //            PropertyXElementJobTemplate.Add(propertyXElementJobTemp);
        //        }
        //    }

        //    this.Items = PropertyXElementJobTemplate;
        //}

        /// <summary>
        /// Deleting
        /// </summary>
        //public void Save(PropertyXElementJob propertyXElementJobSave)
        //{
        //    List<PropertyXElementJob> PropertyXElementJobTemplate = new List<PropertyXElementJob>();

        //    foreach (PropertyXElementJob propertyXElementJobTemp in ProprtyXElementJobFMain)
        //    {
        //        if (propertyXElementJobTemp._Id == propertyXElementJobSave._Id) { PropertyXElementJobTemplate.Add(propertyXElementJobSave); }
        //        else { PropertyXElementJobTemplate.Add(propertyXElementJobTemp); }
        //    }

        //    this.Items = PropertyXElementJobTemplate;
        //}
        #endregion

        private void MainListJobs_Load(object sender, EventArgs e)
        {
         
        }

        /// <summary>
        /// Свойство которое передает иль получает список с элементами PropertyXElementJob
        /// </summary>
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

                GroupBox groupBoxTemplate;
                FlowLayoutPanel flowLayoutPanelTamplate = new FlowLayoutPanel();
                Button cxbutton_Delete;
                Button cxbutton_Save;

                int pointDrawPos = 10;

                Button cxbutton_NewRec = new Button();
                cxbutton_NewRec.Name = "newRec";
                cxbutton_NewRec.Text = "Добавить задание в конець задание";
                cxbutton_NewRec.Top = pointDrawPos + 15;
                cxbutton_NewRec.Size = new Size(200, 24);
                cxbutton_NewRec.Click += Cxbutton_NewRec_Click;

                flowLayoutPanelTamplate.Controls.Add(cxbutton_NewRec);

                pointDrawPos = 55;

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
                    cxbutton_Delete.Name = "ButtonDelete_" + xProprtyXElementJobAttachControl._Id.ToString();
                    cxbutton_Delete.Text = "Удалить задание";
                    cxbutton_Delete.Top = 15;
                    cxbutton_Delete.Size = new Size(120, 24);
                    cxbutton_Delete.Left = elementJobForListTemplate.Location.X + elementJobForListTemplate.Width - cxbutton_Delete.Width - 10 - elementJobForListTemplate.Margin.Right;
                    cxbutton_Delete.Click += Cxbutton_Delete_Click;

                    cxbutton_Save = new Button();
                    cxbutton_Save.Name = "ButtonSave_" + xProprtyXElementJobAttachControl._Id.ToString();
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

        /// <summary>
        /// Событие при нажатии на кнопку Cxbutton_NewRec
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cxbutton_NewRec_Click(object sender, EventArgs e)
        {
            PropertyXElementJob XpropertyXElementJobTemplate = new PropertyXElementJob();
            XpropertyXElementJobTemplate._Id = ProprtyXElementJobFMain.Count();
            XpropertyXElementJobTemplate._DirInput = "Введите наиманование директории";
            XpropertyXElementJobTemplate._DirOutput = "Введите наиманование директории";

            ProprtyXElementJobFMain.Add(new PropertyXElementJob());

            Items = ProprtyXElementJobFMain;
        }

        /// <summary>
        /// Событие при нажатии на кнопки с началм названий Cxbutton_Save
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cxbutton_Save_Click(object sender, EventArgs e)
        {
            Control xcontrolTemplate;
            try { xcontrolTemplate = (Button)sender; }
            catch { return; }

            if (xcontrolTemplate.Parent.Controls["XElementJobForList_" + xcontrolTemplate.Name.Split('_')[1]] != null)
            {
                List<PropertyXElementJob> PropertyXElementJobTemplate = new List<PropertyXElementJob>();

                foreach (PropertyXElementJob propertyXElementJobTemp in ProprtyXElementJobFMain)
                {
                    if (propertyXElementJobTemp._Id == ((XElementJobForList)(xcontrolTemplate.Parent.Controls["XElementJobForList_" + xcontrolTemplate.Name.Split('_')[1]])).Value._Id) 
                    { PropertyXElementJobTemplate.Add(((XElementJobForList)(xcontrolTemplate.Parent.Controls["XElementJobForList_" + xcontrolTemplate.Name.Split('_')[1]])).Value); }
                    else { PropertyXElementJobTemplate.Add(propertyXElementJobTemp); }
                }

                ConfigSMB.RemoveAllJobsForConfigSMBXML();
                ConfigSMB.AddJobsForConfigSMBXML_forPropertyXElementJob(PropertyXElementJobTemplate);

                Items = ConfigSMB.getInfo_XElemetJobForListAll();
            }
        }

        /// <summary>
        /// Событие при нажатии на кнопки с началм названий Cxbutton_Delete
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cxbutton_Delete_Click(object sender, EventArgs e)
        {
            Control xcontrolTemplate;
            try { xcontrolTemplate = (Button)sender; }
            catch { return; }

            if (xcontrolTemplate.Parent.Controls["XElementJobForList_" + xcontrolTemplate.Name.Split('_')[1]] != null)
            {
                ConfigSMB.RemoveJobsForConfigSMBXML(((XElementJobForList)(xcontrolTemplate.Parent.Controls["XElementJobForList_" + xcontrolTemplate.Name.Split('_')[1]])).Value._Id);
                Items = ConfigSMB.getInfo_XElemetJobForListAll();
            }
        }
    }
}