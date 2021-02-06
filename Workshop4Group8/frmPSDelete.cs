using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TravelExpertsData;

namespace Workshop4Group8
{
    public partial class frmPSDelete : Form
    {
        public frmPSDelete()
        {
            InitializeComponent();
        }

        public frmPS mainForm;

        private void frmPSDelete_Load(object sender, EventArgs e)
        {
            lblWarning.Text = mainForm.currentlyDGVSelectedProductName + " provided by " + mainForm.currentlyDGVSelectedSupplierName + "\n\nmust also be removed from the following packages:";
            
            dgvPPS.DataSource = PPSDB.GetPPSWithPS(mainForm.currentlyDGVSelectedProductName, mainForm.currentlyDGVSelectedSupplierName);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}
