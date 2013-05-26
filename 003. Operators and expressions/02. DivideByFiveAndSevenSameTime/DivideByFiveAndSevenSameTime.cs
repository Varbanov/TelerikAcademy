using System;

class DivideByFiveAndSevenSameTime
{
    /*Write a boolean expression that checks for given integer if it can be divided (without remainder) by 7 and 5 in the same time.
    */
    static void Main()
    {
        //number input
        int num;
        do
        {
            Console.Write("Please enter an integer: ");
        }
        while (!int.TryParse(Console.ReadLine(), out num));

        //number check and output
        if (num % 5 == 0 && num % 7 == 0)
        {
            Console.WriteLine("The number entered can be divided by 7 and 5 in the same time!");
        }
        else
        {
            Console.WriteLine("The number entered cannot be divided by 7 and 5 in the same time without remainder!");
        }
    }
}

