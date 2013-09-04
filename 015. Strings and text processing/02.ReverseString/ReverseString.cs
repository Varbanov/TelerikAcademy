using System;
using System.Text;

class ReverseString
{
    //02. Write a program that reads a string, reverses it and prints the result at the console.

    static string ReverseStr(string input)
    {
        StringBuilder result = new StringBuilder();
        for (int i = input.Length - 1; i >= 0; i--)
        {
            result.Append(input[i]);
        }

        return result.ToString();
    }

    static void Main()
    {
        //input
        Console.Write("Please enter a string: ");
        string input = Console.ReadLine();
        //solution
        Console.WriteLine(ReverseStr(input));
    }
}

