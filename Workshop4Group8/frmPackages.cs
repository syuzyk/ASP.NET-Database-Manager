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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0 &&
                e.ColumnIndex == 0)
            {
                dgvPPS.Rows[e.RowIndex].Selected = true;
                DialogResult dialogresult = MessageBox.Show("Are you sure you wish to delete \n\n" + dgvPPS.SelectedCells[2].Value.ToString() + " provided by " + dgvPPS.SelectedCells[3].Value.ToString() + "\n\nfrom the package " + packageDataGridView.SelectedCells[1].Value.ToString() + "?", "Confirm delete", MessageBoxButtons.YesNo);
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
                if (result == DialogResult.OK)
                {
                    dgvPPS.DataSource = PPSDB.GetPPS(Convert.ToInt32(packageDataGridView[0, packageDataGridView.SelectedCells[0].RowIndex].Value));
                }
            }
        }

        private void packageDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            dgvPPS.DataSource = PPSDB.GetPPS(Convert.ToInt32(packageDataGridView[0, packageDataGridView.SelectedCells[0].RowIndex].Value));
        }

        private void btnAddPPS_Click(object sender, EventArgs e)
        {
            currentlySelectedPackageId = Convert.ToInt32(packageDataGridView.SelectedCells[0].Value); 
            currentlySelectedPackageName = packageDataGridView.SelectedCells[1].Value.ToString();
            currentlySelectedProductName = "";
            currentlySelectedSupplierName = "";
            frmPPSAddModify secondForm = new frmPPSAddModify();
            secondForm.mainPackageForm = this;
            DialogResult result = secondForm.ShowDialog();
            if (result == DialogResult.OK)
            {
                dgvPPS.DataSource = PPSDB.GetPPS(Convert.ToInt32(packageDataGridView[0, packageDataGridView.SelectedCells[0].RowIndex].Value));
            }
        }
    }
}
