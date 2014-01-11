using System;

class CatalanNumber2
{
    //ATTENTION: Task 9 and Task 10 are the same!

    //In the combinatorial mathematics, the Catalan numbers are calculated by the following formula:
    // C(n) = (1 / (n + 1)) * (2n over n) =  (2n)! / ((n + 1)! * n!) for n >= 0
    //Write a program to calculate the Nth Catalan number by given N.
    static void Main()
    {
        //ATTENTION: Task 9 and Task 10 are the same!
        //input
        int n;
        do
        {
            Console.Write("Please enter an integer \"N\" [0...]:");
        } while (!int.TryParse(Console.ReadLine(), out n) || n < 0);

        //solution
        //after cancelling n!(n + 1) in the nominator against n!(n + 1) in the denominator respectively,
        //the formula is C(n) = ((n + 2) * (n + 3) * ... * (n + n)) / n!
        double result;
        double denominator = 1;
        double nominator = 1;
        int upperMost = n + n;

        for (int i = 1; i <= n; i++)
        {
            denominator *= i;
        }

        for (int i = n + 2; i <= upperMost; i++)
        {
            nominator *= i;
        }
        result = nominator / denominator;
        Console.WriteLine("The {0} Catalan number is: {1}", n, result);
    }
}

