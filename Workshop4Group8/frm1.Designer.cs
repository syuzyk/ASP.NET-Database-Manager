
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
            this.Packages = new System.Windows.Forms.Button();
            this.product = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Packages
            // 
            this.Packages.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Packages.Location = new System.Drawing.Point(75, 479);
            this.Packages.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Packages.Name = "Packages";
            this.Packages.Size = new System.Drawing.Size(364, 107);
            this.Packages.TabIndex = 1;
            this.Packages.Text = "Manage Packages";
            this.Packages.UseVisualStyleBackColor = true;
            this.Packages.Click += new System.EventHandler(this.Packages_Click);
            // 
            // product
            // 
            this.product.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.product.Location = new System.Drawing.Point(641, 479);
            this.product.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.product.Name = "product";
            this.product.Size = new System.Drawing.Size(364, 107);
            this.product.TabIndex = 2;
            this.product.Text = "Manage Products";
            this.product.UseVisualStyleBackColor = true;
            this.product.Click += new System.EventHandler(this.button3_Click);
            // 
            // frm1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1085, 644);
            this.Controls.Add(this.product);
            this.Controls.Add(this.Packages);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frm1";
            this.Text = "Package and Product Manager - Home";
            this.AutoSizeChanged += new System.EventHandler(this.frm1_Resize);
            this.Load += new System.EventHandler(this.frm1_Load);
            this.ResizeEnd += new System.EventHandler(this.frm1_Resize);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button Packages;
        private System.Windows.Forms.Button product;
    }
}

