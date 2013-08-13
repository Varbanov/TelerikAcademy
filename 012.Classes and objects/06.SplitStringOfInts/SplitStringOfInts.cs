using System;
using System.Collections.Generic;



class SplitStringOfInts
{
    //06. You are given a sequence of positive integer values written into a string, separated by spaces. 
    //Write a function that reads these values from given string and calculates their sum. Example:
    //string = "43 68 9 23 318"  result = 461

    static void Main()
    {
        //input and check
        Console.WriteLine("Please enter a string of integers separated by intervals: ");
        string input = Console.ReadLine();
        List<char> digits = new List<char>()
        {
            '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', ' '
        };

        for (int i = 0; i < input.Length; i++)
        {
            if (!digits.Contains(input[i]))
            {
                throw new ArgumentException("The input string is incorrect!");
            }
        }

        //solution
        SumIntsFromString(input);
    }

    private static void SumIntsFromString(string input)
    {
        string[] nums = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        int sum = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            sum += Convert.ToInt32(nums[i]);
        }
        Console.WriteLine("Sum: {0}", sum);
    }
}
