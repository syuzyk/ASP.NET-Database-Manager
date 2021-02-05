
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
            this.button3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Packages
            // 
            this.Packages.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Packages.Location = new System.Drawing.Point(56, 389);
            this.Packages.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Packages.Name = "Packages";
            this.Packages.Size = new System.Drawing.Size(273, 87);
            this.Packages.TabIndex = 1;
            this.Packages.Text = "Manage Packages";
            this.Packages.UseVisualStyleBackColor = true;
            this.Packages.Click += new System.EventHandler(this.Packages_Click);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(481, 389);
            this.button3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(273, 87);
            this.button3.TabIndex = 2;
            this.button3.Text = "Manage Products";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // frm1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(814, 523);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.Packages);
            this.DoubleBuffered = true;
            this.Name = "frm1";
            this.Text = "Package and Product Manager - Home";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button Packages;
        private System.Windows.Forms.Button button3;
    }
}

