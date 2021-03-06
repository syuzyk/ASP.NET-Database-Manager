﻿using System;
using System.Windows.Forms;
using TravelExpertsData;

namespace Workshop4Group8
{
    //Ricky wrote this code
    public partial class frmGuardian : Form
    {
        bool isAuthenticated;

        public frmGuardian()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtPassword.Text) == false)
            {
                if (PasswordDB.Authenticate(txtPassword.Text))
                {
                    isAuthenticated = true;
                    DialogResult = DialogResult.OK;
                }
                    
                else
                    lblIncorrectPassword.Visible = true;
            }
        }

        private void frmGuardian_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (isAuthenticated == false)
                Application.Exit();
        }

        private void frmGuardian_Load(object sender, EventArgs e)
        {
            isAuthenticated = false;
            lblIncorrectPassword.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(lblHint.Text) == true)
            {
                lblHint.Text = "Hint: " + PasswordDB.GetHint();
                button2.Text = "Hide hint";
            }
            else
            {
                lblHint.Text = "";
                button2.Text = "Show hint";
            }
        }
    }
}
