using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

class ReverseWordsInSentence
{
    //Write a program that reverses the words in given sentence.
	//Example: "C# is not C++, not PHP and not Delphi!"  "Delphi not and PHP, not C++ not is C#!".

    static void ReverseWords(string sentence)
    {
        StringBuilder res = new StringBuilder();
        Stack<string> words = new Stack<string>();

        Regex regex = new Regex(@"(\b[\w#\+]+)");
        Match match = regex.Match(sentence);
        //extract words
        while (match.Success)
        {
            words.Push(match.ToString());
            match = match.NextMatch();
        }
        //extract signs
        Regex regexPunct = new Regex(@"[,\.!?:;-]");
        Match sign = regexPunct.Match(sentence);

        //combine signs and words in the result, so that the sign keeps its initial index as closest as possible
        while (words.Count > 0)
        {
            res.Append(words.Pop());

            if (res.Length >= sign.Index)
            {
                res.Append(sign.ToString());
                res.Append(" ");
                sign = sign.NextMatch();
            }
            else
            {
                res.Append(" ");
            }
        }
        Console.WriteLine(res.ToString());
    }

    static void Main()
    {
        string input = "C# is not C++, not PHP and not Delphi!";
        ReverseWords(input);
    }
}

