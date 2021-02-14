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
        public static bool IsPresent(Control control) //Takes in any type of control as a argument
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

        public static bool IsNonNegativeDecimal(TextBox tb, string name)
        {
            bool isValid = true;
            decimal value;
            if (!Decimal.TryParse(tb.Text, out value))// not a decimal number
            {
                isValid = false;
                MessageBox.Show(name + " should be a number", "Input Error");
                tb.SelectAll(); // select all text box content to ease replacing
                tb.Focus();
            }
            else if (value < 0)// integer, but negative
            {
                isValid = false;
                MessageBox.Show(name + " should be positive or zero", "Input Error");
                tb.SelectAll(); // select all text box content to ease replacing
                tb.Focus();
            }
            return isValid;
        }

        public string IsDecimalNull(decimal? value)
        {
            return value == null || value == 0 ? "NA" : value.ToString();
        }

        //Validates the data to make sure the data is an Integer
        public static bool IsInt32(TextBox textBox)
        {
            try
            {
                Convert.ToInt32(textBox.Text);
                return true;
            }
            catch (FormatException)
            {
                MessageBox.Show(textBox.Tag + " must be an integer. Entry Error.");
                textBox.Focus();
                return false;
            }
        }
    }
}
