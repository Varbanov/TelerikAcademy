namespace _04.FindLongestEqualNumbersSubsequence
{
    using System;
    using System.Collections.Generic;

    class LongestSubsequenceMain
    {
        static void Main()
        {
            var input = new List<int> { 1, 2, 3, 3 };
            var result = LongestEqualNumbersSubsequence.FindSequence(input);
            Console.WriteLine(string.Join(", ", result));
        }
    }
}
