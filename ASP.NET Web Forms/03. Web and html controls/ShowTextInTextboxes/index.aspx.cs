using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ShowTextInTextboxes
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void buttonSubmit_Click(object sender, EventArgs e)
        {
            var inputText = this.TextboxInput.Text;
            this.LabelResult.Text = this.Server.HtmlEncode(inputText);
            this.TextBoxResult.Text = inputText; // this.Server.HtmlEncode(inputText);
        }
    }
}