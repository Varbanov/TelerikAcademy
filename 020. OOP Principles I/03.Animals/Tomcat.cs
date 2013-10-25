using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Animals
{
    class Tomcat : Cat, ISound
    {
        //field
        public int TailLength { get; set; }

        //constructor
        public Tomcat(string name, int age, int whiskersLength, int tailLength)
        {
            this.Name = name;
            this.Age = age;
            this.Sex = Sex.male;
            this.WhiskersLength = whiskersLength;
            this.TailLength = tailLength;
        }

        //methods
        public override void MakeSound()
        {
            Console.WriteLine("Myauuu!");
        }

        public override string GetSpecies()
        {
            return "Tomcat";
        }

        //implement abstract method Fight
        public override void Fight()
        {
            Console.WriteLine("I scratch and bite!");
        }
    }
}
