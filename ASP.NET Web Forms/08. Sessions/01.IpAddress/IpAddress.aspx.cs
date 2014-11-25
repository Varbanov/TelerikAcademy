using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _01.IpAddress
{
    public partial class IpAddress : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.IpLabel.Text = this.Request.UserAgent + "<br/>";
            this.IpLabel.Text += this.Request.UserHostAddress.ToString().Trim();
        }
    }
}