using Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Library
{
    public partial class BookDetails : System.Web.UI.Page
    {
        private LibraryDbContext dbContext;
        public BookDetails()
        {
            this.dbContext = new LibraryDbContext();
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // The id parameter should match the DataKeyNames value set on the control
        // or be decorated with a value provider attribute, e.g. [QueryString]int id
        public Book FormViewBookDetails_GetItem([QueryString("id")]int? Id)
        {
            //the same as the shit above
            //string idStr = Request.QueryString["id"];
            //if (idStr == null)
            //{
            //    Response.Redirect("~/");
            //}
            //else
            //{
            //}


            if (Id == null)
            {
                Response.Redirect("~/");
            }

            var book = this.dbContext.Books.FirstOrDefault(b => b.Id == Id);
            return book;
        }
    }
}