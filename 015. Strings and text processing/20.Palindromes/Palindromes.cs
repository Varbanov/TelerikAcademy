using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

class Palindromes
{
    //20. Write a program that extracts from a given text all palindromes, e.g. "ABBA", "lamal", "exe".

    static List<string> ExtractPalindromes(string text)
    {
        List<string> palindromes = new List<string>();
        string[] words = text.Split(new char[] {' ', ',', '.', '!', '?'}, StringSplitOptions.RemoveEmptyEntries);
        StringBuilder reversed = new StringBuilder();

        foreach (var item in words)
        {
            reversed.Clear();
            for (int i = item.Length - 1; i >= 0; i--)
            {
                reversed.Append(item[i]);
            }

            if (reversed.ToString() == item)
            {
                //save to list and print
                palindromes.Add(item);
                Console.WriteLine(item);
            }
        }
        return palindromes;
    }

    static void Main()
    {
        //input
        string text = "sdfas abba dfs lamal. exe";

        ExtractPalindromes(text);
    }
}

