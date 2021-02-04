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
    public partial class frmPPSAddModify : Form
    {
        public frmPPSAddModify()
        {
            InitializeComponent();
        }

        public frmPackages mainPackageForm;
        
        bool isAddAndNotModify;

        bool overrideEventProduct_SelectedIndexChanged = true;

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void frmPPSAddModify_Load(object sender, EventArgs e)
        {
            foreach (string product in ProductDB.GetProducts())
            {
                cmbProduct.Items.Add(product);
            }

            cmbProduct.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSupplier.DropDownStyle = ComboBoxStyle.DropDownList;
            lblPackageName.Text = "Package: " + mainPackageForm.currentlySelectedPackageName;
            if (mainPackageForm.currentlySelectedProductName == "" && mainPackageForm.currentlySelectedSupplierName == "")
            {
                isAddAndNotModify = true;
                lblInstructions.Visible = true;
                cmbProduct.SelectedIndex = 0;
                cmbSupplier.Enabled = false;
            }
            else
            {
                isAddAndNotModify = false;
                lblInstructions.Visible = false;
                
                cmbProduct.SelectedItem = mainPackageForm.currentlySelectedProductName;
                
                cmbSupplier.Items.Add("");
                cmbSupplier.Items.Add(mainPackageForm.currentlySelectedSupplierName);
                cmbSupplier.Items.Add("");

                foreach (string supplier in SupplierDB.GetSuppliers(mainPackageForm.currentlySelectedProductName))
                {
                    cmbSupplier.Items.Add(supplier);
                }
                
                cmbSupplier.SelectedItem = mainPackageForm.currentlySelectedSupplierName;

                lblGandalf.Visible = false;
            }
                
        }

        private void cmbProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (overrideEventProduct_SelectedIndexChanged == false)
            {
                if (cmbProduct.SelectedItem == null)
                {
                    cmbSupplier.Enabled = false;
                    isReadyForSubmission();
                }
                else if (cmbProduct.SelectedItem.ToString() == "")
                {
                    cmbSupplier.Enabled = false;
                    isReadyForSubmission();
                }
                else
                {
                    cmbSupplier.Enabled = true;
                    cmbSupplier.Items.Clear();
                    foreach (string supplier in SupplierDB.GetSuppliers(cmbProduct.SelectedItem.ToString()))
                    {
                        cmbSupplier.Items.Add(supplier);
                    }
                    cmbSupplier.SelectedIndex = 0;
                    btnSubmit.Enabled = false;
                    lblGandalf.Visible = false;
                }
            }
            else
                overrideEventProduct_SelectedIndexChanged = false;
        }

        private void cmbSupplier_SelectedIndexChanged(object sender, EventArgs e)
        {
            isReadyForSubmission();
        }

        private void isReadyForSubmission()
        {
            if (cmbProduct.SelectedItem == null || cmbSupplier.SelectedItem == null)
            {
                btnSubmit.Enabled = false;
                lblGandalf.Visible = false;
            }
            else if (cmbProduct.SelectedItem.ToString() == "" || cmbSupplier.SelectedItem.ToString() == "")
            {
                btnSubmit.Enabled = false;
                lblGandalf.Visible = false;
            }
            else if (cmbSupplier.SelectedItem.ToString() == "----------")
            {
                btnSubmit.Enabled = false;
                lblGandalf.Visible = false;
            }
            else if (PPSDB.recordAlreadyExistsInPPS(mainPackageForm.currentlySelectedPackageId, cmbProduct.SelectedItem.ToString(), cmbSupplier.SelectedItem.ToString()) == true)
            {
                btnSubmit.Enabled = false;
                lblGandalf.Visible = true;
            }
            else
            {
                btnSubmit.Enabled = true;
                lblGandalf.Visible = false;
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (PSDB.recordExistsInPS(cmbProduct.SelectedItem.ToString(), cmbSupplier.SelectedItem.ToString()) == false)
            {
                DialogResult dialogresult = MessageBox.Show("Are you sure that " + cmbProduct.SelectedItem.ToString() + " is being provided by " + cmbSupplier.SelectedItem.ToString() + "? \n\nThis information is not in our database.", "Confirm information", MessageBoxButtons.YesNo);
                if (dialogresult == DialogResult.Yes)
                {
                    if (PSDB.addToPSThenConfirmSuccess(cmbProduct.SelectedItem.ToString(), cmbSupplier.SelectedItem.ToString()) != true)
                        MessageBox.Show("Database error, please contact your administrator");
                }
            }

            if (isAddAndNotModify == true)
            {
                if (PPSDB.addToPPSThenConfirmSuccess(mainPackageForm.currentlySelectedPackageId, cmbProduct.SelectedItem.ToString(), cmbSupplier.SelectedItem.ToString()) == true)
                    MessageBox.Show("You have added \n\n" + cmbProduct.SelectedItem.ToString() + " provided by " + cmbSupplier.SelectedItem.ToString() + "\n\nto the package " + mainPackageForm.currentlySelectedPackageName + ".", "Success!");
                else
                    MessageBox.Show("Database error, please contact your administrator");

                DialogResult = DialogResult.OK;
            }
            else
            {
                if (PPSDB.UpdateOrderThenConfirmSuccess(mainPackageForm.currentlySelectedPackageId, mainPackageForm.currentlySelectedProductName, mainPackageForm.currentlySelectedSupplierName, cmbProduct.SelectedItem.ToString(), cmbSupplier.SelectedItem.ToString()) == true)
                    MessageBox.Show(mainPackageForm.currentlySelectedProductName + " provided by " + mainPackageForm.currentlySelectedSupplierName + "\n\nin the package " + mainPackageForm.currentlySelectedPackageName + " has been successfully updated to \n\n" + cmbProduct.SelectedItem.ToString() + " provided by " + cmbSupplier.SelectedItem.ToString() + ".", "Success!");
                else
                    MessageBox.Show("Database error, please contact your administrator");

                DialogResult = DialogResult.OK;
            }
                        
            //update/add to PPS
        }
    }
}
