﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Library.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Isbn { get; set; }
        public string WebSite { get; set; }
        public int CategoryId { get; set; }
        public string Author { get; set; }

        public virtual Category Category { get; set; }

    }
}
