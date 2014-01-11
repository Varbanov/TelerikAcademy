using System;

class MinAndMaxOfSeq
{
    //Write a program that reads from the console a sequence of N integer numbers and returns the minimal and maximal of them.
    static void Main()
    {
        //input
        int n;
        do
        {
            Console.Write("Please enter an integer:");
        } while (!int.TryParse(Console.ReadLine(), out n));

        //solution
        int max = int.MinValue;
        int min = int.MaxValue;
        for (int i = 0; i < n; i++)
        {
            int currNum;
            do
            {
                Console.Write("Please enter integer {0}: ", i + 1);
            } while (!int.TryParse(Console.ReadLine(), out currNum));

            if (currNum <= min)
            {
                min = currNum;
            }
            if (currNum >= max)
            {
                max = currNum;
            }
        }
        Console.WriteLine("Min: {0}\nMax: {1}", min, max);



    }
}

