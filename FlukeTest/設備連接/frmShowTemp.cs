using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlukeTest.設備連接
{
    public partial class frmShowTemp : Form
    {
        public frmShowTemp(string FTemp, string FUnit)
        {
            InitializeComponent();
            this.Temp = FTemp;
            this.Unit = FUnit;

            lblTemp.Text = $"{Temp} {Unit}";
        }

        public string Temp { get; set; }
        public string Unit { get; set; }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
