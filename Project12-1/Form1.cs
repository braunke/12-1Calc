using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Project12_1;

namespace Project12_1
{
    public partial class Form1 : Form
    {

        Calculator calculator;

        public Form1()
        {
            InitializeComponent();
            calculator = new Calculator();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        //bool to determine if values should be reset or not depending on click events 
        bool reset = false;

        //method to display text in display text box 
        private string Display
        {
            get { return txtDisplay.Text; }
            set { txtDisplay.Text = value; }
        }

        //all numbers and decimal point wired up to click event
        //to get value of text  then sends it to handle function 
        private void btn_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            handleInput(btn.Text);
        }

        //each operation has its own event which uses a method from the calculator class 
        private void btnAdd_Click(object sender, EventArgs e) { add(); }
        private void btnSubtract_Click(object sender, EventArgs e) { subtract(); }
        private void btnMultiply_Click(object sender, EventArgs e) { multiply(); }
        private void btnDivide_Click(object sender, EventArgs e) { divide(); }
        private void btnSQRT_Click(object sender, EventArgs e) { squareRoot(); }
        private void btnRecip_Click(object sender, EventArgs e) { reciprocal(); }
        private void btnEquals_Click(object sender, EventArgs e) { equals(); }

        //adds next digit if valid 
        private void handleInput(string keyValue)
        {
            string nextDisplayedValue = Display;
            if (reset)
            {
                nextDisplayedValue = "";
            }
            nextDisplayedValue += keyValue;
            if (Validator.IsDecimal(nextDisplayedValue))
            {
                Display = nextDisplayedValue;
                reset = false;
            }
        }

        //function for operators 
        private void add()
        {
            if (Validator.IsPresent(Display))
            {
                calculator.Add();
                EnterValue();
            }
        }

        private void subtract()
        {
            if (Validator.IsPresent(Display))
            {
                calculator.Subtract();
                EnterValue();
            }
        }

        private void multiply()
        {
            if (Validator.IsPresent(Display))
            {
                calculator.Multiply();
                EnterValue();
            }
        }

        private void divide()
        {
            if (Validator.IsPresent(Display))
            {
                calculator.Divide();
                EnterValue();
            }
        }

        private void squareRoot()
        {
            if (Validator.IsPresent(Display))
            {
                calculator.SquareRoot();
                EnterValue();
                calculator.Equals();
                //displays answer 
                Display = Convert.ToString(calculator.CurrentValue);
            }
        }

        private void reciprocal()
        {
            if (Validator.IsPresent(Display))
            {
                calculator.Reciprocal();
                EnterValue();
                calculator.Equals();
                //displays answer 
                Display = Convert.ToString(calculator.CurrentValue);
            }
        }

        private void equals()
        {
            //try-catch to make sure it is not dividing by zero 
            try
            {
                //converts string to decimal for calculation then uses equals method for calculator class 
                Decimal valueEntered = Convert.ToDecimal(Display);
                calculator.EnterValue(valueEntered);
                calculator.Equals();
                //displays answer 
                Display = Convert.ToString(calculator.CurrentValue);
            }
            catch (DivideByZeroException)
            {
                Display = "Can not divide by zero";
            }
        }

        //converts value entered in display to decimal and sends to enter value method 
        public void EnterValue()
        {
            Decimal valueEntered = Convert.ToDecimal(Display);
            calculator.EnterValue(valueEntered);
            reset = true;
        }

        //clears out everything in the calculator 
        private void btnClear_Click(object sender, EventArgs e)
        {
            reset = false;
            Display = "";
            calculator.Clear();
        }

        //removes last entered number 
        private void btnBack_Click(object sender, EventArgs e)
        {
            if (Display != "")
            { Display = Display.Substring(0, Display.Length - 1); }
        }
        
        //deals with keyboard entered characters 
        private void txtDisplay_KeyPress(object sender, KeyPressEventArgs e)
        {
            string keyValue = e.KeyChar + "";
            if (Validator.IsOperator(keyValue))
            {
                switch (keyValue)
                {
                    case "+":
                        add();
                        break;
                    case "-":
                        subtract();
                        break;
                    case "/":
                        divide();
                        break;
                    case "*":
                        multiply();
                        break;
                    case "1/X":
                        reciprocal();
                        break;
                    case "sqrt":
                        squareRoot();
                        break;
                    case "=":
                        equals();
                        break;
                }
            }
            else 
            {
                handleInput(keyValue);
            }
            e.Handled = true;

        }

        //if number is negative will change to positive and vise versa 
        private void btnChange_Click(object sender, EventArgs e)
        {
            decimal displayNumber = Convert.ToDecimal(Display);
            if (displayNumber >= 0)
            {
                Display = "-" + Display;
            }
            else
            {
                Display = Display.Substring(1);
            }
        }
    }
}
