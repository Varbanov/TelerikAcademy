using System;
using System.Text.RegularExpressions;

class ExtractEmails
{
    //18. Write a program for extracting all email addresses from given text. All substrings that match 
    //the format <identifier>@<host>…<domain> should be recognized as emails.

    static void ParseEmails(string inputText)
    {
        string pattern = @"\w+@\w+\.\w+"; //a really basic pattern in order to match all substrings in the format wanted

        MatchCollection matches = Regex.Matches(inputText, pattern);
        foreach (var item in matches)
        {
            Console.WriteLine(item);
        }
    }

    static void Main()
    {
        string input = "hehe asd@abv.bg afasf dd@haha.com d";
        ParseEmails(input);
    }
}

