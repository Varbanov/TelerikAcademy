using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Workers
{
    class Student : Human
    {
        private int grade;

        public int Grade
        {
            get { return grade; }
            set
            {
                if (value > 0 && value <= 12)
                    grade = value;
                else
                    throw new ArgumentOutOfRangeException("The grade must be a value in the range [1..12]");
            }
        }

        public Student(string firstName, string lastName, int grade)
            : base(firstName, lastName)
        {
            this.Grade = grade;
        }
    }
}
