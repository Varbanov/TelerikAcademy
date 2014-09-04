using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSystem.Model
{
    public class Course
    {
        private ICollection<Student> students;
        private ICollection<Homework> homeworks;

        public string Description { get; set; }

        public ICollection<Homework> Homeworks
        {
            get { return this.homeworks; }
            set { this.homeworks = value; }
        } 
        
        public Course()
        {
            this.Id = Guid.NewGuid();
            this.students = new HashSet<Student>();
            this.homeworks = new HashSet<Homework>();
        }

        public ICollection<Student> Students
        {
            get { return this.students; }
            set { this.students = value; }
        }

        public Guid Id { get; set; }

        public string Name { get; set; }
         
    }
}
