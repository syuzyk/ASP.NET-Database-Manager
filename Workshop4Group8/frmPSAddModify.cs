using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Workshop4Group8
{
    public partial class frmPSAddModify : Form
    {
        public frmPSAddModify()
        {
            InitializeComponent();
        }

        public frmPS mainForm;

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void frmPSAddModify_Load(object sender, EventArgs e)
        {

        }
    }
}
