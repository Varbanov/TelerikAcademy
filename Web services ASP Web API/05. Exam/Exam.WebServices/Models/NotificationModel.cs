using Exam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace Exam.WebServices.Models
{
    public class NotificationModel
    {
        public static Expression<Func<Notification, NotificationModel>> FromNotification
        {
            get
            {
                return m => new NotificationModel
                {
                    Id = m.Id,
                    DateCreated = m.DateCreated,
                    GameId = m.GameId,
                    Message = m.Message,
                    State = (m.IsRead == true? "Read" : "Unread"),
                    Type = m.Type,
                };
            }
        }

        public int Id { get; set; }
        public string Message { get; set; }
        public DateTime DateCreated { get; set; }
        public NotificationType Type { get; set; }
        public string State { get; set; }
        public int GameId { get; set; }

    }
}