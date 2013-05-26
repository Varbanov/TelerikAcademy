using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class FindSum
{
    static void Main()
    {
        //ideqta e slednata: primerno imame redicata ot n 4isla (n=3) 1, 2, 3 i iskame da vidim dali ima suma 4. 4islata ot 1 do ((2^n) - 1), predstaveni
        //pobitovo sa 1, 10, 11, 100, 101, 110, 111. v purviq cikul vurtim posledovatelno vsqko ot tezi 4isla, a vuv vtoriq cikul vurtim
        // negovite bitove ot 0 do n-1 (t.e. bitove nulev, purvi i vtori). Na vseki nomer na bit supostavqme suotvetniq nomer 4islo ot redicata.
        // naprimer za 101 vzimame ot redicata purvoto i tretoto 4islo. sumirame i ako sumata ni udovletvorqva, broq4++.
        // s drugi dumi, 4islata 1, 10, 11, 100, 101, 111 iz4erpvat vsi4ki vuzmojni kombinacii mejdu 4islata ot redicata.

        long s = long.Parse(Console.ReadLine());
        int n = int.Parse(Console.ReadLine());
        long[] arr = new long[n];
        
        for (int i = 0; i < n; i++)
        {
            arr[i] = long.Parse(Console.ReadLine());
        }

        int numOfSums = (int)Math.Pow(2, n) - 1;

        int counter = 0;

        for (int i = 1; i <= numOfSums; i++)
        {
            long tempSum = 0;

            for (int j = 0; j < n; j++)
            {
                int mask = 1 << j;
                int bitNumAndMask = i & mask;
                int bit = bitNumAndMask >> j;
                if (bit == 1)
                {
                    tempSum += arr[arr.Length - 1 - j];
                }
            }
            if (tempSum == s)
            {
                counter++;
            }
        }
        Console.WriteLine(counter);
    }
}

