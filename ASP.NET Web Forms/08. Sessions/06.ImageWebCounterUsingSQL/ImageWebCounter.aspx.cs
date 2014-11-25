using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _05.ImageWebCounter
{
    public partial class ImageWebCounter : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Controls.Add(new LiteralControl("<img src=\"ImageGenerator.aspx\" />"));
        }
    }
}