using System;

  class NumsNotDivBy3And7
  {
      //Write a program that prints all the numbers from 1 to N, that are not divisible by 3 and 7 at the same time.
      static void Main()
      {
          //input
          int n;
          do
          {
              Console.Write("Please enter an integer:");
          } while (!int.TryParse(Console.ReadLine(), out n));

          //solution
          for (int i = 1; i <= n; i++)
          {
              if (i % 3 == 0 && i % 7 == 0)
              {
                  continue;
              }
              Console.Write("{0}, ", i);
          }
      }
  }

