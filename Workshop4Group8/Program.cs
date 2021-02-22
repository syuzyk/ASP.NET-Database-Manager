using System;
using System.Windows.Forms;

namespace Workshop4Group8
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new frmPackages());
            //Application.Run(new frmSuppliers());
            //Application.Run(new frmProduct());
            Application.Run(new frm1());
            //Application.Run(new frmPS());
        }
    }
}
