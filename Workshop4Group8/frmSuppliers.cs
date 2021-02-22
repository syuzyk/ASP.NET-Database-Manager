using System;
using System.Data;
using System.Linq;
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

        //Connects the datagrid to the suppliers table in the database ~ TS
        private void frmSuppliers_Load(object sender, EventArgs e)
        {
            supplierDataGridView.DataSource = db.Suppliers;
            supplierDataGridView.Sort(dataGridViewTextBoxColumn1, 0);
        }

        //On click of add button, opens new form and connects back to the database ~ TS
        private void btnAddSuppliers_Click(object sender, EventArgs e)
        {
            frmSuppliersAddModify secondSupplierForm = new frmSuppliersAddModify();
            secondSupplierForm.supplierForm = this;
            DialogResult result = secondSupplierForm.ShowDialog();
            if(result == DialogResult.OK)
            {
                db = new SuppliersDataContext();
                supplierDataGridView.DataSource = db.Suppliers;
                supplierDataGridView.Sort(dataGridViewTextBoxColumn1, 0);
            }
        }

        //On click of modify button, opens a new form and grabs the information from the selected value in the datagrid view ~ TS
        private void btnModifySuppliers_Click(object sender, EventArgs e)
        {
            frmSuppliersAddModify secondSupplierForm = new frmSuppliersAddModify();
            int rowNum = supplierDataGridView.CurrentCell.RowIndex;
            int suppId = Convert.ToInt32(supplierDataGridView["dataGridViewTextBoxColumn1", rowNum].Value);
            Supplier currentSupplier;

            //Grabs the supplier based on the selected supplierID ~ TS
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
                supplierDataGridView.Sort(dataGridViewTextBoxColumn1, 0);
            }
        }

        //On click of cancel button, closes the form ~ TS
        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
