using StudentSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace StudentSystem.Web.Models
{
    public class HomeworkModel
    {
        public static Expression<Func<Homework, HomeworkModel>> FromHomework
        {
            get
            {
                return s => new HomeworkModel
                {
                    FileUrl = s.FileUrl,
                    StudentFirstName = s.Student.FirstName,
                    CourseId = s.CourseId,
                };
            }
        }

        public string FileUrl { get; set; }

        public string StudentFirstName { get; set; }

        public string StudentLastName { get; set; }

        public Guid CourseId { get; set; }

        public int Id { get; set; }
    }
}