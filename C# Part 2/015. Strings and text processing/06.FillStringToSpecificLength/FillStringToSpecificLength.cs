using System;
using System.Collections.Generic;
using System.Text;

class FillStringToSpecificLength
{
    //06. Write a program that reads from the console a string of maximum 20 characters. If the length
    //of the string is less than 20, the rest of the characters should be filled with '*'. Print the result string into the console.

    static string FillStringToLength(string str)
    {
        StringBuilder res = new StringBuilder();
        res.Append(str);
        while (res.Length < 20)
        {
            res.Append("*");
        }
        return res.ToString();
    }

    static void Main()
    {
        //input
        string input;
        do
        {
        Console.WriteLine("Please enter a string shorter than 20 characters");
        input = Console.ReadLine();
        } while (input.Length > 20);
        //solution
        Console.WriteLine(FillStringToLength(input));
    }
}

