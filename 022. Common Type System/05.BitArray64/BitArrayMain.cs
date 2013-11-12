using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.BitArray64
{
    class BitArrayMain
    {
        //Define a class BitArray64 to hold 64 bit values inside an ulong value. Implement IEnumerable<int> and Equals(…), GetHashCode(), [], == and !=.

        static void Main()
        {
            BitArray64 p = new BitArray64(7);

            foreach (var item in p)
            {
                Console.Write(item);
            }

            Console.WriteLine("----------");
            Console.WriteLine(p[63]);
        }
    }
}
