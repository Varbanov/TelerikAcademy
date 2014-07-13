using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTesting
{
    public class School
    {
        private List<Course> courses;

        public School()
        {
            this.courses = new List<Course>();
        }

        public void AddStudent(Course course, Student student)
        {
            if (!this.courses.Contains(course))
            {
                throw new ArgumentException("No such course in school");
            }

            for (int i = 0; i < this.courses.Count; i++)
            {
                var currentCourse = this.courses[i];
                for (int j = 0; j < currentCourse.Students.Count; j++)
                {
                    if (student.Id == currentCourse.Students[j].Id)
                    {
                        throw new ArgumentException("There is already a student with the same id in the school");
                    }
                }
            }

            this.courses.Find((x) => x == course).Students.Add(student);

        }

        public void RemoveStudent(Course course, Student student)
        {
            if (!this.courses.Contains(course))
            {
                throw new ArgumentException("No such course in school");
            }

            var schoolCourse = this.courses.Find((x) => x == course);

            if (!schoolCourse.Students.Remove(student))
            {
                throw new ArgumentException("No such student in course");
            }
        }

        public void AddCourse(Course course)
        {
            this.courses.Add(course);
        }

        public bool RemoveCourse(Course course)
        {
            return this.courses.Remove(course);
        }
    }
}
