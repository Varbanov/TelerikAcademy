using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.School
{
    class SchoolClass :ICommentable
    {
        //fields
        private List<Teacher> Teachers;
        private List<Student> Students;
        public string ID { get; set; }
        private List<string> comments;

        //constructors
        public SchoolClass(string id)
        {
            this.ID = id;
            this.Teachers = new List<Teacher>();
            this.Students = new List<Student>();
            this.comments = new List<string>();
        }

        public SchoolClass(string id, List<Student> students, List<Teacher> teachers)
            : this(id)
        {
            this.Students = students;
            this.Teachers = teachers;
            this.comments = new List<string>();
        }

        //methods

        //implement ICommentable
        public void AddComment(string comment)
        {
            this.comments.Add(comment);
        }

        public void ViewComments()
        {
            foreach (var comment in this.comments)
            {
                Console.WriteLine(comment);
            }
        }


        public void AddStudent(Student student)
        {
            if (!this.Students.Contains(student))
            {
                this.Students.Add(student);
                Console.WriteLine("Student {0} added to class {1}!", student.Name, this.ID);
            }
            else
            {
                Console.WriteLine("Student {0} is already a member of the clas {1}!", student.Name, this.ID);
            }
        }

        public void ExpelStudent(Student student)
        {
            if (this.Students.Contains(student))
            {
                this.Students.Remove(student);
                Console.WriteLine("The student {0} is expelled from class {1}", student.Name, this.ID);
            }
            else
            {
                Console.WriteLine("The student {0} does not belong to the class {1}", student.Name, this.ID);
            }
        }

        public void PrintStudents()
        {
            foreach (var st in this.Students)
            {
                Console.WriteLine("{0} - {1}", st.Name, st.ID);
            }
        }

        public void AddTeacher(Teacher teacher)
        {
            if (!this.Teachers.Contains(teacher))
            {
                this.Teachers.Add(teacher);
                Console.WriteLine("Teacher {0} added to class {1}!", teacher.Name, this.ID);
            }
            else
            {
                Console.WriteLine("Teacher {0} is already a member of the clas {1}!", teacher.Name, this.ID);
            }
        }

        public void RemoveTeacher(Teacher teacher)
        {
            if (this.Teachers.Contains(teacher))
            {
                this.Teachers.Remove(teacher);
                Console.WriteLine("Teacher {0} removed from class {1}", teacher.Name, this.ID);
            }
            else
            {
                Console.WriteLine("The teacher {0} does not teach the class {1}", teacher.Name, this.ID);
            }
        }

        public void PrintTeachers()
        {
            foreach (Teacher te in this.Teachers)
            {
                Console.WriteLine(te.ToString());
            }
        }
    }
}
