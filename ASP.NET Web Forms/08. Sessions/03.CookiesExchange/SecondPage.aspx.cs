using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _03.CookiesExchange
{
    public partial class SecondPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            foreach (string item in this.Request.Cookies)
            {
                this.Literal.Text += this.Request.Cookies[item].Value + "<br/>";
            }
        }

        protected void OnBtnClicked(object sender, EventArgs e)
        {
            this.Response.AppendCookie(new HttpCookie(new Random().Next().ToString(), "SecondPage cookie"));
            this.Response.Redirect("FirstPage.aspx");
        }
    }
}