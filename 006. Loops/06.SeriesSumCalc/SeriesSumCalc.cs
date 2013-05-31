using System;

class SeriesSumCalc
{
    //Write a program that, for given two integer numbers N and X, calculates the sumS = 1 + 1!/X + 2!/X^2 + … + N!/X^N

    static void Main()
    {
        //input
        int n;
        do
        {
            Console.Write("Please enter an integer \"N\": ");
        } while (!int.TryParse(Console.ReadLine(), out n));

        int x;
        do
        {
            Console.Write("Please enter an integer \"X\": ");
        } while (!int.TryParse(Console.ReadLine(), out x));

        //solution
        double sum = 1;
        double factorial = 1;
        double denominator = 1;
        for (int i = 1; i <= n; i++)
        {
            factorial *= i;
            denominator = Math.Pow(x, i);
            sum += factorial / denominator;
        }

        Console.WriteLine("The sum S is: {0}", sum);
    }
}

