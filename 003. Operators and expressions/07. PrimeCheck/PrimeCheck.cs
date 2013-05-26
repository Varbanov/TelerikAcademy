using System;

class PrimeCheck
{
    /* Write an expression that checks if given positive integer number n (n ≤ 100) is prime. E.g. 37 is prime.
    */
    static void Main()
    {
        //number input
        int num;

        do
        {
            Console.Write("Please enter an integer to check: ");
        }
        while (!int.TryParse(Console.ReadLine(), out num) || num > 100);
        
        //solution
        bool isPrime = true;
        int upperMostValue = (int) Math.Sqrt(num);
        for (int i = 2; i <= upperMostValue; i++)
			{
                if (num % i == 0)
                {
                    isPrime = false;
                    break;
                }
			}

        //result output
        if (isPrime)
        {
            Console.WriteLine("The number is prime!");
        }
        else
        {
            Console.WriteLine("The number is NOT prime!");
        }
    }
}

