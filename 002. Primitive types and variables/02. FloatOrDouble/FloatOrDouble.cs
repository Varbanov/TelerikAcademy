using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* Which of the following values can be assigned to a variable of type float and which to a variable of type 
 * double: 34.567839023, 12.345, 8923.1234857, 3456.091?
*/

class FloatOrDouble
{
    static void Main()
    {
        double firstVar = 34.567839023;
        float secondVar = 12.345f;
        double thirdVar = 8923.1234857;
        float fourthVar = 3456.091f;

        Console.WriteLine("{0}, {1}, {2}, {3}", firstVar, secondVar, thirdVar, fourthVar);

    }
}

