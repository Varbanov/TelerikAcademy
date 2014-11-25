using Library.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Library
{
    public partial class Search : System.Web.UI.Page
    {
        public LibraryDbContext dbContext;

        public Search()
        {
            dbContext = new LibraryDbContext();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.LiteralSarchQuery.Text = Request.QueryString["q"];

        }

        public IQueryable<Book> RepeaterBooks_GetData([QueryString("q")] string query)
        {
            var books = this.dbContext.Books.Where(b => b.Author.Contains(query) ||
                b.Title.Contains(query));
            return books;
        }

        protected string GetTitle(Book book)
        {
            return string.Format("“{0}” <i>by {1}</i>", Server.HtmlEncode(book.Title), Server.HtmlEncode(book.Author));
        }
    }
}