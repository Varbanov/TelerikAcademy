using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTesting
{
    public class Course
    {
        private List<Student> students;
        private const int MAX_STUDENTS = 30;

        public List<Student> Students
        {
            get { return students; }
            set 
            {
                if (value.Count > MAX_STUDENTS)
                {
                    throw new ArgumentException("The students in the course cannot be more than 30.");
                }

                students = value;
            }
        }

        public Course()
        {
            this.students = new List<Student>();
        }
    }
}
