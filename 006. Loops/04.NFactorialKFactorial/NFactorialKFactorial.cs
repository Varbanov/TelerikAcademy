using System;
using System.Numerics;

class NfactorialKFactorial
{
    //Write a program that calculates N!/K! for given N and K (1<K<N).
    static void Main()
    {
        //input N 1<K<N
        int n;
        do
        {
            Console.Write("Please enter \"N\" (N > 1):");
        } while (!int.TryParse(Console.ReadLine(), out n) || n < 1);
        
        //input K 1<K<N
        int k;
        do
        {
            Console.Write("Please enter \"K\" [1..N]:");
        } while (!int.TryParse(Console.ReadLine(), out k) || k > n || k < 1);

        //solution N!/K! = 1*2*..k*(k+1)*..*n / 1*2*...k = (k+1)*(k+2)*...n
        BigInteger factorial = 1;
        for (int i = k + 1; i <= n; i++)
        {
            factorial *= i;
        }

        Console.WriteLine("N!/K! = {0}", factorial);
    }
}

