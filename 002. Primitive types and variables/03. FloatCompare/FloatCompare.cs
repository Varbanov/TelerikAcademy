using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class FloatCompare
{
    /*Write a program that safely compares floating-point numbers with precision of 0.000 001.
     * Examples:(5.3 ; 6.01)  false;  (5.00 000 001 ; 5.00 000 003)  true
    */
    static void Main()
    {
        double firstNum;
        double secondNum;

        Console.WriteLine("Please enter first number to compare:");
        double.TryParse(Console.ReadLine(), out firstNum);
        Console.WriteLine("Please enter second number to compare");
        double.TryParse(Console.ReadLine(), out secondNum);

        double difference = Math.Abs(firstNum - secondNum);

        if (difference <= 0.000001)
        {
            Console.WriteLine("Numbers are equal with presicion of 0.000001!");
        }
        else
        {
            Console.WriteLine("Numbers are NOT equal with precision of 0.000001");
        }


    }
}

