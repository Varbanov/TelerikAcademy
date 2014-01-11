using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.School
{
    class Human
    {
        private string name;

        public string Name
        {
            get { return name; }
            set 
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("Error! The name is either null or empty!");
                else
                    name = value; 
            }
        }

        public Human(string name)
        {
            this.Name = name;
        }

    }
}
