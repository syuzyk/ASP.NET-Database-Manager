
namespace Workshop4Group8
{
    partial class frm1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm1));
            this.product = new System.Windows.Forms.Button();
            this.Packages = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.Supplier = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // product
            // 
            this.product.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.product.Location = new System.Drawing.Point(12, 12);
            this.product.Name = "product";
            this.product.Size = new System.Drawing.Size(199, 108);
            this.product.TabIndex = 0;
            this.product.Text = "Product";
            this.product.UseVisualStyleBackColor = true;
            this.product.Click += new System.EventHandler(this.product_Click);
            // 
            // Packages
            // 
            this.Packages.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Packages.Location = new System.Drawing.Point(12, 331);
            this.Packages.Name = "Packages";
            this.Packages.Size = new System.Drawing.Size(199, 107);
            this.Packages.TabIndex = 1;
            this.Packages.Text = "Packages";
            this.Packages.UseVisualStyleBackColor = true;
            this.Packages.Click += new System.EventHandler(this.Packages_Click);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(603, 331);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(185, 116);
            this.button3.TabIndex = 2;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // Supplier
            // 
            this.Supplier.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Supplier.Location = new System.Drawing.Point(603, 12);
            this.Supplier.Name = "Supplier";
            this.Supplier.Size = new System.Drawing.Size(185, 108);
            this.Supplier.TabIndex = 3;
            this.Supplier.Text = "Suppliers";
            this.Supplier.UseVisualStyleBackColor = true;
            this.Supplier.Click += new System.EventHandler(this.Supplier_Click);
            // 
            // frm1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(847, 492);
            this.Controls.Add(this.Supplier);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.Packages);
            this.Controls.Add(this.product);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frm1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.frm1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button product;
        private System.Windows.Forms.Button Packages;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button Supplier;
    }
}

