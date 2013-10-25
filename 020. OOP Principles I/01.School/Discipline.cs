using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.School
{
    class Discipline : ICommentable
    {
        private string name;
        private int numOfLectures;
        private int numOfExercises;
        private List<string> comments;

        //properties
        public string Name
        {
            get { return name; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("Error! The name of discipline is either null or empty!");
                else
                    name = value;
            }
        }

        public int NumOfLectures
        {
            get { return numOfLectures; }
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("Error! The number of lectures must be positive!");
                else
                    numOfLectures = value;
            }
        }

        public int NumOfExercises
        {
            get { return numOfExercises; }
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("Error! The number of exercises must be positive!");
                else
                    numOfExercises = value;
            }
        }

        //constructor
        public Discipline(string name, int lectures, int exercises)
        {
            this.Name = name;
            this.numOfLectures = lectures;
            this.NumOfExercises = exercises;
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
