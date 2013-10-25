using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Animals
{
    abstract class Cat : Animal, ISound
    {
        public int WhiskersLength { get; set; }

        //methods
        public abstract void Fight();
    }
}
