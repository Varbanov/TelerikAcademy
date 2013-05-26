using System;

class ReturnBitAtPosition
{
    /* Write a boolean expression that returns if the bit at position p (counting from 0) in a given 
     * integer number v has value of 1. Example: v=5; p=1  false.
    */
    static void Main()
    {
        //integer input
        int num;
        do
        {
            Console.Write("Please enter an integer: ");
        }
        while (!int.TryParse(Console.ReadLine(), out num));

        //position input
        int bitPosition;
        do
        {
            Console.Write("Please enter a bit position to check [0..31]: ");
        }
        while (!int.TryParse(Console.ReadLine(), out bitPosition) || bitPosition > 31 || bitPosition < 0);

        //solution
        int mask = 1 << bitPosition;
        bool isOne = (num & mask) >> bitPosition == 1;

        //output
        Console.WriteLine(isOne);
    }
}

