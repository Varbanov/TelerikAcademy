using Exam.Data;
using Exam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Exam.WebServices.Models
{
    public class BugsController : BaseController
    {
        // TODO: uncomment ninject in Startup.cs and remove empty contructor
        public BugsController()
            : base(new BugData())
        {
        }


        [HttpGet]
        public IHttpActionResult Get()
        {
            var modelled = this.data.Bugs
                .All()
                .Select(b => new BugModel() 
                { 
                    id = b.Id,
                    LogDate = b.LogDate,
                    Status = b.Status,
                    Text = b.Text
                });

            return Ok(modelled);
        }

        [HttpPost]
        public IHttpActionResult Get(BugModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var bug = new Bug()
            {
                Text = model.Text,
                LogDate = DateTime.Now.Date,
                Status = model.Status,
            };

            this.data.Bugs.Add(bug);
            this.data.SaveChanges();

            model.id = bug.Id;
            model.LogDate = bug.LogDate;

            return Ok(model);
        }

        [HttpGet]
        public IHttpActionResult GetAfterDate(DateTime date)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var modelled = this.data.Bugs
                .All()
                .Where(b => b.LogDate >= date)
                .Select(b => new BugModel()
                {
                    id = b.Id,
                    LogDate = b.LogDate,
                    Status = b.Status,
                    Text = b.Text
                });

            return Ok(modelled);
        }

        [HttpPut]
        public IHttpActionResult Change(BugModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var bug = this.data.Bugs
                .Find(model.id);

            if (bug == null)
            {
                return NotFound();
            }

            bug.Status = model.Status;
            bug.Text = model.Text;
            this.data.SaveChanges();

            model.id = bug.Id;
            return Ok(model);
        }

    }
}
