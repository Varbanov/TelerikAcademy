using _02.Employees.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _02.Employees
{
    public partial class Details : System.Web.UI.Page
    {
        private NorthwindEntities db = new NorthwindEntities();


        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Params["id"] == null)
            {
                this.Response.Redirect("Employees.aspx");
            }

            int searchedId;
            var idIsCorrect = int.TryParse(Request.Params["id"], out searchedId);
            if (!idIsCorrect)
            {
                this.Response.Redirect("Employees.aspx");                
            }

            var employee = this.db.Employees.FirstOrDefault(x => x.EmployeeID == searchedId);
            if (employee == null)
            {
                this.Response.Redirect("Employees.aspx");                
            }

            var source = new List<Employee>();
            source.Add(employee);
            this.DetailsView.DataSource = source;
            this.DetailsView.DataBind();

        }

        protected void OnBackBtnClicked(object sender, EventArgs e)
        {
            this.Response.Redirect("Employees.aspx");
        }
    }
}