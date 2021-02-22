using System;
using System.Windows.Forms;
using TravelExpertsData;

namespace Workshop4Group8
{
    //Ricky wrote this code
    public partial class frmNewPassword : Form
    {
        public frmNewPassword()
        {
            InitializeComponent();
        }

        bool checkOPC = false; //check: old password correct
        bool checkNPM = false; //check: new passwords match
        bool checkNPLE = false; //check: new passwords long enough
        bool checkNPU = false; //check: new passwords unique

        public bool ninetyDayUpdate = false;

        private void AllFieldsFilled()
        {
            if (!string.IsNullOrEmpty(txtOldPass.Text) && !string.IsNullOrEmpty(txtNewPass1.Text) && !string.IsNullOrEmpty(txtNewPass2.Text))
                btnSubmit.Enabled = true;
            else
                btnSubmit.Enabled = false;
        }

        private void frmNewPassword_Load(object sender, EventArgs e)
        {
            if (ninetyDayUpdate == true)
                lblninetyDay.Visible = true;
            else
                lblninetyDay.Visible = false;
            AllFieldsFilled();
        }

        private void txtOldPass_TextChanged(object sender, EventArgs e)
        {
            AllFieldsFilled();
        }

        private void txtNewPass1_TextChanged(object sender, EventArgs e)
        {
            AllFieldsFilled();
        }

        private void txtNewPass2_TextChanged(object sender, EventArgs e)
        {
            AllFieldsFilled();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (PasswordDB.Authenticate(txtOldPass.Text) == true)
            {
                checkOPC = true;

                if (txtNewPass1.Text.Equals(txtNewPass2.Text) == true)
                {
                    checkNPM = true;

                    if (PasswordDB.HasPasswordAlreadyBeenUsed(txtNewPass1.Text) == false)
                    {
                        checkNPU = true;

                        if (txtNewPass1.Text.Length >= 8)
                        {
                            checkNPLE = true;

                            string hint;

                            if (string.IsNullOrEmpty(txtHint.Text) == true)
                                hint = "******No hint available******";
                            else
                                hint = txtHint.Text;

                            UpdatePassword(txtNewPass1.Text, hint);
                        }
                        else
                        {
                            checkNPLE = false;
                            MessageBox.Show("Please enter a longer password.", "Error: password too short");
                        }
                    }
                    else
                    {
                        checkNPU = false;
                        MessageBox.Show("You have used this password in the past. Please try a different password.", "Error: already used password");
                    }
                }
                else
                {
                    checkNPM = false;
                    MessageBox.Show("New passwords do not match. Please re-enter and try again. System is case sensitive.", "Error: passwords don't match");
                }    
            }
            else
            {
                checkOPC = false;
                MessageBox.Show("Please enter your current password correctly. System is case sensitive.", "Error: current password");
            }
        }

        private void UpdatePassword(string newPassword, string hint)
        {
            DateTime today = DateTime.Today;

            Password password = new Password()
            {
                PasswordInput = newPassword,
                Hint = hint,
                UpdateDate = today
            };

            if (PasswordDB.UpdatePassword(password) == true)
            {
                MessageBox.Show("Password updated. You will be reminded in 90 days to update again", "Success!");
                DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Database error, please try again later or contact your adminstrator.", "Error");
                DialogResult = DialogResult.OK;
            }
                
        }
    }
}
