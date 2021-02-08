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
    public partial class frmProduct : Form
    {
        public frmProduct()
        {
            InitializeComponent();
        }

        private void frmProduct_Load(object sender, EventArgs e)
        {
            RefreshProducts();
        }
        public void RefreshProducts()
        {
            productsDataContext db = new productsDataContext();
            productBindingSource.DataSource = db.Products;
        }

        private void newproduct_Click(object sender, EventArgs e)
        {
            frmProductAddModfy newform = new frmProductAddModfy();
            newform.isAdd = true;
            DialogResult result = newform.ShowDialog();
            if (result == DialogResult.OK)
            {
                RefreshProducts();
            }
        }

        private void update_Click(object sender, EventArgs e)
        {
            int rowNum = productDataGridView.CurrentCell.RowIndex; // index of the current row
            int prodCode = (int)productDataGridView["dataGridViewTextBoxColumn1", rowNum].Value; // Column for ProductCode
            Product currentproduct;
            using (productsDataContext dbContext = new productsDataContext())
            {
                currentproduct = (from p in dbContext.Products
                                  where p.ProductId == prodCode
                                  select p).Single();
            }
            frmProductAddModfy newform = new frmProductAddModfy();
            newform.isAdd = false;
            newform.currentProduct = currentproduct;
            DialogResult result = newform.ShowDialog();
            if (result == DialogResult.OK)
            {
                RefreshProducts();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
