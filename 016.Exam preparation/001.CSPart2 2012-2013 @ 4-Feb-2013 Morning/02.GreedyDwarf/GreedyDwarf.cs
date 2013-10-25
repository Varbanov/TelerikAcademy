using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class GreedyDwarf
{
    static void Main()
    {
        //input
        string inputValey = Console.ReadLine();
        int m = int.Parse(Console.ReadLine());

        string[] splittedValey = inputValey.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);

        int[] valey = new int[splittedValey.Length];
        for (int i = 0; i < splittedValey.Length; i++)
        {
            valey[i] = int.Parse(splittedValey[i]);
        }

        //solution
        int maxSum = int.MinValue;

        //for each pattern, read it and jump over according to it while possible
        for (int i = 0; i < m; i++)
        {
            string inputPattern = Console.ReadLine();
            string[] splittedPattern = inputPattern.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
            int[] pattern = new int[splittedPattern.Length];
            for (int j = 0; j < splittedPattern.Length; j++)
            {
                pattern[j] = int.Parse(splittedPattern[j]);
            }

            int sum = 0;
            bool[] visited = new bool[valey.Length];
            int currIndex = 0;
            int patternIndex = 0;

            while (currIndex >= 0 && currIndex < valey.Length)
            {
                if (visited[currIndex])
                {
                    break;
                }
                else
                {
                    sum += valey[currIndex];
                    visited[currIndex] = true;
                    currIndex = currIndex + pattern[patternIndex];
                    if (patternIndex < pattern.Length - 1)
                    {
                        patternIndex++;
                    }
                    else
                    {
                        patternIndex = 0;
                    }
                }
            }
            if (sum > maxSum)
            {
                maxSum = sum;
            }
        }

        Console.WriteLine(maxSum);
    }
}

