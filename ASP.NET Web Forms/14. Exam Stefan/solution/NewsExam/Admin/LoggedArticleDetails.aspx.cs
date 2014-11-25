using NewsExam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NewsExam.Admin
{
    public partial class LoggedArticleDetails : System.Web.UI.Page
    {
        private NewsDbContext dbContext;

        public LoggedArticleDetails()
        {
            this.dbContext = new NewsDbContext();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        public int GetLikes(Article item)
        {
            var totalValue = 0;
            foreach (var like in item.Likes)
            {
                totalValue += 1;
            }

            return totalValue;
        }

        // The id parameter should match the DataKeyNames value set on the control
        // or be decorated with a value provider attribute, e.g. [QueryString]int id
        public Article FormViewArticleDetails_GetItem([QueryString("id")] int? Id)
        {

            var article = this.dbContext.Articles.FirstOrDefault(x => x.Id == Id);
            return article;
        }

        protected void VoteUp_Click(object sender, EventArgs e)
        {
            var id = Request.Params["id"];
            if (id == null)
            {
                return;
            }
            else
            {
                var theId = int.Parse(id);
                var article = this.dbContext.Articles.Find(theId);
                article.Likes.Add(new Like());
                this.dbContext.SaveChanges();
            }
        }

        protected void VoteDown_Click(object sender, EventArgs e)
        {
            var id = Request.Params["id"];
            if (id == null)
            {
                return;
            }
            else
            {
                var theId = int.Parse(id);
                var article = this.dbContext.Articles.Find(theId);
                
                //article.Likes.Remove;
                this.dbContext.SaveChanges();
            }
        }
    }
}