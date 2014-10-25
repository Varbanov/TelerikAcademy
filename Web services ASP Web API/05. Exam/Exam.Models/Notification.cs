namespace Exam.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Notification
    {
        [Key]
        public int Id { get; set; }
        public string Message { get; set; }
        public DateTime DateCreated { get; set; }
        public NotificationType Type { get; set; }
        public bool IsRead { get; set; }
        public int GameId { get; set; }
        public virtual Game Game { get; set; }

    }
}
