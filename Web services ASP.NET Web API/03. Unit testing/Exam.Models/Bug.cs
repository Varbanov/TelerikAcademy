namespace Exam.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Bug
    {
        public Bug()
        {
            this.Status = BugStatus.Pending;
        }

        [Key]
        public int Id { get; set; }

        public BugStatus Status { get; set; }

        public DateTime LogDate { get; set; }

        public string Text { get; set; }

    }
}
