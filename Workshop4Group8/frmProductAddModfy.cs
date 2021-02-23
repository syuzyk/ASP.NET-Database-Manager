using System;
using System.Linq;
using System.Windows.Forms;
//Dhaval wrote this code
namespace Workshop4Group8
{
    public partial class frmProductAddModfy : Form
    {
        public bool isAdd;              // main form sets it
        public Product currentProduct;  // main form sets it
        public frmProductAddModfy()
        {
            InitializeComponent();
        }

        private void frmProductAddModfy_Load(object sender, EventArgs e)
        {
            if (!isAdd)
            {
                DisplayCurrentProduct();
            }
            else
            {
                productID.Visible = false;
                productIdTextBox.Visible = false;
                
            }
        }
        private void DisplayCurrentProduct()
        {
            productIdTextBox.Text = Convert.ToString(currentProduct.ProductId);
            prodNameTextBox.Text = currentProduct.ProdName;
        }

        private void save_Click(object sender, EventArgs e)
        {

            if (isAdd)
            {
                if (Validator.IsPresent(prodNameTextBox) == true)
                {
                    Product newProduct = new Product // create product using provided data
                    {
                        ProdName = prodNameTextBox.Text
                    };
                    using (productsDataContext db = new productsDataContext())
                    {
                        try
                        {
                            // insert through data context object from the main form
                            db.Products.InsertOnSubmit(newProduct);
                            db.SubmitChanges(); // submit to the database
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(prodNameTextBox.Text + " is already there");
                        }
                    }
                    DialogResult = DialogResult.OK;
                }

            }
            else
            {
                if (Validator.IsPresent(prodNameTextBox) == true)
                {
                    using (productsDataContext dbContext = new productsDataContext())
                    {
                        // get the product with id from the current text box
                        Product prod = dbContext.Products.Single(p => p.ProductId == currentProduct.ProductId);

                        if (prod != null)
                        {
                            // make changes by copying values from text boxes
                            prod.ProdName = prodNameTextBox.Text;
                            try
                            {
                                // submit changes 
                                dbContext.SubmitChanges();
                                DialogResult = DialogResult.OK;
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.ToString());
                            }
                        }
                    }
                }
            }
        }
        private void exit_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
