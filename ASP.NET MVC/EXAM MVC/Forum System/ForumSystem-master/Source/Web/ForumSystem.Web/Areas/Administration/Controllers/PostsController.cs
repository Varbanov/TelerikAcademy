namespace ForumSystem.Web.Areas.Administration.Controllers
{
    using System.Web.Mvc;
    using AutoMapper.QueryableExtensions;
    using ForumSystem.Data;
    using ForumSystem.Data.Models;
    using ForumSystem.Web.Areas.Administration.ViewModels;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;

    public class PostsController : BaseController
    {
        public PostsController(IForumSystemData data)
            : base(data)
        {
        }

        [HttpGet]
        public ActionResult Index()
        {
            return this.View();
        }

        [HttpPost]
        public ActionResult Update([DataSourceRequest]DataSourceRequest request, PostViewModel model)
        {
            if (model != null && ModelState.IsValid)
            {
                var post = this.Data.Posts.GetById(model.Id);

                // tinymce shit
                post.Content = Request.Params["title"];
                post.Title = model.Title;
                this.Data.SaveChanges();
            }

            // return result to kendo
            return this.Json(new[] { model }.ToDataSourceResult(request, this.ModelState));
        }

        public ActionResult Create([DataSourceRequest]DataSourceRequest request, PostViewModel model)
        {
            if (model != null)
            {
                var post = new Post()
                {
                    Title = model.Title,

                    // tinymce shit
                    Content = Request.Params["title"],
                    Author = this.UserProfile,
                };

                this.Data.Posts.Add(post);
                this.Data.SaveChanges();
                model.Id = post.Id;
            }

            return this.Json(new[] { model }.ToDataSourceResult(request, this.ModelState));
        }

        public ActionResult Destroy([DataSourceRequest]DataSourceRequest request, PostViewModel model)
        {
            if (model != null && ModelState.IsValid)
            {
                this.Data.Posts.Delete(model.Id);
                this.Data.SaveChanges();
            }

            return this.Json(new[] { model }.ToDataSourceResult(request, this.ModelState));
        }

        [HttpPost]
        public ActionResult GetPosts([DataSourceRequest]DataSourceRequest request)
        {
            var posts = this.Data.Posts.All()
                .Project()
                .To<PostViewModel>()
                .ToDataSourceResult(request, ModelState);

            return this.Json(posts);
        }
    }
}