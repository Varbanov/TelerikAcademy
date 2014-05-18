using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Animal
{
    enum Gender { Male, Female };

    class Person
    {
        public Gender Gender { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }

    public void CreatePerson(int age)
    {
        Person person = new Person();
        person.Age = age;
        if (age % 2 == 0)
        {
            person.Name = "Батката";
            person.Gender = Gender.Male;
        }
        else
        {
            person.Name = "Мацето";
            person.Gender = Gender.Female;
        }
    }
}

