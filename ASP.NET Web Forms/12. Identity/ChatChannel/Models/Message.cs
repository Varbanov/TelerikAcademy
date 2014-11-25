using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChatChannel.Models
{
    public class Message
    {
        public int Id { get; set; }
        public Message()
        {
            this.DateCreated = DateTime.Now;
        }
        public string Content { get; set; }
        public DateTime DateCreated { get; set; }
        public ApplicationUser User { get; set; }
    }
}