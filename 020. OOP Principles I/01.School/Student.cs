using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.School
{
    class Student : Human, ICommentable
    {
        public string ID { get; set; }
        private List<string> comments;

        public Student(string name, string id) 
            : base(name)
        {
            this.ID = id;
            this.comments = new List<string>();
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
