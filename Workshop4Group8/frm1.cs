using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Workshop4Group8
{
    public partial class frm1 : Form
    {
        public frm1()
        {
            InitializeComponent();
        }

        private void Packages_Click(object sender, EventArgs e)
        {
            frmPackages newform = new frmPackages();
            DialogResult result = newform.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmPS newform = new frmPS();
            DialogResult result = newform.ShowDialog();
        }
    }
}
