using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSystem.Model
{
    public class Homework
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public string FilePath { get; set; }

        public DateTime DeadLine { get; set; }

        public Guid CourseId { get; set; }

        public virtual Course Course { get; set; }

        public int StudentId { get; set; }

        public virtual Student Student { get; set; }

    }
}
