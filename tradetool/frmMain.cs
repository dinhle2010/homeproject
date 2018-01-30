using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tradetool
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void btnPolo_Click(object sender, EventArgs e)
        {
            new Form1().Show();
        }

        private void btnAuto_Click(object sender, EventArgs e)
        {
            new frmTradePro().Show();
        }
    }
}
