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
    public partial class XElementJobForList : UserControl
    {
        public XElementJobForList()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Событие которое обрабатывает нажатие на кнопки buttonDir
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonDir_Click(object sender, EventArgs e)
        {
            Button buttonTemp;
            FolderBrowserDialog folderBrowserDialogTemp = new FolderBrowserDialog();
            
            try { buttonTemp = (Button)(sender); }
            catch { return; }

            DialogResult dialogresultTemp = folderBrowserDialogTemp.ShowDialog();

            switch (buttonTemp.Name)
            {
                case "buttonDirInput":
                    folderBrowserDialogTemp.Description = "Укажите каталог с которого нужно зделать Бекап";
                    break;

                case "buttonDirOutput":
                    folderBrowserDialogTemp.Description = "Укажите каталог в который нужно зделать Бекап";
                    break;
            }
            
            if (dialogresultTemp == DialogResult.OK)
            {
                switch (buttonTemp.Name)
                {
                    case "buttonDirInput":
                        if (cxPropertyXElementJob._DirOutput != folderBrowserDialogTemp.SelectedPath)
                        {
                            textBox_Value_DirInput.Text = folderBrowserDialogTemp.SelectedPath;
                            cxPropertyXElementJob._DirInput = folderBrowserDialogTemp.SelectedPath;
                        } else
                        {
                            MessageBox.Show("Пути не должны совпадать");
                        }
                        break;

                    case "buttonDirOutput":
                        if (cxPropertyXElementJob._DirInput != folderBrowserDialogTemp.SelectedPath)
                        {
                            textBox_Value_DirOutput.Text = folderBrowserDialogTemp.SelectedPath;
                            cxPropertyXElementJob._DirOutput = folderBrowserDialogTemp.SelectedPath;
                        }
                        else
                        {
                            MessageBox.Show("Пути не должны совпадать");
                        }
                        break;
                }
            }
        }
    }
}
