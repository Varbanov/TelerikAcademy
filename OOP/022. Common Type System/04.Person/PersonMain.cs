using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Person
{
    class PersonMain
    {
        //Create a class Person with two fields – name and age. Age can be left unspecified (may contain null value. 
        //Override ToString() to display the information of a person and if age is not specified – to say so. 
        //Write a program to test this functionality.

        static void Main()
        {
            Person p = new Person("Nadya");
            Console.WriteLine(p.ToString());
        }
    }
}
