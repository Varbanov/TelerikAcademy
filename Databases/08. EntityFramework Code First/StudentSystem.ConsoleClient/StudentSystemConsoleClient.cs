using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSystem.ConsoleClient
{
    using StudentSystem.Data;
    using StudentSystem.Data.Migrations;
    using StudentSystem.Model;
    using System.Data.Entity;

    public class StudentSystemConsoleClient
    {
        static void Main()
        {

            var db = new StudentSystemDbContext();

            var student = new Student
            {
                FirstName = "Elena",
                LastName = "Dimirova",
                StudentStatus = StudentStatus.Online,
            };

            db.Students.Add(student);
            db.SaveChanges();
            var course = new Course()
            {
                Name = "Math",
            };

            db.Courses.Add(course);
            db.SaveChanges();

            Console.WriteLine(db.Students.First().FirstName);

        }
    }
}
