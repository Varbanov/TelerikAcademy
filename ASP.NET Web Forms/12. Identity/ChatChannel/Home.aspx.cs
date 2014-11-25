using ChatChannel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ChatChannel
{
    public partial class Home : System.Web.UI.Page
    {

        private ApplicationDbContext dbContext;

        public Home()
        {
            this.dbContext = new ApplicationDbContext();
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IQueryable Meesageslv_GetData()
        {
            return this.dbContext.Messages.OrderByDescending(x => x.DateCreated);
        }
    }
}