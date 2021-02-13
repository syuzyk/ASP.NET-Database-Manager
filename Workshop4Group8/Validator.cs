using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Workshop4Group8
{
    class Validator
    {
        //Validates the data to make sure there is an entry
        public static bool IsPresent(Control control) //Takes in any type of control as a arguement
        {
            if (control.GetType().ToString() == "System.Windows.Forms.TextBox") //If the type is a textbox
            {
                TextBox textBox = (TextBox)control;
                if (textBox.Text == "") //If the field is empty
                {
                    MessageBox.Show(textBox.Tag + " is a required field. Entry Error.");
                    textBox.Focus();
                    return false;
                    //Testing a commit
                }
            }
            return true;
        }
    }
}
