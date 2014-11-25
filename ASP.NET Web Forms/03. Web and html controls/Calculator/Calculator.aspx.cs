using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Calculator
{
    public partial class Calculator : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void OnOperatorButtonClicked(object sender, EventArgs e)
        {
            var operand = (sender as HtmlInputButton).Value;
            var valueInMemory = this.GetValueInMemory();
            var lastSelectedOperator = this.GetLastSelectedOperator();

            if (valueInMemory != double.MinValue)
            {
                var secondValue = this.GetInputValueAsNumber(this.resultBox.Value);
                var result = this.CalculateResult(valueInMemory, secondValue, lastSelectedOperator);
                this.resultBox.Value = result.ToString();
                this.valueInMemory.Value = double.MinValue.ToString();
            }
            else
            {
                this.valueInMemory.Value = this.GetInputValueAsNumber(this.resultBox.Value).ToString();
                this.lastSelectedOperator.Value = operand;
                this.resultBox.Value = string.Empty;
            }
        }

        protected void OnRootButtonClicked(object sender, EventArgs e)
        {
            // TODO:
        }

        protected void OnResultButtonClicked(object sender, EventArgs e)
        {
            var valueFromTextBox = this.GetInputValueAsNumber(this.resultBox.Value);
            var valueFromMemory = this.GetValueInMemory();
            var selectedOperator = this.GetLastSelectedOperator();

            var result = this.CalculateResult(valueFromMemory, valueFromTextBox, selectedOperator);
            this.resultBox.Value = result.ToString();

            this.lastSelectedOperator.Value = string.Empty;
            this.valueInMemory.Value = string.Empty;
        }

        protected void OnNumberButtonClicked(object sender, EventArgs e)
        {
            var input = sender as HtmlInputButton;
            var result = Math.Round(this.GetInputValueAsNumber(this.resultBox.Value += input.Value), 2);
            this.resultBox.Value = result.ToString();
        }

        private double CalculateResult(double firstValue, double secondValue, string operand)
        {
            switch (operand)
            {
                case "+":
                    {
                        return firstValue + secondValue;
                    }
                case "-":
                    {
                        return firstValue - secondValue;
                    }
                case "*":
                    {
                        return firstValue * secondValue;
                    }
                case "/":
                    {
                        return firstValue / secondValue;
                    }
                default:
                    {
                        return 0;
                    }
            }
        }

        private string GetLastSelectedOperator()
        {
            return this.lastSelectedOperator.Value;
        }

        private double GetInputValueAsNumber(string value)
        {
            double result;
            double.TryParse(value, out result);
            return result;
        }

        private double GetValueInMemory()
        {
            if (string.IsNullOrEmpty(this.valueInMemory.Value))
            {
                return double.MinValue;
            }

            return this.GetInputValueAsNumber(this.valueInMemory.Value);
        }


    }
}