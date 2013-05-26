using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class NullableNumVars
{
    /*Create a program that assigns null values to an integer and to double variables. 
     * Try to print them on the console, try to add some values or the null literal to them and see the result.
    */
    static void Main()
    {
        int? nullInt = null;
        double? nullDouble = null;

        Console.WriteLine("Null Int:{0}\nNull double:{1}", nullInt, nullDouble);

        nullInt += 5;
        Console.WriteLine("Null + 5: {0}", nullInt);
    }
}

