using System;

class PrintAllNumsToN
{
    //Write a program that prints all the numbers from 1 to N.
    static void Main()
    {
        //input
        int num;
        do
        {
            Console.Write("Please enter an integer:");
        } while (!int.TryParse(Console.ReadLine(), out num));

        //solution
        for (int i = 0; i < num; i++)
        {
            Console.Write("{0}, ", i + 1);
        }

    }
}

