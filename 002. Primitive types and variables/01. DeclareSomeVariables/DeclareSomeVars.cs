
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class DeclareSomeVars
{
    /* Declare five variables choosing for each of them the most appropriate of the types byte, sbyte, short, ushort, 
     * int, uint, long, ulong to represent the following values: 52130, -115, 4825932, 97, -10000.
    */
    static void Main()
    {
        ushort ushortVar = 52130;
        sbyte sbyteVar = -115;
        int intVar = 4825932;
        byte byteVar = 97;
        short shortVar = -10000;

        Console.WriteLine("{0}, {1}, {2}, {3}, {4}", ushortVar, sbyteVar, intVar, byteVar, shortVar);
    }
}

