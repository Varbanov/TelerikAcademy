using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using StudentSystem.Data;
using StudentSystem.Models;

namespace StudentSystem.Web.Controllers
{
    public class TestsController : ApiController
    {
        private StudentSystemDbContext data = new StudentSystemDbContext();

        public IQueryable<Test> GetTests()
        {
            return data.Tests;
        }

        [ResponseType(typeof(Test))]
        public IHttpActionResult GetTest(int id)
        {
            Test test = data.Tests.Find(id);
            if (test == null)
            {
                return NotFound();
            }

            return Ok(test);
        }

        // PUT: api/Tests/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTest(int id, Test test)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != test.Id)
            {
                return BadRequest();
            }

            data.Entry(test).State = EntityState.Modified;

            try
            {
                data.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TestExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Tests
        [ResponseType(typeof(Test))]
        public IHttpActionResult PostTest(Test test)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            data.Tests.Add(test);
            data.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = test.Id }, test);
        }

        // DELETE: api/Tests/5
        [ResponseType(typeof(Test))]
        public IHttpActionResult DeleteTest(int id)
        {
            Test test = data.Tests.Find(id);
            if (test == null)
            {
                return NotFound();
            }

            data.Tests.Remove(test);
            data.SaveChanges();

            return Ok(test);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                data.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TestExists(int id)
        {
            return data.Tests.Count(e => e.Id == id) > 0;
        }
    }
}