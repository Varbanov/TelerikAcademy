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
    public class HomeworksController : ApiController
    {
         private StudentsSystemData data = new StudentsSystemData();

        public HomeworksController()
            :this(new StudentsSystemData())
        {
        }

        public HomeworksController(StudentsSystemData studentsSystemData)
        {
            this.data = studentsSystemData;
        }

        [HttpGet]
        public IHttpActionResult All()
        {
            var homeworks = this.data
                .Homeworks
                .All()
                .Select(HomeworkModel.FromHomework);

            return this.Ok(homeworks);
        }

        [HttpGet]
        public IHttpActionResult ById(int id)
        {
            var homework = this.data
                .Homeworks
                .All()
                .Where(h => h.Id == id)
                .Select(HomeworkModel.FromHomework)
                .FirstOrDefault();

            if (homework == null)
            {
                return this.BadRequest("Student does not exist");
            }

            return this.Ok(homework);
        }

        [HttpPost]
        public IHttpActionResult Create(HomeworkModel homework)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(ModelState);
            }

            var newHw = new Homework()
            {
                FileUrl = homework.FileUrl,
                Student = new Student() { FirstName = homework.StudentFirstName, LastName = homework.StudentLastName },
                TimeSent = DateTime.Now,
                CourseId = homework.CourseId,
            };

            this.data.Homeworks.Add(newHw);
            this.data.SaveChanges();

            homework.Id = newHw.StudentIdentification;
            return Ok(homework);
        }

        [HttpPut]
        public IHttpActionResult Update(int id, HomeworkModel homework)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(ModelState);
            }

            var existingHw = this.data
                .Homeworks
                .All()
                .FirstOrDefault(h => h.Id == id);

            if (existingHw == null)
            {
                return this.BadRequest("No such homework found!");
            }

            existingHw.FileUrl = homework.FileUrl;
            existingHw.Student.FirstName = homework.StudentFirstName;
            existingHw.Student.LastName = homework.StudentLastName;

            this.data.SaveChanges();

            homework.Id = existingHw.StudentIdentification;
            return this.Ok(homework);
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var existingHw = this.data.Homeworks
                .All()
                .FirstOrDefault(h => h.Id == id);

            if (existingHw == null)
            {
                return this.BadRequest("No such homework found!");
            }

            this.data.Homeworks.Delete(existingHw);
            this.data.SaveChanges();
            return this.Ok();
        }


    }
}
