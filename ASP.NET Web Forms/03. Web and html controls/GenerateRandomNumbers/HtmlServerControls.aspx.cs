using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GenerateRandomNumbers
{
    public partial class HtmlServerControls : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonSubmit_ServerClick(object sender, EventArgs e)
        {
            int min;
            int max;
            var firstIsNum = int.TryParse(this.inputMin.Value, out min);
            var secondIsNum = int.TryParse(this.inputMax.Value, out max);

            if (!(firstIsNum && secondIsNum && min <= max))
            {
                this.labelResult.Text = "Wrong input or min is smaller than max!";
                return;
            }

            var random = new Random();
            this.labelResult.Text = random.Next(min, max + 1).ToString();
        }
    }
}