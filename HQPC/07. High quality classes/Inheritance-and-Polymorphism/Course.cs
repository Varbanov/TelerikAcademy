namespace InheritanceAndPolymorphism
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public abstract class Course
    {
        private string name;
        private string teacherName;
        private IList<string> students;

        public Course(string name, string teacherName, IList<string> students)
        {
            this.Name = name;
            this.TeacherName = teacherName;
            this.Students = students;
        }

        public IList<string> Students
        {
            get 
            { 
                return this.students; 
            }

            set 
            {
                if (value == null)
                {
                    throw new ArgumentException("Students cannot be null");
                }

                this.students = value; 
            }
        }

        public string TeacherName
        {
            get 
            {
                return this.teacherName; 
            }

            set 
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("The teacher name is either null or empty.");
                }

                this.teacherName = value; 
            }
        }
        
        public string Name
        {
            get
            {
                return this.name; 
            }

            set 
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("The name is either null or empty.");
                }

                this.name = value; 
            }
        }

        protected string GetStudentsAsString()
        {
            if (this.Students == null || this.Students.Count == 0)
            {
                return "{ }";
            }
            else
            {
                return "{ " + string.Join(", ", this.Students) + " }";
            }
        }
    }
}
