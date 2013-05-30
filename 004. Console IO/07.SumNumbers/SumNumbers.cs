using System;

class SumNumbers
{
    //Write a program that gets a number n and after that gets more n numbers and calculates and prints their sum. 

    static void Main()
    {
        //data input
        int n;
        do
        {
            Console.Write("Please enter the number of numbers you want to sum:");
        }
        while (!int.TryParse(Console.ReadLine(), out n) || n < 0);

        //solution
        double sum = 0;
        for (int i = 1; i <= n; i++)
        {
            float temp;
            do
            {
                Console.Write("Please enter number {0}:", i);
            } 
            while (!float.TryParse(Console.ReadLine(), out temp));
            sum += temp;
        }

        //output
        Console.WriteLine("The sum of the numbers entered is {0}!", sum);

    }
}

