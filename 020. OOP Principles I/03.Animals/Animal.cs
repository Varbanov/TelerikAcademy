using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Animals
{
    public abstract class Animal : ISound
    {
        //fields
        public string Name { get; set; }
        public int Age { get; set; }
        public Sex Sex { get; set; }

        //methods
        public static int CalcAverageAge(Animal[] animalArray)
        {
            int sum = 0;
            int count = animalArray.Length;
            foreach (var item in animalArray)
	        {
                sum += item.Age;
	        }
            return sum / count;
        }

        public void SayAge()
        {
            Console.WriteLine("I am {0} and I am {1} years old.", this.GetSpecies(), this.Age);
        }

        public abstract string GetSpecies();

        public abstract void MakeSound();
    }
}
