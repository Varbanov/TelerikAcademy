using System;
using System.Numerics;

   class FibonacciToN
   {
       static void Main()
       {
           //input
           int n;
           do
           {
               Console.Write("Please enter an integer \"N\": ");
           } while (!int.TryParse(Console.ReadLine(), out n));

           //solution and output
           BigInteger first = 0;
           BigInteger second = 1;
           BigInteger temp;
           Console.Write("{0}, {1}, ", first, second);
           for (int i = 0; i <= n - 2; i++)
           {
                   temp = first + second;

                   Console.Write("{0}, ", temp);
                   first = second;
                   second = temp;
           }
       }
   }

