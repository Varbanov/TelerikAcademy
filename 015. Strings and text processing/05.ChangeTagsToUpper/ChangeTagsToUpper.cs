using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Text;

class ChangeTagsToUpper
{
    //05. You are given a text. Write a program that changes the text in all regions surrounded by the tags <upcase>
    //and </upcase> to uppercase. The tags cannot be nested. Example:
    //We are living in a <upcase>yellow submarine</upcase>. We don't have <upcase>anything</upcase> else.
    //The expected result:
    //We are living in a YELLOW SUBMARINE. We don't have ANYTHING else.

    static string TaggedTextToUpper(string inputText)
    {
        StringBuilder res = new StringBuilder();
        res.Append(inputText);
        Regex regex = new Regex(@"(<upcase>)(?'substr'.*?)</upcase>");
        Match match = regex.Match(inputText);
        //extract the whole substring with the tags, extract the text between the tags and manipulate res with it
        while (match.Success)
        {
            string token = match.ToString();
            string currString = match.Groups["substr"].Value.ToUpper();
            res.Replace(token, currString);
            match = match.NextMatch();
        }
        return res.ToString();
    }

    static void Main()
    {
        //input
        string text = "We are living in a <upcase>yellow submarine</upcase>. We don't have <upcase>anything</upcase> else.";
        Console.WriteLine(TaggedTextToUpper(text));
    }
}

