using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Animals
{
    class AnimalsMain
    {
        /*03.Create a hierarchy Dog, Frog, Cat, Kitten, Tomcat and define useful constructors and methods.
         * Dogs, frogs and cats are Animals. All animals can produce sound (specified by the ISound interface).
         * Kittens and tomcats are cats. All animals are described by age, name and sex. Kittens can be only 
         * female and tomcats can be only male. Each animal produces a specific sound. Create arrays of different
         * kinds of animals and calculate the average age of each kind of animal using a static method (you may use LINQ).
        */

        private static Tomcat[] InstantiateTomcats()
        {
            Tomcat[] tomcats = new Tomcat[10];
            for (int i = 0; i <= 5; i++)
            {
                tomcats[i] = new Tomcat("Tommy", 2, 8, 20);
            }
            for (int i = 6; i < 10; i++)
            {
                tomcats[i] = new Tomcat("Marcho", 3, 11, 23);
            }
            return tomcats;
        }

        private static Dog[] InstantiateDogs()
        {
            Dog[] dogs = new Dog[10];
            for (int i = 0; i <= 5; i++)
            {
                dogs[i] = new Dog("Joe", 4, Sex.male, FurColour.black);
            }
            for (int i = 6; i < 10; i++)
            {
                dogs[i] = new Dog("Sharo", 13, Sex.female, FurColour.white);
            }
            return dogs;
        }

        static void Main()
        {
            //some tests
            Dog d = new Dog("Joe", 4, Sex.male, FurColour.black);
            d.MakeSound();
            Console.WriteLine(d.GetSpecies());
            d.Bite();
            Console.WriteLine("----------------------");

            Kitten k = new Kitten("Kittie", 5, 10, 10);
            k.MakeSound();
            Console.WriteLine(k.GetSpecies());
            k.SayAge();
            k.Fight();
            Console.WriteLine("----------------------");

            Tomcat t = new Tomcat("Tommie", 3, 15, 25);
            Console.WriteLine(t.GetSpecies());
            t.SayAge();
            t.Fight();
            t.MakeSound();
            Console.WriteLine("----------------------");

            Frog f = new Frog("Froggy", 1, Sex.male, 3);
            Console.WriteLine(f.GetSpecies());
            Console.WriteLine("Froggy has {0} green spots", f.greenSpots);
            f.SayAge();
            f.MakeSound();
            Console.WriteLine("----------------------");

            //instantiate arrays of dogs and tomcats
            Dog[] dogs = InstantiateDogs();
            Tomcat[] tomcats = InstantiateTomcats();

            //calculate average age
            Console.WriteLine("Average age of dogs: {0}", Animal.CalcAverageAge(dogs));
            Console.WriteLine("Average age of tomcats: {0}", Animal.CalcAverageAge(tomcats));

        }
    }
}
