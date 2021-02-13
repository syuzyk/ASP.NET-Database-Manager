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
    //All code here written by Ricky.
    public partial class frmPS : Form
    {
        public frmPS()
        {
            InitializeComponent();
        }

        //On this form, users select rows in the DGV. When user goes 
        //to the Add/Modify form to edit products/suppliers, that form 
        //needs to know the information the user selected. That form can 
        //refer to this information through the following public global variables:
        public string currentlyDGVSelectedProductName;
        public string currentlyDGVSelectedSupplierName;
        public string productFilterCondition = "";
        public string supplierFilterCondition = "";

        /// <summary>
        /// When form loads, fill combo boxes and DGV with data from database.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmPS_Load(object sender, EventArgs e)
        {
            cmbProduct.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSupplier.DropDownStyle = ComboBoxStyle.DropDownList;

            ReloadPPSData();
        }

        private void ReloadPPSData()
        {
            dgvPS.DataSource = PSDB.GetPS("", "");

            foreach (string product in ProductDB.GetAllProducts())
            {
                cmbProduct.Items.Add(product);
            }

            foreach (string supplier in SupplierDB.GetAllSuppliers())
            {
                cmbSupplier.Items.Add(supplier);
            }
        }

        /// <summary>
        /// Suppliers button allows user to access Suppliers GUI.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSuppliers_Click(object sender, EventArgs e)
        {
            frmSuppliers newform = new frmSuppliers();
            DialogResult result = newform.ShowDialog();
            ReloadPPSData();
        }

        /// <summary>
        /// Products button allows user to access Products GUI.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnProducts_Click(object sender, EventArgs e)
        {
            frmProduct newform = new frmProduct();
            DialogResult result = newform.ShowDialog();
            ReloadPPSData();
        }

        /// <summary>
        /// Some cells in the products DGV contain buttons.
        /// This method contains method for the different buttons. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvPS_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            //If user clicks a button next to record in column index 0, which is the Delete button,
            //get ready to delete it.
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0 &&
                e.ColumnIndex == 0)
            {
                //Select record and confirm with user to delete it.
                dgvPS.Rows[e.RowIndex].Selected = true;
                currentlyDGVSelectedProductName = dgvPS.SelectedCells[2].Value.ToString();
                currentlyDGVSelectedSupplierName = dgvPS.SelectedCells[3].Value.ToString();

                //Check how many records in Packages_Products_Suppliers also contain this combination
                //of product and supplier.
                //If none, simply ask if user wishes to delete.
                if (PPSDB.GetPPSWithPS(dgvPS.SelectedCells[2].Value.ToString(), dgvPS.SelectedCells[3].Value.ToString()).Count == 0)
                {
                    DialogResult dialogresult = MessageBox.Show("Are you sure you wish to delete \n\n" + dgvPS.SelectedCells[2].Value.ToString() + " provided by " + dgvPS.SelectedCells[3].Value.ToString() + "?", "Confirm delete", MessageBoxButtons.YesNo);

                    //If user says yes, try to delete record.
                    if (dialogresult == DialogResult.Yes)
                    {
                        if (PSDB.DeletePSThenConfirm(dgvPS.SelectedCells[2].Value.ToString(), dgvPS.SelectedCells[3].Value.ToString()) != true)
                        {
                            MessageBox.Show("Someone has deleted or changed that record in the database. Click OK to refresh the data displayed here.", "Concurrency error");
                            dgvPS.DataSource = PSDB.GetPS(productFilterCondition, supplierFilterCondition);
                        }
                        else
                        {
                            MessageBox.Show("You have deleted \n\n" + dgvPS.SelectedCells[2].Value.ToString() + " provided by " + dgvPS.SelectedCells[3].Value.ToString() + ".", "Success!");
                            if (PSDB.GetPS(productFilterCondition, supplierFilterCondition).Count > 0)
                                dgvPS.DataSource = PSDB.GetPS(productFilterCondition, supplierFilterCondition);
                            else
                                dgvPS.DataSource = PSDB.GetPS("", "");
                        }
                    }
                }

                //If some packages already contain this product and supplier,
                //inform user that deleting this product and supplier will also 
                //delete it from those packages. Confirm if user wishes to proceed.
                else
                {
                    frmPSDelete secondForm = new frmPSDelete();
                    secondForm.mainForm = this;
                    DialogResult result = secondForm.ShowDialog();

                    if (result == DialogResult.OK)
                    {
                        if (PPSDB.DeletePPSWithPSThenConfirm(dgvPS.SelectedCells[2].Value.ToString(), dgvPS.SelectedCells[3].Value.ToString()) != true)
                            MessageBox.Show("Someone has deleted or changed that product(s) in the package(s).", "Concurrency error");
                        
                        if (PSDB.DeletePSThenConfirm(dgvPS.SelectedCells[2].Value.ToString(), dgvPS.SelectedCells[3].Value.ToString()) != true)
                        {
                            MessageBox.Show("Someone has deleted or changed that record in the database. Click OK to refresh the data displayed here.", "Concurrency error");
                            dgvPS.DataSource = PSDB.GetPS(productFilterCondition, supplierFilterCondition);
                        }
                        else
                        {
                            MessageBox.Show("You have deleted \n\n" + dgvPS.SelectedCells[2].Value.ToString() + " provided by " + dgvPS.SelectedCells[3].Value.ToString() + ".", "Success!");
                            if (PSDB.GetPS(productFilterCondition, supplierFilterCondition).Count > 0)
                                dgvPS.DataSource = PSDB.GetPS(productFilterCondition, supplierFilterCondition);
                            else
                                dgvPS.DataSource = PSDB.GetPS("", "");
                        }
                    }
                }
            }

            //If user clicks a button next to record in column index 1, which is the Update button,
            //update the global variables for the Add/Modify form dialog to access, 
            //then create Add/Modify form dialog.
            else if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0 &&
                e.ColumnIndex == 1)
            {
                dgvPS.Rows[e.RowIndex].Selected = true;
                
                currentlyDGVSelectedProductName = dgvPS.SelectedCells[2].Value.ToString();
                currentlyDGVSelectedSupplierName = dgvPS.SelectedCells[3].Value.ToString();
                frmPSAddModify secondForm = new frmPSAddModify();
                secondForm.mainForm = this;
                DialogResult result = secondForm.ShowDialog();

                //If update was successful, update products DGV.
                if (result == DialogResult.OK)
                {
                    dgvPS.DataSource = PSDB.GetPS(productFilterCondition, supplierFilterCondition);
                }
            }
        }

        /// <summary>
        /// When user clicks 'Connect product to supplier' button, update 
        /// the global variables for the Add/Modify form dialog to access, 
        /// then create Add/Modify form dialog.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddPS_Click(object sender, EventArgs e)
        {
            currentlyDGVSelectedProductName = "";
            currentlyDGVSelectedSupplierName = "";
            frmPSAddModify secondForm = new frmPSAddModify();
            secondForm.mainForm = this;
            DialogResult result = secondForm.ShowDialog();

            //If a product was succesfully added, update products DGV.
            if (result == DialogResult.OK)
            {
                dgvPS.DataSource = PSDB.GetPS(productFilterCondition, supplierFilterCondition);
            }
        }

        /// <summary>
        /// Whenever user selects a product, filter DGV contents.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbProduct_SelectedIndexChanged(object sender, EventArgs e)

        {
            if (cmbProduct.SelectedItem == null || cmbProduct.SelectedItem.ToString() == "")
            {
                productFilterCondition = "";
                supplierFilterCondition = "";
                cmbSupplier.Enabled = true;
                dgvPS.DataSource = PSDB.GetPS("", "");
            }
                
            else
            {
                productFilterCondition = " AND Products.ProdName = '" + cmbProduct.SelectedItem.ToString() + "'";
                supplierFilterCondition = "";

                if (PSDB.GetPS(productFilterCondition, supplierFilterCondition).Count == 0)
                {
                    cmbProduct.SelectedIndex = 0;
                    MessageBox.Show("No results found, please filter by a different selection.");
                    dgvPS.DataSource = PSDB.GetPS("", "");
                } 
                else
                {
                    cmbSupplier.Enabled = false;
                    dgvPS.DataSource = PSDB.GetPS(productFilterCondition, supplierFilterCondition);
                }
            }
        }

        /// <summary>
        /// Whenever user selects a supplier, filter DGV contents.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbSupplier_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSupplier.SelectedItem == null || cmbSupplier.SelectedItem.ToString() == "")
            {
                productFilterCondition = "";
                supplierFilterCondition = "";
                cmbProduct.Enabled = true;
                dgvPS.DataSource = PSDB.GetPS("", "");
            }

            else
            {
                supplierFilterCondition = " AND Suppliers.SupName = '" + cmbSupplier.SelectedItem.ToString() + "'";
                productFilterCondition = "";

                if (PSDB.GetPS(productFilterCondition, supplierFilterCondition).Count == 0)
                {
                    cmbSupplier.SelectedIndex = 0;
                    MessageBox.Show("No results found, please filter by a different selection.");
                    dgvPS.DataSource = PSDB.GetPS("", "");
                }
                else
                {
                    cmbProduct.Enabled = false;
                    dgvPS.DataSource = PSDB.GetPS(productFilterCondition, supplierFilterCondition);
                }
            }
        }

        /// <summary>
        /// Clear filter and show all data.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClearFilter_Click(object sender, EventArgs e)
        {
            cmbProduct.SelectedIndex = 0;
            cmbSupplier.SelectedIndex = 0;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
