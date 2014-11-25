namespace ForumSystem.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using ForumSystem.Data;
    using ForumSystem.Data.Models;
    using ForumSystem.Web.ViewModels.Feedback;

    public class FeedbackController : BaseController
    {
        public FeedbackController(IForumSystemData data)
            : base(data)
        {
        }

        [HttpGet]
        public ActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AddFeedBackViewModel model)
        {
            if (ModelState.IsValid)
            {
                Feedback fb = new Feedback();
                Mapper.Map(model, fb);

                fb.Author = this.UserProfile;

                this.Data.Feedbacks.Add(fb);
                this.Data.SaveChanges();

                this.TempData["Notification"] = "Feedback successfully sent";
                return this.Redirect("/");
            }

            return this.View(model);
        }
    }
}