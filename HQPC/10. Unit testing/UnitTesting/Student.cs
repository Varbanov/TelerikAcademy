using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTesting
{
    public class Student
    {
        private string name;
        private int id;

        private const int minId = 10000;
        private const int maxId = 99999;


        public Student(string name, int id)
        {
            this.Name = name;
            this.Id = id;
        }

        public int Id
        {
            get { return id; }
            set
            {
                if (value < minId || value > maxId)
                {
                    throw new ArgumentException("Student Id must be between 10000 and 99999");
                }
                id = value;
            }
        }

        public string Name
        {
            get { return this.name; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name is either null or empty");
                }

                this.name = value;
            }
        }
    }
}
