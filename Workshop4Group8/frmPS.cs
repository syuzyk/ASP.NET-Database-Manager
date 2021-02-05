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
    public partial class frmPS : Form
    {
        public frmPS()
        {
            InitializeComponent();
        }

        string currentlyDGVSelectedProductName;
        string currentlyDGVSelectedSupplierName;

        string productFilterCondition = "";
        string supplierFilterCondition = "";

        private void frmPS_Load(object sender, EventArgs e)
        {
            dgvPS.DataSource = PSDB.GetPS("", "");
            cmbProduct.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSupplier.DropDownStyle = ComboBoxStyle.DropDownList;

            foreach (string product in ProductDB.GetAllProducts())
            {
                cmbProduct.Items.Add(product);
            }

            foreach (string supplier in SupplierDB.GetAllSuppliers())
            {
                cmbSupplier.Items.Add(supplier);
            }
        }

        private void btnSuppliers_Click(object sender, EventArgs e)
        {
            frmSuppliers newform = new frmSuppliers();
            DialogResult result = newform.ShowDialog();
        }

        private void btnProducts_Click(object sender, EventArgs e)
        {
            frmProduct newform = new frmProduct();
            DialogResult result = newform.ShowDialog();
        }

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

        private void btnClearFilter_Click(object sender, EventArgs e)
        {
            cmbProduct.SelectedIndex = 0;
            cmbSupplier.SelectedIndex = 0;
        }

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
    }
}
