using System;

class PrimeNumsEratosthenes
{
    //Write a program that finds all prime numbers in the range [1...10 000 000]. Use the sieve of Eratosthenes algorithm (find it in Wikipedia).

    static void Main()
    {
        bool[] arr = new bool[10000001];

        for (long i = 2; i < arr.Length; i++)
        {
            if (arr[i] == false)
            {
                long tempComposite = i + i;
                while ( tempComposite <= 10000000)
                {
                    arr[tempComposite] = true;
                    tempComposite += i;
                }
            }
        }
        for (long i = 2; i < arr.Length; i++)
        {
            if (arr[i] == false)
            {
                Console.Write("{0}, ", i);
            }
        }

    }
}

