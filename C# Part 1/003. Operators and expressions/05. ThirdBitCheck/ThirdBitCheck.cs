using System;

class ThirdBitCheck
{
    /*Write a boolean expression for finding if the bit 3 (counting from 0) of a given integer is 1 or 0.
    */
    static void Main()
    {
        //integer input
        int num;
        do
        {
            Console.Write("Please enter an integer to check: ");
        }
        while (!int.TryParse(Console.ReadLine(), out num));

        //bit check
        num >>= 3;
        bool bitIsOne = false;
        if ((num & 1) == 1)
        {
            bitIsOne = true;
        }

        //output
        if (bitIsOne)
        {
            Console.WriteLine("The 3rd bit from 0 is 1!");
        }
        else
        {
            Console.WriteLine("The third bit from 0 is 0!");
        }
    }
}

