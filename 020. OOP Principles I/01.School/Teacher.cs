using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.School
{
    class Teacher : Human, ICommentable
    {
        private List<Discipline> disciplines;
        private List<string> comments; 

        //properties
        public List<Discipline> Disciplines
        {
            get { return disciplines; }
        }

        //constructor
        public Teacher(string name)
            : base(name)
        {
            this.disciplines = new List<Discipline>();
            this.comments = new List<string>();
        }

        //methods
        public void AddDiscipline(Discipline discipline)
        {
            //if the teacher does not have the discipline, add it, else skip it
            if (!this.Disciplines.Contains(discipline))
            {
                this.disciplines.Add(discipline);
                Console.WriteLine("{0} added to teacher {1}!", discipline.Name, this.Name);
            }
            else
            {
                Console.WriteLine("Teacher {0} already has {0} included!", this.Name, discipline.Name);
            }
        }

        public void RemoveDiscipline(Discipline discipline)
        {
            if (this.disciplines.Remove(discipline))
            {
                Console.WriteLine("{0} removed from teacher {1}!", discipline.Name, this.Name);
            }
            else
            {
                Console.WriteLine("Teacher {0} doesn't have the discipline {1}!", this.Name, discipline.Name);
            }
        }


        public override string ToString()
        {
            StringBuilder res = new StringBuilder();
            res.Append(this.Name);
            res.Append("\n");
            foreach (var dis in this.Disciplines)
            {
                res.Append(dis.Name);
                res.Append("\n");
            }
            res.Append("---------");
            return res.ToString();
        }

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
    }
}
