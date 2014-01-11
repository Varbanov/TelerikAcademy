using System;

class Fibonacci100Members
{
    //Write a program to print the first 100 members of the sequence of Fibonacci:
    //0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377, …

    static void Main()
    {
        //solution and output
        decimal first = 0;
        decimal second = 1;
        Console.Write("{0}, {1}, ", first, second);

        decimal temp;
        for (int i = 0; i < 100; i++)
        {
            //checked to prevent hidden overflow
            checked
            {
                temp = first + second;

                Console.Write("{0}, ", temp);
                first = second;
                second = temp;
            }
        }
    }
}

