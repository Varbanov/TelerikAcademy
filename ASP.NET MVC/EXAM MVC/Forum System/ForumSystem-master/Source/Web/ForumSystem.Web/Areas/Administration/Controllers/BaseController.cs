namespace ForumSystem.Web.Areas.Administration.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using ForumSystem.Data;

    [Authorize]
    public class BaseController : ForumSystem.Web.Controllers.BaseController
    {
        public BaseController(IForumSystemData data)
            : base(data)
        {
        }
    }
}