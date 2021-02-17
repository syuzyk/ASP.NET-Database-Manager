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
    public partial class frmPSDeleteUpdate : Form
    {
        //All code here written by Ricky.

        public frmPSDeleteUpdate()
        {
            InitializeComponent();
        }

        public frmPS mainFormPS;
        public frmPSAddModify mainFormPSAM;

        //Boolean value determining whether form will be used for update
        //or delete.
        public bool isDeleteAndNotUpdate;

        /// <summary>
        /// Load data and form appearance depending on whether we are deleting or updating.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmPSDelete_Load(object sender, EventArgs e)
        {
            if (isDeleteAndNotUpdate == true)
            {
                lblWarning.Text = mainFormPS.currentlyDGVSelectedProductName + " provided by " + mainFormPS.currentlyDGVSelectedSupplierName + "\n\nwill also be removed from the following packages:";
                dgvPPS.DataSource = PPSDB.GetPPSWithPS(mainFormPS.currentlyDGVSelectedProductName, mainFormPS.currentlyDGVSelectedSupplierName);
                lblDirection.Text = "Click 'Delete from this table AND all packages' to do so; otherwise click 'Cancel.";
                btnOK.Text = "Delete from this table AND all packages";
            }   
            else
            {
                lblWarning.Text = mainFormPSAM.originalProduct + " provided by " + mainFormPSAM.originalSupplier + "\n\nwill also be updated to " + mainFormPSAM.newlyPickedProduct + " provided by " + mainFormPSAM.newlyPickedSupplier + " in the following packages:";
                dgvPPS.DataSource = PPSDB.GetPPSWithPS(mainFormPSAM.originalProduct, mainFormPSAM.originalSupplier);
                lblDirection.Text = "Click 'Update in this table AND all packages' to do so; otherwise click 'Cancel.";
                btnOK.Text = "Update in this table AND all packages";
            }  
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
