using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Person
{
    class Person
    {
        //Create a class Person with two fields – name and age. Age can be left unspecified (may contain null value. 
        //Override ToString() to display the information of a person and if age is not specified – to say so. 
        //Write a program to test this functionality.

        //fields
        public string Name { get; set; }
        public int? Age { get; set; }

        public Person(string name, int? age = null)
        {
            this.Name = name;
            this.Age = age;
        }

        public override string ToString()
        {
            StringBuilder res = new StringBuilder();
            res.Append(String.Format("Name: {0}", this.Name));
            if (this.Age != null)
            {
                res.Append(String.Format("Age: {0}", this.Age));
            }
            else
            {
                res.Append("\nAge: N/A");
            }

            return res.ToString();
        }
    }
}
