namespace BugLogger.Services.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Web.Http;
    using System.Web.Http.Routing;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Exam.Models;
    using Moq;
    using Bugs.Tests;
    using Exam.Data;
    using Exam.Data.Repositories;

    [TestClass]
    public class BugsControllerTests
    {
        [TestMethod]
        public void GetAllBugsShouldReturnBugsCollection()
        {
            var bugs = this.GenerateBugsCollection();
            var fakeData = new BugFakeData();
            foreach (var bug in bugs)
            {
                fakeData.Bugs.Add(bug);
            }


            //var result = bugsController.All();

            //Assert.AreEqual(bugs.Count, result.Count());

            //CollectionAssert.AreEquivalent(bugs.ToList(), result.ToList());
        }

        [TestMethod]
        public void AddBugWithEmptyDescriptionShouldNotBeAddedToRepository()
        {
        }

        [TestMethod]
        public void AddBugWithNullDescriptionShouldNotBeAddedToRepository()
        {
        }
        private IList<Bug> GenerateBugsCollection()
        {
            var bugs = new List<Bug>()
            {
                new Bug()
                {
                    Id = 1,
                    Text = "bug-1"
                },
                new Bug()
                {
                    Id = 2,
                    Text = "bug-2"
                },
                new Bug()
                {
                    Id = 3,
                    Text = "bug-3"
                }
            };

            return bugs;
        }


    }
}
