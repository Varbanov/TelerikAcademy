using _02.Employees.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _02.Employees
{
    public partial class Employees : System.Web.UI.Page
    {
        NorthwindEntities db = new NorthwindEntities();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var employees = db.Employees.Select(x => new
                {
                    EmployeeID = x.EmployeeID,
                    FirstName = x.FirstName,
                    LastName = x.LastName
                }).ToList();

                this.EmployeesGridView.DataSource = employees;
                this.EmployeesGridView.DataBind();
            }
        }

        protected void EmployeesGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            var employees = db.Employees.Select(x => new
            {
                EmployeeID = x.EmployeeID,
                FirstName = x.FirstName,
                LastName = x.LastName
            }).ToList();

            this.EmployeesGridView.PageIndex = e.NewPageIndex;
            this.EmployeesGridView.DataSource = employees;
            this.EmployeesGridView.DataBind();
        }

    }
}