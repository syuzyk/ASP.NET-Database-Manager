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
        
        //Certain elements on this form differ depending on whether
        //user is adding a new product or modifying an existing product.
        //This bool indicates which action user is taking.
        bool isAddAndNotModify;

        //Events during Form_Load conflict with the event 
        //"Product_SelectedInexChanged". This bool is used to override
        //that event and prevent the program from crashing.
        bool overrideEventProduct_SelectedIndexChanged = true;

        /// <summary>
        /// Cancel button will close the form dialog.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        /// <summary>
        /// If user is adding a product, the dropdowns should be blank.
        /// If user is modifying a product, the dropdowns should reflect
        /// the product user is modifying.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmPPSAddModify_Load(object sender, EventArgs e)
        {
            foreach (string product in ProductDB.GetProducts())
            {
                cmbProduct.Items.Add(product);
            }

            //Set form appearance, and update title lable with package name.
            cmbProduct.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSupplier.DropDownStyle = ComboBoxStyle.DropDownList;
            lblPackageName.Text = "Package: " + mainPackageForm.currentlySelectedPackageName;
            
            //If user tries to submit a duplicate record, a message will tell
            //the user, "STOP, YOU CANNOT SUBMIT THIS."
            //This message is not required at Form_Load.
            lblGandalf.Visible = false;
            
            //If no product was selected when user launched this form dialog, 
            //then user is adding a product to the package.
            //If user is adding, clear the combo box selections.
            if (mainPackageForm.currentlySelectedProductName == "" && mainPackageForm.currentlySelectedSupplierName == "")
            {
                isAddAndNotModify = true;
                btnSubmit.Text = "Add";
                cmbProduct.SelectedIndex = 0;
                cmbSupplier.Enabled = false;
            }
            
            //If user is modifying, have the combo boxes seslect the product and supplier
            //user had selected in the Packages form.
            else
            {
                isAddAndNotModify = false;
                btnSubmit.Text = "Update";
                
                cmbProduct.SelectedItem = mainPackageForm.currentlySelectedProductName;
                
                //The currently selected Supplier will probably be in the middle of the combo
                //box list. When user opens the list on the combo box, it will scroll down
                //the list to where the currently selected Supplier is. I do not want it
                //to scroll down. I want user to see the list from the beginning. Therefore, 
                //add the currently selected Supplier to the list before adding the complete
                //list of suppliers. That way, it will be at the top of the combo box list,
                //and the list will not have to scroll down to it.
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

        /// <summary>
        /// Whenever user selects a product from the products list,
        /// - determine whether Submit button should be enabled.
        /// - update the suppliers list to customize it for selected product
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            //If this event is not being over-ridden, run it.
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
            
            //After this event was over-ridden once during Form_Load, do
            //not over-ride it again.
            else
                overrideEventProduct_SelectedIndexChanged = false;
        }

        /// <summary>
        /// Whenever user selects a Supplier, check if user is allowed to submit.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbSupplier_SelectedIndexChanged(object sender, EventArgs e)
        {
            isReadyForSubmission();
        }

        /// <summary>
        /// Do not allow user to add/update if:
        /// - user has not picked a product
        /// - user has not picked a supplier
        /// - the product/supplier the user picked already exists in this package.
        /// </summary>
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
            
            //Check if user's selection already exists in this package.
            //If so, prevent submission and display message.
            else if (PPSDB.recordAlreadyExistsInPPS(mainPackageForm.currentlySelectedPackageId, 
                cmbProduct.SelectedItem.ToString(), cmbSupplier.SelectedItem.ToString()) == true)
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

        /// <summary>
        /// Any combination of product and supplier must exist in the Products_Suppliers
        /// table before it can be added to the Packages_Products_Suppliers table. 
        /// Therefore, when user clicks Submit button, first check if user's selection exists 
        /// in Products_Suppliers
        /// - if yes, then add it to Packages_Products_Suppliers
        /// - if not, add it to Products_Suppliers first, then add to Packages_Products_Suppliers
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            //If user's selection does not exist in Products_Suppliers, inform user of this
            //and confirm whether they still wish to proceed.
            if (PSDB.recordExistsInPS(cmbProduct.SelectedItem.ToString(), cmbSupplier.SelectedItem.ToString()) == false)
            {
                DialogResult dialogresult = MessageBox.Show("Are you sure that " + cmbProduct.SelectedItem.ToString() + " is being provided by " + 
                    cmbSupplier.SelectedItem.ToString() + "? \n\nThis information is not in our database.", "Confirm information", MessageBoxButtons.YesNo);
                if (dialogresult == DialogResult.Yes)
                {
                    if (PSDB.addToPSThenConfirmSuccess(cmbProduct.SelectedItem.ToString(), cmbSupplier.SelectedItem.ToString()) != true)
                        MessageBox.Show("Database error, please contact your administrator");
                }
            }

            //If user is adding a record, customize message box text accordingly.
            if (isAddAndNotModify == true)
            {
                if (PPSDB.addToPPSThenConfirmSuccess(mainPackageForm.currentlySelectedPackageId, cmbProduct.SelectedItem.ToString(), 
                    cmbSupplier.SelectedItem.ToString()) == true)
                    MessageBox.Show("You have added \n\n" + cmbProduct.SelectedItem.ToString() + " provided by " + cmbSupplier.SelectedItem.ToString() + 
                        "\n\nto the package " + mainPackageForm.currentlySelectedPackageName + ".", "Success!");
                else
                    MessageBox.Show("Database error, please contact your administrator");

                DialogResult = DialogResult.OK;
            }

            //Otherwise, user is modifying a record, so customize message box text accordingly.
            else
            {
                if (PPSDB.UpdateOrderThenConfirmSuccess(mainPackageForm.currentlySelectedPackageId, mainPackageForm.currentlySelectedProductName, 
                    mainPackageForm.currentlySelectedSupplierName, cmbProduct.SelectedItem.ToString(), cmbSupplier.SelectedItem.ToString()) == true)
                    MessageBox.Show(mainPackageForm.currentlySelectedProductName + " provided by " + mainPackageForm.currentlySelectedSupplierName + 
                        "\n\nin the package " + mainPackageForm.currentlySelectedPackageName + " has been successfully updated to \n\n" + 
                        cmbProduct.SelectedItem.ToString() + " provided by " + cmbSupplier.SelectedItem.ToString() + ".", "Success!");
                else
                    MessageBox.Show("Database error, please contact your administrator");

                DialogResult = DialogResult.OK;
            }
        }
    }
}
