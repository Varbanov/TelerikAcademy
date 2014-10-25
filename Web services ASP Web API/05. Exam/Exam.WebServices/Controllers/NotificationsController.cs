using Exam.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.Identity;

namespace Exam.WebServices.Models
{
    [Authorize]
    public class NotificationsController : BaseController
    {
        const int defaultPageSize = 10;

        // TODO: uncomment ninject in Startup.cs and remove this empty constructor

        public NotificationsController()
            : base(new ExamData())
        {
        }

        public NotificationsController(IExamData data)
            : base(data)
        {
        }

        [HttpGet]
        public IHttpActionResult GetNotifications()
        {
            return this.Get(0);
        }

        [HttpGet]
        public IHttpActionResult Get(int page)
        { 
            // TODO: refactor extract method
            var currentUserId = this.User.Identity.GetUserId();
              var currentUser = this.data
                .Users
                .All()
                .Where(x => x.Id == currentUserId)
                .FirstOrDefault();

            if (currentUser == null)
            {
                return BadRequest("Invalid user authentication");
            }

            var notifications = currentUser.Notifications
                .Skip(page * defaultPageSize)
                .Take(defaultPageSize);

            foreach (var notification in notifications)
            {
                notification.IsRead = true;
            }

            this.data.SaveChanges();

            var modelled = notifications.Select(n => NotificationModel.FromNotification);


            return Ok(modelled);
        }

        [HttpGet]
        public IHttpActionResult GetOldest()
        {
            // TODO: refactor extract method
            var currentUserId = this.User.Identity.GetUserId();
            var currentUser = this.data
              .Users
              .All()
              .Where(x => x.Id == currentUserId)
              .FirstOrDefault();

            if (currentUser == null)
            {
                return BadRequest("Invalid user authentication");
            }

            var notification = currentUser.Notifications
                .OrderByDescending(x => x.DateCreated)
                .FirstOrDefault();

            if (notification == null)
            {
                return Ok(new NotificationModel[0]);
            }

            notification.IsRead = true;
            this.data.SaveChanges();

            var modelled = new NotificationModel()
            {
                DateCreated = notification.DateCreated,
                GameId = notification.GameId,
                Id = notification.Id,
                Message = notification.Message,
                State = (notification.IsRead == true ? "Read" : "Unread"),
                Type = notification.Type,
            };


            return Ok(modelled);

        }

    }
}
