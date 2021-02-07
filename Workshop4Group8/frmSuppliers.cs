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
    public partial class frmSuppliers : Form
    {
        public SuppliersDataContext db = new SuppliersDataContext();
        
        public frmSuppliers()
        {
            InitializeComponent();
        }

        private void frmSuppliers_Load(object sender, EventArgs e)
        {
            supplierDataGridView.DataSource = db.Suppliers;
        }

        private void btnAddSuppliers_Click(object sender, EventArgs e)
        {
            frmSuppliersAddModify secondSupplierForm = new frmSuppliersAddModify();
            secondSupplierForm.supplierForm = this;
            DialogResult result = secondSupplierForm.ShowDialog();
            if(result == DialogResult.OK)
            {
                db = new SuppliersDataContext();
                supplierDataGridView.DataSource = db.Suppliers;
            }
        }

        private void btnModifySuppliers_Click(object sender, EventArgs e)
        {
            frmSuppliersAddModify secondSupplierForm = new frmSuppliersAddModify();
            int rowNum = supplierDataGridView.CurrentCell.RowIndex;
            int suppId = Convert.ToInt32(supplierDataGridView["dataGridViewTextBoxColumn1", rowNum].Value);
            Supplier currentSupplier;
            using(SuppliersDataContext dbContext = new SuppliersDataContext())
            {
                currentSupplier = (from s in dbContext.Suppliers
                                   where s.SupplierId == suppId
                                   select s).Single();
            }
            secondSupplierForm.isModify = true;
            secondSupplierForm.currentSupplier = currentSupplier;
            DialogResult result = secondSupplierForm.ShowDialog();
            if(result == DialogResult.OK || result == DialogResult.Retry)
            {
                db = new SuppliersDataContext();
                supplierDataGridView.DataSource = db.Suppliers;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
