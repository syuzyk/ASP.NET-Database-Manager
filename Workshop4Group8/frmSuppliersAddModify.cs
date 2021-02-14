using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        private void btnCancelSuppliers_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnSaveSuppliers_Click(object sender, EventArgs e)
        {
            
            if(!isModify) // If add supplier
            {
                if (Validator.IsPresent(supplierIdTextBox) == true && Validator.IsPresent(supNameTextBox) == true)
                {
                    Supplier newSupp = new Supplier
                    {
                        SupplierId = Convert.ToInt32(supplierIdTextBox.Text), //Replace with auto generated version and read only textbox
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
            else // Is modify
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
            if(isModify)
            {
                DisplayCurrentSupplier();
                supplierIdTextBox.Enabled = false;
                supNameTextBox.Focus();  
            }
            else
            {
                supplierIdTextBox.Enabled = true;
                supplierIdTextBox.Focus();
            }
        }

        private void DisplayCurrentSupplier()
        {
            supplierIdTextBox.Text = Convert.ToString(currentSupplier.SupplierId);
            supNameTextBox.Text = currentSupplier.SupName;
        }
    }
}
