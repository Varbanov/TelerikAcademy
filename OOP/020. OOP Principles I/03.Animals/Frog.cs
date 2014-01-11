using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Animals
{
    class Frog : Animal, ISound
    {
        public int greenSpots { get; set; }

        //constructor
        public Frog(string name, int age, Sex sex, int greenSpots)
        {
            this.Name = name;
            this.Age = age;
            this.Sex = sex;
            this.greenSpots = greenSpots;
        }

        //methods
        public override string GetSpecies()
        {
            return "Frog";
        }

        public override void MakeSound()
        {
            Console.WriteLine("Croak!");
        }
    }
}
