namespace _08.FindMajorant
{
    using System;
    using System.Linq;

    class FindMajorant
    {
        // * The majorant of an array of size N is a value that occurs in it at least N/2 + 1 times. 
        //Write a program to find the majorant of given array (if exists). Example: {2, 2, 3, 3, 2, 3, 4, 3, 3} 3

        static void PrintMajorant(int[] input)
        {
            var majorantLength = (input.Length / 2) + 1;
            bool hasMajorant = input.Any(x => input.Count(n => n == x) >= majorantLength);
            if (hasMajorant)
            {
                var majorant = input.First(x => input.Count(n => n == x) >= majorantLength);
                Console.WriteLine("The majorant is: {0}", majorant);
            }
            else
            {
                Console.WriteLine("There is no majorant!");
            }
        }

        static void Main()
        {
            var input = new int[] { 2, 2, 3, 3, 2, 3, 4, 3, 3 };
            PrintMajorant(input);
        }
    }
}
