using System;

class ReturnBit
{
    /*Write an expression that extracts from a given integer i the value of a given bit number b. Example: i=5; b=2  value=1.
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

        //solution and output
        int mask = 1 << bitPosition;
        int bitAtPosition = (num & mask) >> bitPosition;
        Console.WriteLine(bitAtPosition);
    }
}

