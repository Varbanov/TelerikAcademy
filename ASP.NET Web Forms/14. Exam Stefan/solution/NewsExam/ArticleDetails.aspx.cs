using NewsExam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NewsExam
{
    public partial class ArticleDetails : System.Web.UI.Page
    {
        private NewsDbContext dbContext;

        public ArticleDetails()
        {
            this.dbContext = new NewsDbContext();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.IsAuthenticated)
            {
                var id = Request.Params["id"];
                if (id == null)
                {
                    Response.Redirect("~Home.aspx");
                }
                else
                {
                    var theId = int.Parse(id);
                    Response.Redirect(string.Format("~/Admin/LoggedArticleDetails.aspx?id={0}", theId));
                }
            }
        }

        public int GetLikes(Article item)
        {
            var totalValue = 0;
            foreach (var like in item.Likes)
            {
                totalValue += like.Value;
            }

            return totalValue;
        }

        // The id parameter should match the DataKeyNames value set on the control
        // or be decorated with a value provider attribute, e.g. [QueryString]int id
        public Article FormViewArticleDetails_GetItem([QueryString("id")] int? Id)
        {
            if (Id == null)
            {
                Response.Redirect("~Home.aspx");
            }

            var article = this.dbContext.Articles.FirstOrDefault(x => x.Id == Id);
            return article;
        }
    }
}