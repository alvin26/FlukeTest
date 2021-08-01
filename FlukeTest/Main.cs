using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlukeTest
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void 添加設備配置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmConnection fm = new frmConnection();
            try
            {
                fm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, $"添加設備配置失敗:{ex.Message}{ex.InnerException}");
            }
            finally
            {
                fm.Close();
                fm = null;
            }
        }
    }
}
