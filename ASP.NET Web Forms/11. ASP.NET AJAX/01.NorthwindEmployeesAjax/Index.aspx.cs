using _01.NorthwindEmployeesAjax.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _01.NorthwindEmployeesAjax
{
    public partial class Index : System.Web.UI.Page
    {
        private NorthwindEntities db;

        protected void Page_Init(object sender, EventArgs e)
        {
            this.db = new NorthwindEntities();
        }

        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IQueryable<Employees> EmployeesGridView_GetData()
        {
            return this.db.Employees;
        }

        protected void EmployeesGridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedEmployeeId = (int) this.EmployeesGridView.SelectedValue;
            Thread.Sleep(5000);
            this.OrdersGridView.DataSource = this.db.Orders.Where(x => x.EmployeeID == selectedEmployeeId).ToList();
            this.OrdersGridView.DataBind();
        }
    }
}