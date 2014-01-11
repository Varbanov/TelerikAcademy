using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class ExchangeTwoIntegers
{
    /*Declare  two integer variables and assign them with 5 and 10 and after that exchange their values.
    */
    static void Main()
    {
        int firstNum = 5;
        int secondNum = 10;

        int tempNum = firstNum;
        firstNum = secondNum;
        secondNum = tempNum;

        Console.WriteLine("{0}, {1}", firstNum, secondNum);

        /*Another solution without using a temporary variable
         * int firstNum = 5;
         * int secondNum = 10;
         * firstNum += secondNum;
         * secondNum = firstNum - secondNum;
         * firstNumber = firstNum - secondNum;
         * */
    }
}

