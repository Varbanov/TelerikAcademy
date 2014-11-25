using Exam.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.Identity;

using Exam.WebServices.Models;

namespace Exam.WebServices.Controllers
{
    public class ScoresController : BaseController
    {
        private const int CountOfUsers = 10;

        // TODO: uncomment ninject in Startup.cs and remove this empty constructor
        public ScoresController()
            : base(new ExamData())
        {
        }

        public ScoresController(IExamData data)
            : base(data)
        {
        }

        [HttpGet]
        public IHttpActionResult GetTopUsers()
        {
            var users = this.data.Users
                .All()
                .OrderBy(u => u.WonScores * 100 + u.LostScores * 15)
                .Take(CountOfUsers).ToList();

            var modelled = users.Select(u => new ScoreModel()
            {
                Rank = u.WonScores * 100 + u.LostScores * 15,
                Username = u.UserName,
            });

            return Ok(modelled);
        }
    }
}
