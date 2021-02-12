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
        //All code here written by Ricky.

        public frmPSDelete()
        {
            InitializeComponent();
        }

        public frmPS mainForm;

        /// <summary>
        /// Load data indicating which packages contain the target package.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmPSDelete_Load(object sender, EventArgs e)
        {
            lblWarning.Text = mainForm.currentlyDGVSelectedProductName + " provided by " + mainForm.currentlyDGVSelectedSupplierName + "\n\nwill also be removed from the following packages:";
            
            dgvPPS.DataSource = PPSDB.GetPPSWithPS(mainForm.currentlyDGVSelectedProductName, mainForm.currentlyDGVSelectedSupplierName);
        }

        /// <summary>
        /// Dialog.Cancel to close form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        /// <summary>
        /// Sumbit dialog.OK to proceed with delete.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}
