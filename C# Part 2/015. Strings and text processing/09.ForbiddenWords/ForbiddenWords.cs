using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Text;

class ForbiddenWords
{
    //09. We are given a string containing a list of forbidden words and a text containing some
    //of these words. Write a program that replaces the forbidden words with asterisks. Example:
    //Microsoft announced its next generation PHP compiler today. It is based on .NET Framework 4.0 and is implemented as a dynamic language in CLR.
    //Words: "PHP, CLR, Microsoft"
    //The expected result:
    //********* announced its next generation *** compiler today. It is based on .NET Framework 4.0 and is implemented as a dynamic language in ***.

    private static string HideForbiddenWords(string inputText, string inputWords)
    {
        string[] words = inputWords.Trim().Split(' ');
        StringBuilder str = new StringBuilder();
        str.Append(inputText);

        for (int i = 0; i < words.Length; i++)
        {
            string asterisks = new String('*', words[i].Length);
            string pattern = @"\b" + words[i] + @"\b";
            Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);
            Match match = regex.Match(inputText);

            while (match.Success)
            {
                //replace the word found in the stringbuilder object with aterisks
                str.Replace(words[i], asterisks, match.Index, words[i].Length);
                match = match.NextMatch();
            }
        }
        return str.ToString();
    }

    static void Main()
    {
        //user input
        //Console.WriteLine("Please enter string:");
        //string text = Console.ReadLine();
        //Console.WriteLine("Please enter words as string separated by whitespace \" \":");
        //string words = Console.ReadLine();
        string text = "Microsoft announced its next generation PHP compiler today. It is based on .NET Framework 4.0 and is implemented as a dynamic language in CLR.";
        string words = "PHP CLR Microsoft ";

        var result = HideForbiddenWords(text, words);
        Console.WriteLine(result);
    }
}

