using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewsExam.Models
{
    public class Article
    {
        private ICollection<Like> likes;

        public Article()
        {
            this.likes = new HashSet<Like>();
            this.DateCreated = DateTime.Now;
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public string AppUserId { get; set; }
        public virtual AppUser AppUser { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public virtual ICollection<Like> Likes
        {
            get { return this.likes; }
            set { this.likes = value; }
        }
        public DateTime DateCreated { get; set; }

    }
}