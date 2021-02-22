using System;
using System.Windows.Forms;
using TravelExpertsData;

namespace Workshop4Group8
{
    //All code here written by Ricky.
    
    /// <summary>
    /// Form for modifying Products_Packages table.
    /// </summary>
    public partial class frmPSAddModify : Form
    {
        public frmPSAddModify()
        {
            InitializeComponent();
        }

        public frmPS mainForm;

        //Certain elements on this form differ depending on whether
        //user is adding a new product or modifying an existing product.
        //This bool indicates which action user is taking.
        bool isAddAndNotModify;

        //Some events conflict with the event 
        //"Supplier_SelectedIndexChanged". This bool is used to override
        //that event and prevent the program from crashing.
        bool overrideEventSupplier_SelectedIndexChanged = true;

        //When refreshing the combo box list, the most recently selected
        //supplier gets deleted. This variable retains it.
        string mostRecentlySelectedSupplier;

        //If we are updating a product/supplier combo, we may need to know
        //the original product/supplier selections and the new one we
        //are trying to update to.
        public string originalProduct;
        public string originalSupplier;
        public string newlyPickedProduct;
        public string newlyPickedSupplier;

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
        private void frmPSAddModify_Load(object sender, EventArgs e)
        {
            foreach (string product in ProductDB.GetAllProducts())
            {
                cmbProduct.Items.Add(product);
            }

            //Set form appearance, and update title lable with package name.
            cmbProduct.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSupplier.DropDownStyle = ComboBoxStyle.DropDownList;

            //If user tries to submit a duplicate record, a message will tell
            //the user, "STOP, YOU CANNOT SUBMIT THIS."
            //This message is not required at Form_Load.
            lblGandalf.Visible = false;

            //If no product was selected when user launched this form dialog, 
            //then user is adding a product to the package.
            //If user is adding, clear the combo box selections.
            if (mainForm.currentlyDGVSelectedProductName == "" && mainForm.currentlyDGVSelectedSupplierName == "")
            {
                isAddAndNotModify = true;
                btnSubmit.Text = "Add";
                cmbProduct.SelectedIndex = 0;
                cmbSupplier.Enabled = false;
            }

            //If user is modifying, have the combo boxes select the product and supplier
            //user had selected in the Packages form.
            else
            {
                isAddAndNotModify = false;
                btnSubmit.Text = "Update";
                originalProduct = mainForm.currentlyDGVSelectedProductName;
                newlyPickedProduct = mainForm.currentlyDGVSelectedProductName;
                originalSupplier = mainForm.currentlyDGVSelectedSupplierName;
                newlyPickedSupplier = mainForm.currentlyDGVSelectedSupplierName;

                cmbProduct.SelectedItem = mainForm.currentlyDGVSelectedProductName;

                //The currently selected Supplier will probably be in the middle of the combo
                //box list. When user opens the list on the combo box, it will scroll down
                //the list to where the currently selected Supplier is. I do not want it
                //to scroll down. I want user to see the list from the beginning. Therefore, 
                //add the currently selected Supplier to the list before adding the complete
                //list of suppliers. That way, it will be at the top of the combo box list,
                //and the list will not have to scroll down to it.
                cmbSupplier.Items.Clear();
                cmbSupplier.Items.Add(mainForm.currentlyDGVSelectedSupplierName);
                cmbSupplier.Items.Add("");

                foreach (string supplier in SupplierDB.GetUnlinkedSuppliers(mainForm.currentlyDGVSelectedProductName))
                {
                    cmbSupplier.Items.Add(supplier);
                }

                overrideEventSupplier_SelectedIndexChanged = true;
                cmbSupplier.SelectedIndex = 0;

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
            if (cmbProduct.SelectedItem == null || cmbProduct.SelectedItem.ToString() == "")
            {
                cmbSupplier.Items.Clear(); 
                cmbSupplier.Enabled = false;
                isReadyForSubmission();
            }
            else
            {
                newlyPickedProduct = cmbProduct.SelectedItem.ToString();

                cmbSupplier.Enabled = true;
                cmbSupplier.Items.Clear();
                foreach (string supplier in SupplierDB.GetUnlinkedSuppliers(cmbProduct.SelectedItem.ToString()))
                {
                    cmbSupplier.Items.Add(supplier);
                }
                overrideEventSupplier_SelectedIndexChanged = true;
                cmbSupplier.SelectedIndex = 0;
                btnSubmit.Enabled = false;
                lblGandalf.Visible = false;
            }
        }

        /// <summary>
        /// Whenever user selects a Supplier, check if user is allowed to submit.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbSupplier_SelectedIndexChanged(object sender, EventArgs e)
        {
            //If we should not over-ride this event, run this code.
            if (overrideEventSupplier_SelectedIndexChanged == false)
            {
                if (cmbSupplier.SelectedItem != null && cmbSupplier.SelectedItem.ToString() != "")
                {
                    newlyPickedSupplier = cmbSupplier.SelectedItem.ToString(); 
                    mostRecentlySelectedSupplier = cmbSupplier.SelectedItem.ToString();
                    cmbSupplier.Items.Clear();
                    cmbSupplier.Items.Add(mostRecentlySelectedSupplier);
                }
                else
                {
                    mostRecentlySelectedSupplier = "";
                    cmbSupplier.Items.Clear();
                }

                foreach (string supplier in SupplierDB.GetUnlinkedSuppliers(cmbProduct.SelectedItem.ToString()))
                {
                    cmbSupplier.Items.Add(supplier);
                }

                overrideEventSupplier_SelectedIndexChanged = true;
                cmbSupplier.SelectedIndex = 0;

                isReadyForSubmission();
            }

            //If this event was over-ridden, don't over-ride it next time.
            else
                overrideEventSupplier_SelectedIndexChanged = false;
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
            else if (PSDB.recordAlreadyExistsInPS(cmbProduct.SelectedItem.ToString(), cmbSupplier.SelectedItem.ToString()) == true)
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
            //If user is adding a record, customize message box text accordingly.
            if (isAddAndNotModify == true)
            {
                if (PSDB.addToPSThenConfirmSuccess(cmbProduct.SelectedItem.ToString(), cmbSupplier.SelectedItem.ToString()) == true)
                        MessageBox.Show("You have added \n\n" + cmbProduct.SelectedItem.ToString() + " provided by " + cmbSupplier.SelectedItem.ToString() +
                        ".", "Success!");
                else
                    MessageBox.Show("Database error, please contact your administrator");

                DialogResult = DialogResult.OK;
            }

            //Otherwise, user is modifying a record.
            else
            {
                //Check how many records in Packages_Products_Suppliers also contain this combination
                //of product and supplier.
                //If none, simply ask if user wishes to delete.
                if (PPSDB.GetPPSWithPS(originalProduct, originalSupplier).Count == 0)
                {
                    if (PSDB.UpdatePSThenConfirmSuccess(mainForm.currentlyDGVSelectedProductName,
                      mainForm.currentlyDGVSelectedSupplierName, cmbProduct.SelectedItem.ToString(), cmbSupplier.SelectedItem.ToString()) == true)
                        MessageBox.Show(mainForm.currentlyDGVSelectedProductName + " provided by " + mainForm.currentlyDGVSelectedSupplierName +
                            "\n\nhas been successfully updated to \n\n" +
                            cmbProduct.SelectedItem.ToString() + " provided by " + cmbSupplier.SelectedItem.ToString() + ".", "Success!");
                    else
                        MessageBox.Show("Database error, please contact your administrator");

                    DialogResult = DialogResult.OK;
                }
                else
                {
                    frmPSDeleteUpdate secondForm = new frmPSDeleteUpdate();
                    secondForm.mainFormPSAM = this;
                    secondForm.isDeleteAndNotUpdate = false;
                    DialogResult result = secondForm.ShowDialog();

                    if (result == DialogResult.OK)
                    {
                        if (PSDB.addToPSThenConfirmSuccess(cmbProduct.SelectedItem.ToString(), cmbSupplier.SelectedItem.ToString()) != true)
                            MessageBox.Show("Database error, please contact your administrator");
                        else
                        {
                            if (PPSDB.UpdatePPSWithPSThenConfirmSuccess(originalProduct, originalSupplier, newlyPickedProduct, newlyPickedSupplier) != true)
                                MessageBox.Show("Someone has deleted or changed that product(s) in the package(s).", "Concurrency error");
                            else
                            {
                                if (PSDB.DeletePSThenConfirm(mainForm.currentlyDGVSelectedProductName, mainForm.currentlyDGVSelectedSupplierName) !=true)
                                    MessageBox.Show("Database error, please contact your administrator"); 
                                else
                                    MessageBox.Show(mainForm.currentlyDGVSelectedProductName + " provided by " + mainForm.currentlyDGVSelectedSupplierName +
                                        "\n\nhas been successfully updated to \n\n" +
                                        cmbProduct.SelectedItem.ToString() + " provided by " + cmbSupplier.SelectedItem.ToString() + ".", "Success!");
                            }
                        }
                        DialogResult = DialogResult.OK;
                    }
                }     
            }
        }
    }
}
