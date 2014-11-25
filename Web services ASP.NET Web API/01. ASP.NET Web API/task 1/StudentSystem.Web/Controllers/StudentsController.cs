namespace StudentSystem.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;

    using StudentSystem.Data;
    using StudentSystem.Web.Models;
    using StudentSystem.Models;

    public class StudentsController : ApiController
    {
        private StudentsSystemData data = new StudentsSystemData();

        public StudentsController()
            :this(new StudentsSystemData())
        {
        }

        public StudentsController(StudentsSystemData studentsSystemData)
        {
            this.data = studentsSystemData;
        }

        [HttpGet]
        public IHttpActionResult All()
        {
            var students = this.data
                .Students
                .All()
                .Select(StudentModel.FromStudent);

            return this.Ok(students);
        }

        [HttpGet]
        public IHttpActionResult ById(int id)
        {
            var student = this.data
                .Students
                .All()
                .Where(s => s.StudentIdentification == id)
                .Select(StudentModel.FromStudent)
                .FirstOrDefault();

            if (student == null)
            {
                return this.BadRequest("Student does not exist");
            }

            return this.Ok(student);
        }

        [HttpPost]
        public IHttpActionResult Create(StudentModel student)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(ModelState);
            }

            var newStudent = new Student()
            {
                FirstName = student.FirstName,
                LastName = student.LastName,
            };

            this.data.Students.Add(newStudent);
            this.data.SaveChanges();

            student.Id = newStudent.StudentIdentification;
            return Ok(student);
        }

        [HttpPut]
        public IHttpActionResult Update(int id, StudentModel student)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(ModelState);
            }

            var existingStudent = this.data
                .Students
                .All()
                .FirstOrDefault(s => s.StudentIdentification == id);

            if (existingStudent == null)
            {
                return this.BadRequest("No such student found!");
            }

            existingStudent.FirstName = student.FirstName;
            existingStudent.LastName = student.LastName;
            this.data.SaveChanges();

            student.Id = existingStudent.StudentIdentification;
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
