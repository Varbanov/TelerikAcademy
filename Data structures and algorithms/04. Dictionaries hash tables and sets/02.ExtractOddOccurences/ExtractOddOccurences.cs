namespace _02.ExtractOddOccurences
{
    using System;
    using System.Collections.Generic;

    class ExtractOddOccurences
    {
        static void PrintOddOccurences(string[] input)
        {
            var dict = new Dictionary<string, int>();
            foreach (var item in input)
            {
                if (dict.ContainsKey(item))
                {
                    dict[item]++;
                }
                else
                {
                    dict[item] = 1;
                }
            }

            foreach (var pair in dict)
            {
                if (pair.Value % 2 != 0)
                {
                    Console.WriteLine(pair.Key);
                }
            }
        }

        static void Main()
        {
            string[] input = new string[] {"C#", "SQL", "PHP", "PHP", "SQL", "SQL" };
            PrintOddOccurences(input);
        }
    }
}
