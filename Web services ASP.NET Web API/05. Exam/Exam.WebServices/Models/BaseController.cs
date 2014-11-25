using Exam.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Exam.WebServices.Models
{
    public class BaseController : ApiController
    {
        protected IExamData data;

        public BaseController(IExamData data)
        {
            this.data = data;
        }

    }
}
