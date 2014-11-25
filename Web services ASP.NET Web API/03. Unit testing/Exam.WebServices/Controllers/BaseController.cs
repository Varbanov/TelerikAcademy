using Exam.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Exam.WebServices.Controllers
{
    public class BaseController : ApiController
    {
        protected IBugData data;

        // TODO: uncomment ninject in Startup.cs and remove this empty constructor
        public BaseController()
            : this(new BugData())
        {
        }

        public BaseController(IBugData data)
        {
            this.data = data;
        }
    }
}
