using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyEcosystem
{
    public class Woof : Animal, ICarnivore
    {
        public Woof(string name, Point location)
            : base(name, location, 4)
        { 
        }

        public int TryEatAnimal(Animal animal)
        {
            if (animal != null && (animal.Size <= this.Size || animal.State ==                  AnimalState.Sleeping))
            {
                return animal.GetMeatFromKillQuantity();
            }
            else 
                return 0;
        }
    }
}
