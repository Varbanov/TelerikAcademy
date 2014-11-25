using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebFormsIntro
{
    public partial class PrintHello : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void buttonPrint_Click(object sender, EventArgs e)
        {
            var name = this.textboxName.Text;
            if (name != string.Empty)
            {
                this.labelName.Text = this.Server.HtmlEncode("Hello, " + name);
            }
            else
            {
                this.labelName.Text = "Hello";
            }
        }
    }
}