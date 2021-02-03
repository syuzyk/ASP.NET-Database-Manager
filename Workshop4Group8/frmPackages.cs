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

namespace Workshop4Group8
{
    public partial class frmPackages : Form
    {
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
    }
}
