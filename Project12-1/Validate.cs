using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project12_1
{

    public static class Validator
    {



        //makes usre something is entered 
        public static bool IsPresent(string value)
        {
            if (value == "")
            {
                MessageBox.Show("A value is required", "Input Error");
                
                return false;
            }
            return true;
        }
        //checks input 
        public static bool IsDecimal(string value)
        {
            
            decimal number = 0;
            if (Decimal.TryParse(value, out number))
            {
                return true;
            }
            else
            {
              
                return false;
            }

        }
        //checks input 
        public static bool IsOperator(string value)
        {
            
            if (value == "/" || value == "*" || value == "+" || value == "=" || value == "-")
            {
                                return true;
            }
            return false;
        }
    }
}

