using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Bank
{
    class Individual : Customer
    {
        private int age;
        public Gender Gender { get; set; }

        public int Age
        {
            get { return age; }
            set
            {
                if (value < 1 || value > 125)
                    throw new ArgumentException("The age must be between 1 and 125");
                else
                    age = value;
            }
        }

        internal Gender Gender1
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }
        
        public Individual(string name, string id, int age, Gender gender)
            : base(name, id)
        {
            this.Age = age;
            this.Gender = gender;
        }

    }
}
