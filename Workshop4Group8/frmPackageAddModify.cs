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
    public partial class frmPackageAddModify : Form
    {
        public bool isModify; // true if Modify and false if Add
        public Package currentPackage; // current package
        DateTime? tmpStartDate;
        DateTime? tmpEndDate;
        public frmPackageAddModify()
        {
            InitializeComponent();
        }

        private void btnAddCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmPackageAddModify_Load(object sender, EventArgs e)
        {
            if (isModify)
            {
                // display current package data
                pkgNameTextBox.Text = currentPackage.PkgName;
                packageIdTextBox.Text = currentPackage.PackageId.ToString();
                pkgDescRichTextBox.Text = currentPackage.PkgDesc.ToString();
                pkgBasePriceTextBox.Text = currentPackage.PkgBasePrice.ToString();
                pkgAgencyCommissionTextBox.Text = currentPackage.PkgAgencyCommission.ToString();
                if (currentPackage.PkgStartDate != null)
                {
                    // display current date in the date time picker
                    pkgStartDateDateTimePicker.Value = Convert.ToDateTime(currentPackage.PkgStartDate);
                }
                else
                {
                    // display empty text in date time picker when date is null
                    pkgStartDateDateTimePicker.CustomFormat = " ";
                    pkgStartDateDateTimePicker.Format = DateTimePickerFormat.Custom;
                }
                if (currentPackage.PkgEndDate != null)
                {
                    // display current date in the date time picker
                    pkgEndDateDateTimePicker.Value = Convert.ToDateTime(currentPackage.PkgEndDate);
                }
                else
                {
                    // display empty text in date time picker when date is null
                    pkgEndDateDateTimePicker.CustomFormat = " ";
                    pkgEndDateDateTimePicker.Format = DateTimePickerFormat.Custom;
                }
            }
        }

        private void btnAddOk_Click(object sender, EventArgs e)
        {
            using (DataClasses1DataContext dbContext = new DataClasses1DataContext())
            {
                Package pack = null;
                if (isModify)// update
                {
                    pack = dbContext.Packages.Single(p => p.PackageId ==
                                                     Convert.ToInt32(packageIdTextBox.Text));// lambda expression
                    pack.PkgName = (pkgNameTextBox.Text).ToString();
                    pack.PkgDesc = (pkgDescRichTextBox.Text).ToString();
                    pack.PkgBasePrice = Convert.ToDecimal(pkgBasePriceTextBox.Text);
                    pack.PkgAgencyCommission = Convert.ToDecimal(pkgAgencyCommissionTextBox.Text);
                    pack.PkgStartDate = tmpStartDate;
                    pack.PkgEndDate = tmpEndDate; // tmpDate set by date time picker (see two handlers below)
                }
                else // insert
                {
                    pack = new Package
                    {
                        PkgName = (pkgNameTextBox.Text).ToString(),
                        PkgDesc = (pkgDescRichTextBox.Text).ToString(),
                        PkgBasePrice = Convert.ToDecimal(pkgBasePriceTextBox.Text),
                        PkgAgencyCommission = Convert.ToDecimal(pkgAgencyCommissionTextBox.Text),
                        PkgStartDate = tmpStartDate,
                        PkgEndDate = tmpEndDate // tmpDate set by date time picker (see two handlers below)
                    };// object initializer syntax
                    dbContext.Packages.InsertOnSubmit(pack);
                }
                // validate that end date is not before start date
                if (pack.PkgEndDate != null && pack.PkgStartDate != null)
                {
                    if (pack.PkgEndDate < pack.PkgStartDate)
                    {
                        MessageBox.Show("Package cannot end before it started", "Data Error");
                        return; // do not submit changes if bad data
                    }
                }
                // validate that name is not null
                if (pack.PkgName is "")
                {
                    MessageBox.Show("Name cannot be empty", "Data Error");
                    return; // do not submit changes if bad data
                }
                // validate that description is not null
                if (pack.PkgDesc is "")
                {
                    MessageBox.Show("Description cannot be empty", "Data Error");
                    return; // do not submit changes if bad data
                }
                // validate that agency commission is not greater than base price
                if (pack.PkgAgencyCommission != null)
                {
                    if (pack.PkgBasePrice < pack.PkgAgencyCommission)
                    {
                        MessageBox.Show("Commission cannot be greater than package price", "Data Error");
                        return; // do not submit changes if bad data
                    }
                }
                dbContext.SubmitChanges();

                DialogResult = DialogResult.OK;
            }
        }
        private void pkgEndDateDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            if (pkgEndDateDateTimePicker.Value != null)
            {
                pkgEndDateDateTimePicker.Enabled = true;
                pkgEndDateDateTimePicker.Format = DateTimePickerFormat.Long;
                tmpEndDate = pkgEndDateDateTimePicker.Value;
            }
        }
        private void pkgEndDateDateTimePicker_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Delete)
            {
                pkgEndDateDateTimePicker.CustomFormat = " ";
                pkgEndDateDateTimePicker.Format = DateTimePickerFormat.Custom;
                tmpEndDate = null;
            }
        }
        private void pkgStartDateDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            if (pkgStartDateDateTimePicker.Value != null)
            {
                pkgStartDateDateTimePicker.Enabled = true;
                pkgStartDateDateTimePicker.Format = DateTimePickerFormat.Long;
                tmpStartDate = pkgStartDateDateTimePicker.Value;
            }
        }
        private void pkgStartDateDateTimePicker_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Delete)
            {
                pkgStartDateDateTimePicker.CustomFormat = " ";
                pkgStartDateDateTimePicker.Format = DateTimePickerFormat.Custom;
                tmpStartDate = null;
            }
        }
    }
}
