using System;
using System.Collections.Generic;
using System.Text;

class TwoIsBetterThanOne
{
    static bool IsPalindrome(long number)
    {
        string num = number.ToString();
        for (int i = 0; i < num.Length / 2; i++)
        {
            if (num[i] != num[num.Length - i - 1])
            {
                return false;
            }
        }

        return true;
    }

    static int FindLuckyNumbers(long lowerBound, long upperBound)
    {
        long max = upperBound;
        int leftBound = 0;
        var numbers = new List<long> { 3, 5 };

        int count = 0;
        while (leftBound < numbers.Count)
        {
            int rightBound = numbers.Count;
            for (int i = leftBound; i < rightBound; i++)
            {
                if (numbers[i] < max)
                {
                    numbers.Add((numbers[i] * 10) + 3);
                    numbers.Add((numbers[i] * 10) + 5);
                }
            }
            leftBound = rightBound;
        }

        foreach (var num in numbers)
        {
            if (num >= lowerBound && num <= upperBound && IsPalindrome(num))
            {
                count++;
            }
        }

        return count;
    }

    private static int Percentiles(List<int> numbers, int percent)
    {
        numbers.Sort();
        for (int i = 0; i < numbers.Count; i++)
        {
            int countSmaller = 0;
            for (int j = 0; j < numbers.Count; j++)
            {
                if (numbers[i] >= numbers[j])
                {
                    countSmaller++;
                }
            }

            if (countSmaller >= (numbers.Count * (percent / 100.0)))
            {
                return numbers[i];
            }
        }

        return numbers[numbers.Count - 1];
    }

    static void Main()
    {
        string input = Console.ReadLine();
        string[] tokens = input.Split(' ');
        long lowerBound = long.Parse(tokens[0]);
        long upperBound = long.Parse(tokens[1]);
        int count = FindLuckyNumbers(lowerBound, upperBound);

        string inputList = Console.ReadLine();
        string[] listTokens = inputList.Split(',');
        List<int> numbers = new List<int>();

        for (int i = 0; i < listTokens.Length; i++)
        {
            numbers.Add(int.Parse(listTokens[i]));
        }

        int percent = int.Parse(Console.ReadLine());
        int res = Percentiles(numbers, percent);

        Console.WriteLine(count);
        Console.WriteLine(res);
    }

}

