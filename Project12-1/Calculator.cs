using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project12_1
{
    class Calculator
    {
        
        private decimal currentValue;
        private decimal nextOperand;
        private string operation;
        private bool firstEntered;

        public Calculator()
        {
            this.currentValue = 0;
            this.firstEntered = false;
        }

        public decimal CurrentValue
        {
            get { return currentValue;  }
            
        }
        //sets current value 
        public void EnterValue(decimal valueEntered)
        {
            if (!firstEntered)
            {
                currentValue = valueEntered;
                firstEntered = true;
            } else
            {
                nextOperand = valueEntered;
            }
        }
        //methods
        public void Add()
        {
            operation = "+";
        }
        public void Subtract()
        {
            operation = "-";
        }
        public void Multiply()
        {
            operation = "*";
        }
        public void Divide()
        {
            operation = "/";
        }
        public void Equals()
        {
            //switch statement to perform operations 
            switch (operation)
            {
                case "+":
                    currentValue += nextOperand;
                    break;
                case "-":
                    currentValue -= nextOperand;
                    break;
                case "*":
                    currentValue *= nextOperand;
                    break;
                case "/":
                    currentValue /= nextOperand;
                    break;
                case "1/X":
                    currentValue = 1/currentValue;
                    break;
                case "sqrt":
                    //converts to double so can use sqrt
                    double sNumber = Convert.ToDouble(currentValue);
                    sNumber = Math.Sqrt(sNumber);
                    currentValue = Convert.ToDecimal(sNumber);
                    break;
            }


        }
        public void Reciprocal()
        {
            operation = "1/X";
        }
        public void SquareRoot()
        {
            operation = "sqrt";
        }
        public void Clear()
        {
            operation = null;
            nextOperand = 0m;
            currentValue = 0m;
            firstEntered = false;
        }
    }
}