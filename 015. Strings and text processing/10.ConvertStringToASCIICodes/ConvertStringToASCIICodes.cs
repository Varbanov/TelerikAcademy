using System;
using System.Text;

class ConvertStringToASCIICodes
{
    //10. Write a program that converts a string to a sequence of C# Unicode character literals. Use format strings. Sample input:
    //Hi!
    //Expected output:
    //\u0048\u0069\u0021

    static string ConvertStringToASCII(string input)
    {
        StringBuilder res = new StringBuilder();
        for (int i = 0; i < input.Length; i++)
        {
            //for each symbol append its ASCII code using formatting string
            res.Append(String.Format("\\u{0:X4}", (int)input[i]));
        }
        return res.ToString();
    }

    static void Main()
    {
        Console.WriteLine("Please enter a string: ");
        string input = Console.ReadLine();
        Console.WriteLine(ConvertStringToASCII(input));
    }
}

