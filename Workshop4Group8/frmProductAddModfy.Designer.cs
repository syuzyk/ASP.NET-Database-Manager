﻿
namespace Workshop4Group8
{
    partial class frmProductAddModfy
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
            System.Windows.Forms.Label prodNameLabel;
            this.prodNameTextBox = new System.Windows.Forms.TextBox();
            this.productBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.exit = new System.Windows.Forms.Button();
            this.save = new System.Windows.Forms.Button();
            this.productIdTextBox = new System.Windows.Forms.TextBox();
            this.productID = new System.Windows.Forms.Label();
            prodNameLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.productBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // prodNameLabel
            // 
            prodNameLabel.AutoSize = true;
            prodNameLabel.Location = new System.Drawing.Point(11, 68);
            prodNameLabel.Name = "prodNameLabel";
            prodNameLabel.Size = new System.Drawing.Size(121, 20);
            prodNameLabel.TabIndex = 1;
            prodNameLabel.Text = "Product Name:";
            // 
            // prodNameTextBox
            // 
            this.prodNameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.productBindingSource, "ProdName", true));
            this.prodNameTextBox.Location = new System.Drawing.Point(138, 65);
            this.prodNameTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.prodNameTextBox.Name = "prodNameTextBox";
            this.prodNameTextBox.Size = new System.Drawing.Size(112, 26);
            this.prodNameTextBox.TabIndex = 2;
            // 
            // productBindingSource
            // 
            this.productBindingSource.DataSource = typeof(Workshop4Group8.Product);
            // 
            // exit
            // 
            this.exit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exit.Location = new System.Drawing.Point(138, 128);
            this.exit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.exit.Name = "exit";
            this.exit.Size = new System.Drawing.Size(100, 45);
            this.exit.TabIndex = 8;
            this.exit.Text = "Cancel";
            this.exit.UseVisualStyleBackColor = true;
            this.exit.Click += new System.EventHandler(this.exit_Click);
            // 
            // save
            // 
            this.save.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.save.Location = new System.Drawing.Point(26, 128);
            this.save.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(83, 45);
            this.save.TabIndex = 7;
            this.save.Text = "Save";
            this.save.UseVisualStyleBackColor = true;
            this.save.Click += new System.EventHandler(this.save_Click);
            // 
            // productIdTextBox
            // 
            this.productIdTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.productBindingSource, "ProductId", true));
            this.productIdTextBox.Location = new System.Drawing.Point(138, 22);
            this.productIdTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.productIdTextBox.Name = "productIdTextBox";
            this.productIdTextBox.ReadOnly = true;
            this.productIdTextBox.Size = new System.Drawing.Size(112, 26);
            this.productIdTextBox.TabIndex = 9;
            // 
            // productID
            // 
            this.productID.AutoSize = true;
            this.productID.Location = new System.Drawing.Point(35, 25);
            this.productID.Name = "productID";
            this.productID.Size = new System.Drawing.Size(94, 20);
            this.productID.TabIndex = 10;
            this.productID.Text = "Product ID:";
            // 
            // frmProductAddModfy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(182)))), ((int)(((byte)(177)))));
            this.ClientSize = new System.Drawing.Size(273, 211);
            this.Controls.Add(this.productID);
            this.Controls.Add(this.productIdTextBox);
            this.Controls.Add(this.exit);
            this.Controls.Add(this.save);
            this.Controls.Add(prodNameLabel);
            this.Controls.Add(this.prodNameTextBox);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmProductAddModfy";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add/Modify Product";
            this.Load += new System.EventHandler(this.frmProductAddModfy_Load);
            ((System.ComponentModel.ISupportInitialize)(this.productBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource productBindingSource;
        private System.Windows.Forms.TextBox prodNameTextBox;
        private System.Windows.Forms.Button exit;
        private System.Windows.Forms.Button save;
        private System.Windows.Forms.TextBox productIdTextBox;
        private System.Windows.Forms.Label productID;
    }
}