using NewsExam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NewsExam.Admin
{
    public partial class EditArticles : System.Web.UI.Page
    {
        private NewsDbContext dbContext;

        public EditArticles()
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
        public IQueryable<Article> ListViewCategories_GetData()
        {
            return this.dbContext.Articles;
        }

        public IQueryable<Category> DropDownCategories_GetData()
        {
            return this.dbContext.Categories;
        }

        

        // The id parameter name should match the DataKeyNames value set on the control
        public void ListViewCategories_UpdateItem(int Id)
        {
            Article item = this.dbContext.Articles.Find(Id);
            // Load the item here, e.g. item = MyDataLayer.Find(id);
            if (item == null)
            {
                // The item wasn't found
                ModelState.AddModelError("", String.Format("Item with id {0} was not found", Id));
                return;
            }
            TryUpdateModel(item);
            if (ModelState.IsValid)
            {
                // Save changes here, e.g. MyDataLayer.SaveChanges();
                this.dbContext.SaveChanges();
            }
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void ListViewCategories_DeleteItem(int Id)
        {
            Article item = this.dbContext.Articles.Find(Id);
            if (item == null)
            {
                return;
            }

            this.dbContext.Articles.Remove(item);
            this.dbContext.SaveChanges();
        }

        public void ListViewCategories_InsertItem()
        {
            var item = new Article();
            TryUpdateModel(item);
            if (ModelState.IsValid)
            {
                var currentuser = this.dbContext.Users.FirstOrDefault(x => x.UserName == HttpContext.Current.User.Identity.Name);
                item.AppUser = currentuser;
                // Save changes here
                this.dbContext.Articles.Add(item);
                this.dbContext.SaveChanges();
            }
        }
    }
}