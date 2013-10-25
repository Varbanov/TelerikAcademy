using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Animals
{
    class Dog : Animal, ISound
    {
        //fields and properties
        private FurColour FurColour {get; set;}

        //constructor
        public Dog(string name, int age, Sex sex, FurColour furColour)
        {
            this.Name = name;
            this.Age = age;
            this.Sex = sex;
            this.FurColour = furColour;
        }

        //methods
        //abstract method implementation
        public override string GetSpecies()
        {
            return "Dog";
        }
        //interface implementation
        public override void MakeSound()
        {
            Console.WriteLine("Bauuuu!");
        }

        public void Bite()
        {
            Console.WriteLine("You are bitten by {0}!", this.Name);
        }
    }
}
