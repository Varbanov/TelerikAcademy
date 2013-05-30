using System;

class PrintNumbers
{
    //Write a program that reads an integer number n from the console and prints all the numbers
    //in the interval [1..n], each on a single line.
    static void Main()
    {
        int n;
        do
        {
            Console.Write("Please enter an integer:");
        } while (!int.TryParse(Console.ReadLine(), out n));

        for (int i = 1; i <= n; i++)
        {
            Console.WriteLine(i);
        }

    }
}

