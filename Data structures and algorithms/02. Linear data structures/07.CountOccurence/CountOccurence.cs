namespace _07.CountOccurence
{
    using System;
    using System.Collections.Generic;

    //Write a program that finds in given array of integers (all belonging to the range [0..1000]) how many
    //times each of them occurs. Example: array = {3, 4, 4, 2, 3, 3, 4, 3, 2} 2 2 times 3 4 times 4 3 times 

    class CountOccurence
    {
        static void PrintNumberOccurences(int[] input)
        {
            var result = new Dictionary<int, int>();
            for (int i = 0; i < input.Length; i++)
            {
                var currentElement = input[i];
                if (result.ContainsKey(currentElement))
                {
                    result[currentElement]++;
                }
                else
                {
                    result.Add(currentElement, 1);
                }
            }

            foreach (var entry in result)
            {
                Console.WriteLine("{0} - {1} times", entry.Key, entry.Value);
            }
        }

        static void Main()
        {
            var input = new int[] { 1, 2, 2, 3, 3, 3, 4, 4, 4, 4, 5, 5, 5, 5, 5, 6, 6, 6, 6, 6, 6 };
            PrintNumberOccurences(input);
        }
    }
}
