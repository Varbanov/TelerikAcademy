using NewsExam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NewsExam
{
    public partial class News : System.Web.UI.Page
    {
        private NewsDbContext dbContext;

        public News()
        {
            this.dbContext = new NewsDbContext();
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
        public IQueryable<Article> ListViewArticles_GetData()
        {
            return this.dbContext.Articles.OrderBy(x => x.Likes.Count).Take(3);
        }

        public IList<Article> GetArticlesByCategory(int Id)
        {
            return this.dbContext.Articles.Where(x => x.CategoryId == Id).OrderBy(x => x.DateCreated).Take(3).ToList();
        }

        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IQueryable<Category> ListViewCategories_GetData()
        {
            return this.dbContext.Categories.OrderBy(x => x.Name);
        }
    }
}