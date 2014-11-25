using StudentSystem.Data;
using StudentSystem.Models;
using StudentSystem.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace StudentSystem.Web.Controllers
{
    public class CoursesController : ApiController
    {
        private StudentsSystemData data = new StudentsSystemData();

        public CoursesController()
            : this(new StudentsSystemData())
        {
        }

        public CoursesController(StudentsSystemData studentsSystemData)
        {
            this.data = studentsSystemData;
        }

        [HttpGet]
        public IHttpActionResult All()
        {
            var courses = this.data
                .Courses
                .All()
                .Select(CourseModel.FromCourse);

            return this.Ok(courses);
        }

        [HttpGet]
        public IHttpActionResult ById(Guid id)
        {
            var course = this.data
                .Courses
                .All()
                .Where(s => s.Id == id)
                .Select(CourseModel.FromCourse)
                .FirstOrDefault();

            if (course == null)
            {
                return this.BadRequest("Student does not exist");
            }

            return this.Ok(course);
        }

        [HttpPost]
        public IHttpActionResult Create(CourseModel course)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(ModelState);
            }

            var newStudent = new Course()
            {
                Description = course.Description,
                Name = course.Name,
            };

            this.data.Courses.Add(newStudent);
            this.data.SaveChanges();

            return Ok(course);
        }

        [HttpPut]
        public IHttpActionResult Update(Guid id, CourseModel student)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(ModelState);
            }

            var existingStudent = this.data
                .Courses
                .All()
                .FirstOrDefault(s => s.Id == id);

            if (existingStudent == null)
            {
                return this.BadRequest("No such student found!");
            }

            existingStudent.Name = student.Name;
            existingStudent.Description = student.Description;
            this.data.SaveChanges();

            return this.Ok(student);
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var existingStudent = this.data.Students
                .All()
                .FirstOrDefault(s => s.StudentIdentification == id);

            if (existingStudent == null)
            {
                return this.BadRequest("No such student found!");
            }

            this.data.Students.Delete(existingStudent);
            this.data.SaveChanges();
            return this.Ok();
        }

    }
}
