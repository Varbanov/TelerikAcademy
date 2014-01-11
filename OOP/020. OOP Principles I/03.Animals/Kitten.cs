using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Animals
{
    class Kitten : Cat, ISound
    {
        public int Size { get; set; }

        public Kitten(string name, int age, int whiskersLength, int size)
        {
            this.Name = name;
            this.Age = age;
            this.Sex = Sex.female;
            this.WhiskersLength = whiskersLength;
            this.Size = size;
        }

        public override void MakeSound()
        {
            Console.WriteLine("Mrrr");
        }

        public override string GetSpecies()
        {
            return "Kitten";
        }

        public override void Fight()
        {
            Console.WriteLine("I scratch with my claws!");
        }
    }
}
