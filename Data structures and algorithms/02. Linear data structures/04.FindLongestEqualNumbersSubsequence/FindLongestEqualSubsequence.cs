namespace _04.FindLongestEqualNumbersSubsequence
{
    using System.Collections.Generic;

    public class LongestEqualNumbersSubsequence
    {
        // 04. Write a method that finds the longest subsequence of equal numbers in given List<int> and
        //returns the result as new List<int>. Write a program to test whether the method works correctly. 

        public static List<int> FindSequence(List<int> input)
        {
            var result = new List<int>();
            if (input.Count == 0)
            {
                return result;
            }

            int start = 1;
            int bestLength = 1;
            int currentLength = 1;
            int bestElement = input[0];

            for (int i = start; i < input.Count; i++)
            {
                if (input[i] == input[i - 1])
                {
                    currentLength++;
                }

                if (currentLength >= bestLength)
                {
                    bestLength = currentLength;
                    bestElement = input[i - 1];
                }

                if (!(input[i] == input[i - 1]))
                {
                    currentLength = 1;
                }

            }

            for (int i = 0; i < bestLength; i++)
            {
                result.Add(bestElement);
            }

            return result;
        }
    }
}
