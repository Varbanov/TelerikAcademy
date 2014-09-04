namespace _06.RemoveOddOccurencies
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class RemoveOddOccurencies
    {
        // Write a program that removes from given sequence all numbers that occur odd number of times. 
        //Example: {4, 2, 2, 5, 2, 3, 2, 3, 1, 5, 2} {5, 3, 3, 5}

        static void RemoveOddOccurenceNumbers(List<int> input)
        {
            input.RemoveAll(x => input.Count(n => n == x) % 2 != 0);
        }

        static void Main()
        {
            var input = new List<int> { 1, 2, 2, 3, 3, 3, 4, 4, 4, 4, 5, 5, 5, 5, 5, 6, 6, 6, 6, 6, 6 };
            RemoveOddOccurenceNumbers(input);

            Console.WriteLine(string.Join(", ", input));
        }

    }
}
