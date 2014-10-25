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
        protected IExamData data;

        // TODO: uncomment ninject in Startup.cs and remove this empty constructor
        public BaseController()
            : this(new ExamData())
        {
        }

        public BaseController(IExamData data)
        {
            this.data = data;
        }
    }
}
