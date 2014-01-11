using System;
using System.Numerics;

class FactorialFormula
{
    //Write a program that calculates N!*K! / (K-N)! for given N and K (1<N<K).
    static void Main()
    {
        //input K 1<N<K
        int k;
        do
        {
            Console.Write("Please enter \"K\" (K > 1):");
        } while (!int.TryParse(Console.ReadLine(), out k) || k < 1);

        //input N 1<N<K
        int n;
        do
        {
            Console.Write("Please enter \"N\" [1..K]:");
        } while (!int.TryParse(Console.ReadLine(), out n) || n > k || n < 1);

        //cancelling 
        //N!*K!/(K-N)! = (k-n+1)*(k-n+2)*...k*n!
        //numerator = 1*2*..(k-n)*(k-n+1)*(k-n+2)*..k*1*2*3*..n
        //denominator = 1*2*..*(k-n)

        //solution
        BigInteger result = 1;
        for (int i = 1; i <= n; i++)
        {
            result *= i;
        }

        for (int i = k - n + 1; i <= k; i++)
        {
            result *= i;
        }
        Console.WriteLine("The result is: {0}", result);

        /*example
         * n = 3; k = 5
         * n!k! / (k - n)! = (1 * 2 * 3) * (1 * 2 * 3 * 4 * 5)
         *                   ----------------------------------=
         *                                  1 * 2
         *                                  
         * =       6 * 120
         *         ------- = 360
         *            2
         * */
    }
}

