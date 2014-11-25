using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _02.Session
{
    public partial class Session : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["values"] == null)
            {
                this.Session.Add("values", new List<string>());
            }
        }

        protected void OnSaveSessionButtonClicked(object sender, EventArgs e)
        {
            var list = (List<string>)this.Session["values"];
            list.Add(this.sessionTextBox.Text);
            this.MainLabel.Text = string.Empty;

            foreach (var item in list)
            {
                this.MainLabel.Text += "<br/>" + item;
            }

            this.sessionTextBox.Text = string.Empty;
        }
    }
}