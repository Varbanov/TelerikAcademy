namespace _01.CountOccurences
{
    using System;
    using System.Collections.Generic;

    class OccurenceMain
    {
        static void CountOccurence(double[] input)
        {
            var dict = new Dictionary<double, int>();
            foreach (var number in input)
            {
                if (dict.ContainsKey(number))
                {
                    dict[number]++;
                }
                else
                {
                    dict[number] = 1;
                }
            }

            foreach (var pair in dict)
            {
                Console.WriteLine("Number: {0, 5} Occurence: {1, 5}", pair.Key, pair.Value);
            }
        }

        static void Main()
        {
            double[] input = new double[] { 3, 4, 4, -2.5, 3, 3, 4, 3, -2.5 };
            CountOccurence(input);
        }
    }
}
