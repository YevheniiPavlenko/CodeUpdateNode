using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NodUpdater
{
    public partial class Form2 : Form
    {
        static public string Caption;
        public System.Net.WebClient webClient_file = new WebClient();

        public Form2()
        {
            InitializeComponent();
        }
    }
}
