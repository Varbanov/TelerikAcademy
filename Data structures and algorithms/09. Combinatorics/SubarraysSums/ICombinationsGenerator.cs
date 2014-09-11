using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubarraysSums
{
    interface ICombinationsGenerator<T>
    {
        void Generate();
        void Action(T[] combination);
    }
}
