namespace ForumSystem.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using AutoMapper.QueryableExtensions;
    using ForumSystem.Data;
    using ForumSystem.Web.ViewModels.PageableFeedbackListView;

    [Authorize]
    public class PageableFeedbackListController : BaseController
    {
        public PageableFeedbackListController(IForumSystemData data)
            : base(data)
        {
        }

        [OutputCache(Duration = 60 * 60)]
        public ActionResult Index()
        {
            var fb = this.Data.Feedbacks.All().Take(4)
                .Project()
                .To<PageableFeedbackListViewModel>()
                .ToList();

            return this.View(fb);
        }
    }
}