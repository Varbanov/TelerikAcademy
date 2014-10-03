using Exam.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Exam.WebServices.Models
{
    public class BugModel
    {
        public int id { get; set; }

        [Required]
        public string Text { get; set; }

        [Required]
        public BugStatus Status { get; set; }

        [Required]
        public DateTime LogDate { get; set; }

    }
}