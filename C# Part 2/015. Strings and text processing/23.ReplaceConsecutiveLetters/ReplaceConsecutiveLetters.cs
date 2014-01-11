using System;
using System.Collections.Generic;
using System.Text;

class ReplaceConsecutiveLetters
{
    //23. Write a program that reads a string from the console and replaces all series of 
    //consecutive identical letters with a single one. Example: "aaaaabbbbbcdddeeeedssaa"  "abcdedsa".

    static string ReplaceLetters(string input)
    {
        StringBuilder res = new StringBuilder();

        res.Append(input[0]); //append first char as it is always correct

        //proceed with next chars - if not conscutive, add to the result
        for (int i = 1; i < input.Length; i++)
        {
            if (input[i] != res[res.Length - 1])
            {
                res.Append(input[i]);
            }
        }
        return res.ToString();
    }

    static void Main()
    {
        //Console.WriteLine("Please enter a string:");
        string input = "aaaaabbbbbcdddeeeedssaa"; //Console.ReadLine();

        Console.WriteLine(ReplaceLetters(input));
    }
}

