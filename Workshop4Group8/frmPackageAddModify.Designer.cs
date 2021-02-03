
namespace Workshop4Group8
{
    partial class frmPackageAddModify
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
            System.Windows.Forms.Label pkgDescLabel1;
            System.Windows.Forms.Label packageIdLabel;
            System.Windows.Forms.Label pkgAgencyCommissionLabel;
            System.Windows.Forms.Label pkgBasePriceLabel;
            System.Windows.Forms.Label pkgEndDateLabel;
            System.Windows.Forms.Label pkgNameLabel;
            System.Windows.Forms.Label pkgStartDateLabel;
            this.pkgDescRichTextBox = new System.Windows.Forms.RichTextBox();
            this.packageIdTextBox = new System.Windows.Forms.TextBox();
            this.pkgAgencyCommissionTextBox = new System.Windows.Forms.TextBox();
            this.packageBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.pkgBasePriceTextBox = new System.Windows.Forms.TextBox();
            this.packageBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pkgEndDateDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.pkgNameTextBox = new System.Windows.Forms.TextBox();
            this.pkgStartDateDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.btnAddOk = new System.Windows.Forms.Button();
            this.btnAddCancel = new System.Windows.Forms.Button();
            pkgDescLabel1 = new System.Windows.Forms.Label();
            packageIdLabel = new System.Windows.Forms.Label();
            pkgAgencyCommissionLabel = new System.Windows.Forms.Label();
            pkgBasePriceLabel = new System.Windows.Forms.Label();
            pkgEndDateLabel = new System.Windows.Forms.Label();
            pkgNameLabel = new System.Windows.Forms.Label();
            pkgStartDateLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.packageBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.packageBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // pkgDescLabel1
            // 
            pkgDescLabel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            pkgDescLabel1.AutoSize = true;
            pkgDescLabel1.Location = new System.Drawing.Point(117, 83);
            pkgDescLabel1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            pkgDescLabel1.Name = "pkgDescLabel1";
            pkgDescLabel1.Size = new System.Drawing.Size(83, 17);
            pkgDescLabel1.TabIndex = 31;
            pkgDescLabel1.Text = "Description:";
            pkgDescLabel1.UseMnemonic = false;
            // 
            // packageIdLabel
            // 
            packageIdLabel.AutoSize = true;
            packageIdLabel.Location = new System.Drawing.Point(301, 15);
            packageIdLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            packageIdLabel.Name = "packageIdLabel";
            packageIdLabel.Size = new System.Drawing.Size(25, 17);
            packageIdLabel.TabIndex = 19;
            packageIdLabel.Text = "ID:";
            // 
            // pkgAgencyCommissionLabel
            // 
            pkgAgencyCommissionLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            pkgAgencyCommissionLabel.AutoSize = true;
            pkgAgencyCommissionLabel.Location = new System.Drawing.Point(110, 283);
            pkgAgencyCommissionLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            pkgAgencyCommissionLabel.Name = "pkgAgencyCommissionLabel";
            pkgAgencyCommissionLabel.Size = new System.Drawing.Size(87, 17);
            pkgAgencyCommissionLabel.TabIndex = 21;
            pkgAgencyCommissionLabel.Text = "Commission:";
            pkgAgencyCommissionLabel.UseMnemonic = false;
            // 
            // pkgBasePriceLabel
            // 
            pkgBasePriceLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            pkgBasePriceLabel.AutoSize = true;
            pkgBasePriceLabel.Location = new System.Drawing.Point(153, 247);
            pkgBasePriceLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            pkgBasePriceLabel.Name = "pkgBasePriceLabel";
            pkgBasePriceLabel.Size = new System.Drawing.Size(44, 17);
            pkgBasePriceLabel.TabIndex = 23;
            pkgBasePriceLabel.Text = "Price:";
            pkgBasePriceLabel.UseMnemonic = false;
            // 
            // pkgEndDateLabel
            // 
            pkgEndDateLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            pkgEndDateLabel.AutoSize = true;
            pkgEndDateLabel.Location = new System.Drawing.Point(131, 200);
            pkgEndDateLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            pkgEndDateLabel.Name = "pkgEndDateLabel";
            pkgEndDateLabel.Size = new System.Drawing.Size(71, 17);
            pkgEndDateLabel.TabIndex = 25;
            pkgEndDateLabel.Text = "End Date:";
            pkgEndDateLabel.UseMnemonic = false;
            // 
            // pkgNameLabel
            // 
            pkgNameLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            pkgNameLabel.AutoSize = true;
            pkgNameLabel.Location = new System.Drawing.Point(157, 48);
            pkgNameLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            pkgNameLabel.Name = "pkgNameLabel";
            pkgNameLabel.Size = new System.Drawing.Size(49, 17);
            pkgNameLabel.TabIndex = 27;
            pkgNameLabel.Text = "Name:";
            pkgNameLabel.UseMnemonic = false;
            // 
            // pkgStartDateLabel
            // 
            pkgStartDateLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            pkgStartDateLabel.AutoSize = true;
            pkgStartDateLabel.Location = new System.Drawing.Point(124, 164);
            pkgStartDateLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            pkgStartDateLabel.Name = "pkgStartDateLabel";
            pkgStartDateLabel.Size = new System.Drawing.Size(76, 17);
            pkgStartDateLabel.TabIndex = 29;
            pkgStartDateLabel.Text = "Start Date:";
            pkgStartDateLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            pkgStartDateLabel.UseMnemonic = false;
            // 
            // pkgDescRichTextBox
            // 
            this.pkgDescRichTextBox.Location = new System.Drawing.Point(122, 83);
            this.pkgDescRichTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.pkgDescRichTextBox.Name = "pkgDescRichTextBox";
            this.pkgDescRichTextBox.Size = new System.Drawing.Size(258, 65);
            this.pkgDescRichTextBox.TabIndex = 32;
            this.pkgDescRichTextBox.Text = "";
            // 
            // packageIdTextBox
            // 
            this.packageIdTextBox.Location = new System.Drawing.Point(342, 12);
            this.packageIdTextBox.Margin = new System.Windows.Forms.Padding(5);
            this.packageIdTextBox.Name = "packageIdTextBox";
            this.packageIdTextBox.ReadOnly = true;
            this.packageIdTextBox.Size = new System.Drawing.Size(38, 23);
            this.packageIdTextBox.TabIndex = 20;
            this.packageIdTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // pkgAgencyCommissionTextBox
            // 
            this.pkgAgencyCommissionTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.packageBindingSource1, "PkgAgencyCommission", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, "N/A", "C2"));
            this.pkgAgencyCommissionTextBox.Location = new System.Drawing.Point(122, 283);
            this.pkgAgencyCommissionTextBox.Margin = new System.Windows.Forms.Padding(5);
            this.pkgAgencyCommissionTextBox.Name = "pkgAgencyCommissionTextBox";
            this.pkgAgencyCommissionTextBox.Size = new System.Drawing.Size(97, 23);
            this.pkgAgencyCommissionTextBox.TabIndex = 22;
            // 
            // packageBindingSource1
            // 
            this.packageBindingSource1.DataSource = typeof(Workshop4Group8.Package);
            // 
            // pkgBasePriceTextBox
            // 
            this.pkgBasePriceTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.packageBindingSource, "PkgBasePrice", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "C2"));
            this.pkgBasePriceTextBox.Location = new System.Drawing.Point(122, 247);
            this.pkgBasePriceTextBox.Margin = new System.Windows.Forms.Padding(5);
            this.pkgBasePriceTextBox.Name = "pkgBasePriceTextBox";
            this.pkgBasePriceTextBox.Size = new System.Drawing.Size(97, 23);
            this.pkgBasePriceTextBox.TabIndex = 24;
            // 
            // packageBindingSource
            // 
            this.packageBindingSource.DataSource = typeof(Workshop4Group8.Package);
            // 
            // pkgEndDateDateTimePicker
            // 
            this.pkgEndDateDateTimePicker.Location = new System.Drawing.Point(122, 200);
            this.pkgEndDateDateTimePicker.Margin = new System.Windows.Forms.Padding(5);
            this.pkgEndDateDateTimePicker.Name = "pkgEndDateDateTimePicker";
            this.pkgEndDateDateTimePicker.Size = new System.Drawing.Size(258, 23);
            this.pkgEndDateDateTimePicker.TabIndex = 26;
            this.pkgEndDateDateTimePicker.ValueChanged += new System.EventHandler(this.pkgEndDateDateTimePicker_ValueChanged);
            this.pkgEndDateDateTimePicker.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.pkgEndDateDateTimePicker_KeyPress);
            // 
            // pkgNameTextBox
            // 
            this.pkgNameTextBox.Location = new System.Drawing.Point(122, 48);
            this.pkgNameTextBox.Margin = new System.Windows.Forms.Padding(5);
            this.pkgNameTextBox.Name = "pkgNameTextBox";
            this.pkgNameTextBox.Size = new System.Drawing.Size(258, 23);
            this.pkgNameTextBox.TabIndex = 1;
            // 
            // pkgStartDateDateTimePicker
            // 
            this.pkgStartDateDateTimePicker.Location = new System.Drawing.Point(122, 164);
            this.pkgStartDateDateTimePicker.Margin = new System.Windows.Forms.Padding(5);
            this.pkgStartDateDateTimePicker.Name = "pkgStartDateDateTimePicker";
            this.pkgStartDateDateTimePicker.Size = new System.Drawing.Size(258, 23);
            this.pkgStartDateDateTimePicker.TabIndex = 30;
            this.pkgStartDateDateTimePicker.ValueChanged += new System.EventHandler(this.pkgStartDateDateTimePicker_ValueChanged);
            this.pkgStartDateDateTimePicker.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.pkgStartDateDateTimePicker_KeyPress);
            // 
            // btnAddOk
            // 
            this.btnAddOk.Location = new System.Drawing.Point(34, 335);
            this.btnAddOk.Name = "btnAddOk";
            this.btnAddOk.Size = new System.Drawing.Size(126, 45);
            this.btnAddOk.TabIndex = 33;
            this.btnAddOk.Text = "OK";
            this.btnAddOk.UseVisualStyleBackColor = true;
            this.btnAddOk.Click += new System.EventHandler(this.btnAddOk_Click);
            // 
            // btnAddCancel
            // 
            this.btnAddCancel.Location = new System.Drawing.Point(254, 334);
            this.btnAddCancel.Name = "btnAddCancel";
            this.btnAddCancel.Size = new System.Drawing.Size(126, 45);
            this.btnAddCancel.TabIndex = 34;
            this.btnAddCancel.Text = "Cancel";
            this.btnAddCancel.UseVisualStyleBackColor = true;
            this.btnAddCancel.Click += new System.EventHandler(this.btnAddCancel_Click);
            // 
            // frmPackageAddModify
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 392);
            this.Controls.Add(this.btnAddCancel);
            this.Controls.Add(this.btnAddOk);
            this.Controls.Add(pkgDescLabel1);
            this.Controls.Add(this.pkgDescRichTextBox);
            this.Controls.Add(packageIdLabel);
            this.Controls.Add(this.packageIdTextBox);
            this.Controls.Add(pkgAgencyCommissionLabel);
            this.Controls.Add(this.pkgAgencyCommissionTextBox);
            this.Controls.Add(pkgBasePriceLabel);
            this.Controls.Add(this.pkgBasePriceTextBox);
            this.Controls.Add(pkgEndDateLabel);
            this.Controls.Add(this.pkgEndDateDateTimePicker);
            this.Controls.Add(pkgNameLabel);
            this.Controls.Add(this.pkgNameTextBox);
            this.Controls.Add(pkgStartDateLabel);
            this.Controls.Add(this.pkgStartDateDateTimePicker);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmPackageAddModify";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.frmPackageAddModify_Load);
            ((System.ComponentModel.ISupportInitialize)(this.packageBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.packageBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox pkgDescRichTextBox;
        private System.Windows.Forms.TextBox packageIdTextBox;
        private System.Windows.Forms.TextBox pkgAgencyCommissionTextBox;
        private System.Windows.Forms.TextBox pkgBasePriceTextBox;
        private System.Windows.Forms.DateTimePicker pkgEndDateDateTimePicker;
        private System.Windows.Forms.TextBox pkgNameTextBox;
        private System.Windows.Forms.DateTimePicker pkgStartDateDateTimePicker;
        private System.Windows.Forms.Button btnAddOk;
        private System.Windows.Forms.Button btnAddCancel;
        private System.Windows.Forms.BindingSource packageBindingSource;
        private System.Windows.Forms.BindingSource packageBindingSource1;
    }
}