using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _04.DeleteViewState
{
    public partial class DeleteViewState : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.ViewState["values"] == null)
            {
                this.ViewState.Add("values", new List<string>());
            }
        }

        protected void OnButtonClicked(object sender, EventArgs e)
        {
            var list = (List<string>)this.ViewState["values"];
            list.Add(this.TextBox.Text);
            this.Label.Text = string.Empty;

            foreach (var item in list)
            {
                this.Label.Text += "<br/>" + item;
            }

            this.TextBox.Text = string.Empty;
        }
    }
}