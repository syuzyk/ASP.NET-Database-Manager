using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Workshop4Group8
{
    public partial class frmSuppliersAddModify : Form
    {
        public bool isModify;
        public frmSuppliers supplierForm;
        public Supplier currentSupplier;
        public frmSuppliersAddModify()
        {
            InitializeComponent();
        }

        //On click of cancel button, closes the form ~ TS
        private void btnCancelSuppliers_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        //On click of save button it creates a new supplier based on the input provided ~ TS
        private void btnSaveSuppliers_Click(object sender, EventArgs e)
        {
            
            if(!isModify) // If add supplier ~ TS
            {
                if (Validator.IsPresent(supNameTextBox) == true) //If the supplier name is not empty ~ TS
                {
                    Supplier newSupp = new Supplier
                    {
                        SupName = supNameTextBox.Text
                    };
                    using (SuppliersDataContext dbContext = new SuppliersDataContext())
                    {
                        supplierForm.db.Suppliers.InsertOnSubmit(newSupp);
                        supplierForm.db.SubmitChanges();
                    }
                    DialogResult = DialogResult.OK;
                }
            }
            else // Is modify ~ TS
            {
                using(SuppliersDataContext dbContext = new SuppliersDataContext())
                {
                    Supplier supp = dbContext.Suppliers.Single(p => p.SupplierId == Convert.ToInt32(supplierIdTextBox.Text));
                    if(supp != null)
                    {
                        supp.SupName = supNameTextBox.Text;
                        dbContext.SubmitChanges();
                        DialogResult = DialogResult.OK;
                    }
                }
            }
        }

        private void frmSuppliersAddModify_Load(object sender, EventArgs e)
        {
            //If the action is modify, changes the form to fit the correct view ~ TS
            if(isModify)
            {
                DisplayCurrentSupplier();
                supplierIdTextBox.Enabled = false;
                supplierIdTextBox.Visible = true;
                supNameTextBox.Focus();  
            }
            else //Is add supplier, changes the form to fit the correct view ~ TS
            {
                supplierIdTextBox.Visible = false;
                lblSuppID.Visible = false;
                supNameTextBox.Location = new Point(118,24);
                supNameLabel.Location = new Point(12, 27);
                btnSaveSuppliers.Location = new Point(189, 64);
                btnCancelSuppliers.Location = new Point(302, 64);
                this.Size = new Size(419, 150);
                supplierIdTextBox.Focus();
            }
        }

        //Displays current supplier ~ TS
        private void DisplayCurrentSupplier()
        {
            supplierIdTextBox.Text = Convert.ToString(currentSupplier.SupplierId);
            supNameTextBox.Text = currentSupplier.SupName;
        }
    }
}
