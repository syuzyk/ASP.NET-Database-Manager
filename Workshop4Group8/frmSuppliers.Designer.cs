namespace Workshop4Group8
{
    partial class frmSuppliers
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
            this.supplierDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.supplierBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnAddSuppliers = new System.Windows.Forms.Button();
            this.btnModifySuppliers = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.supplierDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.supplierBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // supplierDataGridView
            // 
            this.supplierDataGridView.AutoGenerateColumns = false;
            this.supplierDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.supplierDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2});
            this.supplierDataGridView.DataSource = this.supplierBindingSource;
            this.supplierDataGridView.Location = new System.Drawing.Point(24, 23);
            this.supplierDataGridView.Name = "supplierDataGridView";
            this.supplierDataGridView.Size = new System.Drawing.Size(359, 262);
            this.supplierDataGridView.TabIndex = 1;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "SupplierId";
            this.dataGridViewTextBoxColumn1.HeaderText = "Supplier Id";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 80;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "SupName";
            this.dataGridViewTextBoxColumn2.HeaderText = "Supplier Name";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 225;
            // 
            // supplierBindingSource
            // 
            this.supplierBindingSource.DataSource = typeof(Workshop4Group8.Supplier);
            // 
            // btnAddSuppliers
            // 
            this.btnAddSuppliers.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddSuppliers.Location = new System.Drawing.Point(24, 340);
            this.btnAddSuppliers.Name = "btnAddSuppliers";
            this.btnAddSuppliers.Size = new System.Drawing.Size(118, 36);
            this.btnAddSuppliers.TabIndex = 2;
            this.btnAddSuppliers.Text = "Add Suppliers";
            this.btnAddSuppliers.UseVisualStyleBackColor = true;
            this.btnAddSuppliers.Click += new System.EventHandler(this.btnAddSuppliers_Click);
            // 
            // btnModifySuppliers
            // 
            this.btnModifySuppliers.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModifySuppliers.Location = new System.Drawing.Point(163, 340);
            this.btnModifySuppliers.Name = "btnModifySuppliers";
            this.btnModifySuppliers.Size = new System.Drawing.Size(118, 36);
            this.btnModifySuppliers.TabIndex = 3;
            this.btnModifySuppliers.Text = "Modify Suppliers";
            this.btnModifySuppliers.UseVisualStyleBackColor = true;
            this.btnModifySuppliers.Click += new System.EventHandler(this.btnModifySuppliers_Click);
            // 
            // frmSuppliers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.ClientSize = new System.Drawing.Size(419, 450);
            this.Controls.Add(this.btnModifySuppliers);
            this.Controls.Add(this.btnAddSuppliers);
            this.Controls.Add(this.supplierDataGridView);
            this.Name = "frmSuppliers";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmSuppliers";
            this.Load += new System.EventHandler(this.frmSuppliers_Load);
            ((System.ComponentModel.ISupportInitialize)(this.supplierDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.supplierBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource supplierBindingSource;
        private System.Windows.Forms.DataGridView supplierDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.Button btnAddSuppliers;
        private System.Windows.Forms.Button btnModifySuppliers;
    }
}