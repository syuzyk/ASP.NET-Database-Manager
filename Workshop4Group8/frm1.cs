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

        private void product_Click(object sender, EventArgs e)
        {
            frmProduct newform = new frmProduct();
            DialogResult result = newform.ShowDialog();
        }

        private void Supplier_Click(object sender, EventArgs e)
        {
            frmSuppliers newform = new frmSuppliers();
            DialogResult result = newform.ShowDialog();
        }

        private void Packages_Click(object sender, EventArgs e)
        {
            frmPackages newform = new frmPackages();
            DialogResult result = newform.ShowDialog();
        }

        private void frm1_Load(object sender, EventArgs e)
        {

        }
    }
}
