
namespace Workshop4Group8
{
    partial class frmNewPassword
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtOldPass = new System.Windows.Forms.TextBox();
            this.txtNewPass1 = new System.Windows.Forms.TextBox();
            this.txtNewPass2 = new System.Windows.Forms.TextBox();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.lblninetyDay = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtHint = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(78, 85);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(158, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Enter old password:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(69, 140);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(166, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Enter new password:";
            // 
            // txtOldPass
            // 
            this.txtOldPass.Location = new System.Drawing.Point(242, 80);
            this.txtOldPass.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtOldPass.Name = "txtOldPass";
            this.txtOldPass.PasswordChar = '*';
            this.txtOldPass.Size = new System.Drawing.Size(193, 26);
            this.txtOldPass.TabIndex = 0;
            this.txtOldPass.TextChanged += new System.EventHandler(this.txtOldPass_TextChanged);
            // 
            // txtNewPass1
            // 
            this.txtNewPass1.Location = new System.Drawing.Point(242, 135);
            this.txtNewPass1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtNewPass1.Name = "txtNewPass1";
            this.txtNewPass1.PasswordChar = '*';
            this.txtNewPass1.Size = new System.Drawing.Size(193, 26);
            this.txtNewPass1.TabIndex = 1;
            this.txtNewPass1.TextChanged += new System.EventHandler(this.txtNewPass1_TextChanged);
            // 
            // txtNewPass2
            // 
            this.txtNewPass2.Location = new System.Drawing.Point(242, 192);
            this.txtNewPass2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtNewPass2.Name = "txtNewPass2";
            this.txtNewPass2.PasswordChar = '*';
            this.txtNewPass2.Size = new System.Drawing.Size(193, 26);
            this.txtNewPass2.TabIndex = 2;
            this.txtNewPass2.TextChanged += new System.EventHandler(this.txtNewPass2_TextChanged);
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(161, 301);
            this.btnSubmit.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(181, 65);
            this.btnSubmit.TabIndex = 4;
            this.btnSubmit.Text = "Change password";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // lblninetyDay
            // 
            this.lblninetyDay.Location = new System.Drawing.Point(32, 12);
            this.lblninetyDay.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblninetyDay.Name = "lblninetyDay";
            this.lblninetyDay.Size = new System.Drawing.Size(405, 59);
            this.lblninetyDay.TabIndex = 3;
            this.lblninetyDay.Text = "You have not changed your password for over 90 days. Please change your password." +
    "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(68, 254);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(175, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "Enter a hint (optional):";
            // 
            // txtHint
            // 
            this.txtHint.Location = new System.Drawing.Point(242, 251);
            this.txtHint.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtHint.Name = "txtHint";
            this.txtHint.Size = new System.Drawing.Size(193, 26);
            this.txtHint.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 198);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(211, 20);
            this.label4.TabIndex = 0;
            this.label4.Text = "Enter new password again:";
            // 
            // frmNewPassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(232)))), ((int)(((byte)(229)))));
            this.ClientSize = new System.Drawing.Size(486, 389);
            this.Controls.Add(this.txtHint);
            this.Controls.Add(this.lblninetyDay);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.txtNewPass2);
            this.Controls.Add(this.txtNewPass1);
            this.Controls.Add(this.txtOldPass);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmNewPassword";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Change Password";
            this.Load += new System.EventHandler(this.frmNewPassword_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtOldPass;
        private System.Windows.Forms.TextBox txtNewPass1;
        private System.Windows.Forms.TextBox txtNewPass2;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Label lblninetyDay;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtHint;
        private System.Windows.Forms.Label label4;
    }
}