﻿
namespace Workshop4Group8
{
    partial class frmSuppliersAddModify
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label supNameLabel;
            System.Windows.Forms.Label supplierIdLabel;
            this.supNameTextBox = new System.Windows.Forms.TextBox();
            this.supplierBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.supplierIdTextBox = new System.Windows.Forms.TextBox();
            this.btnSaveSuppliers = new System.Windows.Forms.Button();
            this.btnCancelSuppliers = new System.Windows.Forms.Button();
            supNameLabel = new System.Windows.Forms.Label();
            supplierIdLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.supplierBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // supNameLabel
            // 
            supNameLabel.AutoSize = true;
            supNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            supNameLabel.Location = new System.Drawing.Point(12, 67);
            supNameLabel.Name = "supNameLabel";
            supNameLabel.Size = new System.Drawing.Size(101, 16);
            supNameLabel.TabIndex = 1;
            supNameLabel.Text = "Supplier Name:";
            // 
            // supplierIdLabel
            // 
            supplierIdLabel.AutoSize = true;
            supplierIdLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            supplierIdLabel.Location = new System.Drawing.Point(12, 27);
            supplierIdLabel.Name = "supplierIdLabel";
            supplierIdLabel.Size = new System.Drawing.Size(75, 16);
            supplierIdLabel.TabIndex = 3;
            supplierIdLabel.Text = "Supplier Id:";
            // 
            // supNameTextBox
            // 
            this.supNameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.supplierBindingSource, "SupName", true));
            this.supNameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.supNameTextBox.Location = new System.Drawing.Point(118, 64);
            this.supNameTextBox.Name = "supNameTextBox";
            this.supNameTextBox.Size = new System.Drawing.Size(266, 22);
            this.supNameTextBox.TabIndex = 1;
            this.supNameTextBox.Tag = "Supplier Name";
            // 
            // supplierBindingSource
            // 
            this.supplierBindingSource.DataSource = typeof(Workshop4Group8.Supplier);
            // 
            // supplierIdTextBox
            // 
            this.supplierIdTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.supplierBindingSource, "SupplierId", true));
            this.supplierIdTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.supplierIdTextBox.Location = new System.Drawing.Point(118, 24);
            this.supplierIdTextBox.Name = "supplierIdTextBox";
            this.supplierIdTextBox.Size = new System.Drawing.Size(266, 22);
            this.supplierIdTextBox.TabIndex = 0;
            this.supplierIdTextBox.Tag = "Supplier Id";
            // 
            // btnSaveSuppliers
            // 
            this.btnSaveSuppliers.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveSuppliers.Location = new System.Drawing.Point(189, 113);
            this.btnSaveSuppliers.Name = "btnSaveSuppliers";
            this.btnSaveSuppliers.Size = new System.Drawing.Size(85, 37);
            this.btnSaveSuppliers.TabIndex = 2;
            this.btnSaveSuppliers.Text = "Save";
            this.btnSaveSuppliers.UseVisualStyleBackColor = true;
            this.btnSaveSuppliers.Click += new System.EventHandler(this.btnSaveSuppliers_Click);
            // 
            // btnCancelSuppliers
            // 
            this.btnCancelSuppliers.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelSuppliers.Location = new System.Drawing.Point(302, 113);
            this.btnCancelSuppliers.Name = "btnCancelSuppliers";
            this.btnCancelSuppliers.Size = new System.Drawing.Size(81, 37);
            this.btnCancelSuppliers.TabIndex = 3;
            this.btnCancelSuppliers.Text = "Cancel";
            this.btnCancelSuppliers.UseVisualStyleBackColor = true;
            this.btnCancelSuppliers.Click += new System.EventHandler(this.btnCancelSuppliers_Click);
            // 
            // frmSuppliersAddModify
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(182)))), ((int)(((byte)(177)))));
            this.ClientSize = new System.Drawing.Size(403, 160);
            this.Controls.Add(this.btnCancelSuppliers);
            this.Controls.Add(this.btnSaveSuppliers);
            this.Controls.Add(supNameLabel);
            this.Controls.Add(this.supNameTextBox);
            this.Controls.Add(supplierIdLabel);
            this.Controls.Add(this.supplierIdTextBox);
            this.Name = "frmSuppliersAddModify";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add/Modify Suppliers";
            this.Load += new System.EventHandler(this.frmSuppliersAddModify_Load);
            ((System.ComponentModel.ISupportInitialize)(this.supplierBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource supplierBindingSource;
        private System.Windows.Forms.TextBox supNameTextBox;
        private System.Windows.Forms.TextBox supplierIdTextBox;
        private System.Windows.Forms.Button btnSaveSuppliers;
        private System.Windows.Forms.Button btnCancelSuppliers;
    }
}