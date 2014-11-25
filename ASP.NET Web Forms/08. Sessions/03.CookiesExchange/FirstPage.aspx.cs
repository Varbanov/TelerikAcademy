using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _03.CookiesExchange
{
    public partial class FirstPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void OnRedirectButtonClicked(object sender, EventArgs e)
        {
            this.Response.AppendCookie(new HttpCookie(new Random().Next().ToString(), "FirstPage cookie"));
            this.Response.Redirect("SecondPage.aspx");
        }
    }
}