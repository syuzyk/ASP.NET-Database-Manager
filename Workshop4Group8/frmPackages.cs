using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TravelExpertsData;

namespace Workshop4Group8
{
    public partial class frmPackages : Form
    {
        //On this form, users select packages and products in DGV's.
        //When user goes to the Add/Modify form to edit products, that form
        //needs to know the information the user selected. That form can 
        //refer to this information through the following public global variables:
        public int currentlySelectedPackageId;
        public string currentlySelectedPackageName;
        public string currentlySelectedProductName;
        public string currentlySelectedSupplierName;


        public frmPackages()
        {
            InitializeComponent();
        }

        DataClasses1DataContext dbContext = new DataClasses1DataContext();
        private void frmPackages_Load(object sender, EventArgs e)
        {
            packageDataGridView.DataSource = (from p in dbContext.Packages
                                                 orderby p.PackageId
                                                 select p).ToList();
            dgvPPS.DataSource = PPSDB.GetPPS(Convert.ToInt32(packageDataGridView[0,0].Value));
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmPackageAddModify secondFrm = new frmPackageAddModify();

            DialogResult result = secondFrm.ShowDialog();
            using (DataClasses1DataContext dbContext = new DataClasses1DataContext())
            {
                if (result == DialogResult.OK)// successful Add
                {
                    packageDataGridView.DataSource = dbContext.Packages;// refresh grid
                }
            }
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            frmPackageAddModify secondFrm = new frmPackageAddModify();
            secondFrm.isModify = true;
            int rowNum = Convert.ToInt32(packageDataGridView.CurrentCell.RowIndex);
            int packId = Convert.ToInt32(packageDataGridView["dataGridViewTextBoxColumn1", rowNum].Value);
            using (DataClasses1DataContext dbContext = new DataClasses1DataContext())
            {
                secondFrm.currentPackage = (from p in dbContext.Packages
                                           where p.PackageId == packId
                                           select p).Single();
            }

            DialogResult result = secondFrm.ShowDialog();
            using (DataClasses1DataContext dbContext = new DataClasses1DataContext())
            {
                if (result == DialogResult.OK)// successful Modify
                {
                    packageDataGridView.DataSource = dbContext.Packages; // refresh grid
                }
            }
        }

        /// <summary>
        /// Some cells in the products DGV contain buttons.
        /// This method contains method for the different buttons. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            //If user clicks a button next to record in column index 0, which is the Delete button,
            //get ready to delete it.
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0 &&
                e.ColumnIndex == 0)
            {
                //Select record and confirm with user to delete it.
                dgvPPS.Rows[e.RowIndex].Selected = true;
                DialogResult dialogresult = MessageBox.Show("Are you sure you wish to delete \n\n" + dgvPPS.SelectedCells[2].Value.ToString() + " provided by " + dgvPPS.SelectedCells[3].Value.ToString() + "\n\nfrom the package " + packageDataGridView.SelectedCells[1].Value.ToString() + "?", "Confirm delete", MessageBoxButtons.YesNo);
                
                //If user says yes, try to delete record.
                if (dialogresult == DialogResult.Yes)
                {
                    if (PPSDB.DeletePPSThenConfirm(Convert.ToInt32(packageDataGridView.SelectedCells[0].Value), dgvPPS.SelectedCells[2].Value.ToString(), dgvPPS.SelectedCells[3].Value.ToString()) != true)
                    {
                        MessageBox.Show("Someone has deleted or changed that record in the database. Click OK to refresh the data displayed here.", "Concurrency error");
                        dgvPPS.DataSource = PPSDB.GetPPS(Convert.ToInt32(packageDataGridView[0, packageDataGridView.SelectedCells[0].RowIndex].Value));
                    }
                    else
                    {
                        MessageBox.Show("You have deleted \n\n" + dgvPPS.SelectedCells[2].Value.ToString() + " provided by " + dgvPPS.SelectedCells[3].Value.ToString() + "\n\nfrom the package " + packageDataGridView.SelectedCells[1].Value.ToString() + ".", "Success!");
                        dgvPPS.DataSource = PPSDB.GetPPS(Convert.ToInt32(packageDataGridView[0, packageDataGridView.SelectedCells[0].RowIndex].Value));
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
                dgvPPS.Rows[e.RowIndex].Selected = true;
                currentlySelectedPackageId = Convert.ToInt32(packageDataGridView.SelectedCells[0].Value);
                currentlySelectedPackageName = packageDataGridView.SelectedCells[1].Value.ToString();
                currentlySelectedProductName = dgvPPS.SelectedCells[2].Value.ToString();
                currentlySelectedSupplierName = dgvPPS.SelectedCells[3].Value.ToString();
                frmPPSAddModify secondForm = new frmPPSAddModify();
                secondForm.mainPackageForm = this;
                DialogResult result = secondForm.ShowDialog();
                
                //If update was successful, update products DGV.
                if (result == DialogResult.OK)
                {
                    dgvPPS.DataSource = PPSDB.GetPPS(Convert.ToInt32(packageDataGridView[0, packageDataGridView.SelectedCells[0].RowIndex].Value));
                }
            }
        }

        /// <summary>
        /// Whenever user selects a different package in the Packages DGV,
        /// the products DGV should show products for that DGV.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void packageDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            //If a row is selected, then refresh data.
            if (packageDataGridView.SelectedCells.Count != 0)
                dgvPPS.DataSource = PPSDB.GetPPS(Convert.ToInt32(packageDataGridView[0, packageDataGridView.SelectedCells[0].RowIndex].Value));
        }

        /// <summary>
        /// When user clicks 'Add product to package' button, update 
        /// the global variables for the Add/Modify form dialog to access, 
        /// then create Add/Modify form dialog.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddPPS_Click(object sender, EventArgs e)
        {
            currentlySelectedPackageId = Convert.ToInt32(packageDataGridView.SelectedCells[0].Value); 
            currentlySelectedPackageName = packageDataGridView.SelectedCells[1].Value.ToString();
            currentlySelectedProductName = "";
            currentlySelectedSupplierName = "";
            frmPPSAddModify secondForm = new frmPPSAddModify();
            secondForm.mainPackageForm = this;
            DialogResult result = secondForm.ShowDialog();
            
            //If a product was succesfully added, update products DGV.
            if (result == DialogResult.OK)
            {
                dgvPPS.DataSource = PPSDB.GetPPS(Convert.ToInt32(packageDataGridView[0, packageDataGridView.SelectedCells[0].RowIndex].Value));
            }
        }
    }
}
