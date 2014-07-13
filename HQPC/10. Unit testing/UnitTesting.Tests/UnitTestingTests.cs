using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace UnitTesting.Tests
{
    [TestClass]
    public class UnitTestingTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestCourseStudentsCannotExceed30()
        {
            var course = new Course();
            var students = new List<Student>();
            for (int i = 0; i < 31; i++)
            {
                students.Add(new Student("ivan", 10000 + i));
            }
            course.Students = students;
        }



        [TestMethod]
        public void CourseStudenstIsNotNull()
        {
            var course = new Course();
            Assert.IsNotNull(course.Students);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SchoolStudentsDoesNotHaveSameIds()
        {
            var school = new School();
            var course = new Course();
            var student1 = new Student("ivan", 10000);
            var student2 = new Student("pesho", 10000);

            school.AddCourse(course);
            school.AddStudent(course, student1);
            school.AddStudent(course, student2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SchoolRemoveMissingStudenThrowException()
        {
            var student = new Student(" sd", 10000);
            var school = new School();
            var course = new Course();
            school.AddCourse(course);
            school.RemoveStudent(course, student);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void StudentNameCannotBeNull()
        {
            var student = new Student(null, 10000);
        }

        [TestMethod]
        public void SetStudentID()
        {
            var student = new Student("ivan", 10000);
            var id = student.Id;
            Assert.IsTrue(id == 10000);
        }



        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void StudentNameCannotBeEmpty()
        {
            var student = new Student(string.Empty, 10000);
        }

        [TestMethod]
        public void StudentNameSetterSetsNameCorrectly()
        {
            var student = new Student("ivan", 10000);
            student.Name = "pesho";
            Assert.IsTrue("pesho" == student.Name);
        }

        [TestMethod]
        public void CourseAddListOfStudentsWorks()
        {
            var course = new Course();
            var list = new List<Student>();
            list.Add(new Student("a", 10001));
            list.Add(new Student("b", 10002));
            course.Students = list;
            Assert.IsTrue(course.Students.Count == 2);

        }


        [TestMethod]
        public void SchoolAddandRemoveCourse()
        {
            var course = new Course();
            var school = new School();
            school.AddCourse(course);
            Assert.IsTrue(school.RemoveCourse(course));

        }

        [TestMethod]
        public void CourseStudentsListIsNotNull()
        {
            var course = new Course();
            Assert.IsNotNull(course.Students);

        }

        [TestMethod]
        public void SchoolRemoveMissingCourse()
        {
            var course = new Course();
            var school = new School();
            Assert.IsFalse(school.RemoveCourse(course));
        }
    }
}
