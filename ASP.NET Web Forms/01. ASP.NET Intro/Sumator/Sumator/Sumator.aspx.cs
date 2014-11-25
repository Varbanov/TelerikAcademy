using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sumator
{
    public partial class Sumator : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void ButtonCalculateSum_Click(object sender, EventArgs e)
        {
            try
            {
                decimal firstNum = decimal.Parse(this.TextBoxFirstNumber.Text);
                decimal secondNum = decimal.Parse(this.TextBoxSecondNumber.Text);
                decimal sum = firstNum + secondNum;
                this.TextBoxSum.Text = sum.ToString();
            }
            catch (Exception)
            {

                this.TextBoxSum.Text = "Invalid numbers";
            }
        }



    }
}