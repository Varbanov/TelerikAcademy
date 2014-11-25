using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NewsExam.Models
{
    public class Like
    {
        public int Id { get; set; }
        public int Value { get; set; }

        public virtual AppUser Author { get; set; }
    }
}
