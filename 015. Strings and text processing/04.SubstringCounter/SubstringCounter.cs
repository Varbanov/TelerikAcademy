using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class SubstringCounter
{
    //04. Write a program that finds how many times a substring is contained in a given text (perform case insensitive search).
    //Example: The target substring is "in". The text is as follows:
    //We are living in an yellow submarine. We don't have anything else. Inside the submarine is very 
    //tight. So we are drinking all the day. We will move out of it in 5 days.
    //The result is: 9.

    static int CountSubstrOccurenceCaseInsens(string text, string substr)
    {
        string pattern = substr;
        Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);
        MatchCollection matches = regex.Matches(text);
        return matches.Count;
    }

    static void Main()
    {
        //input
        //Console.WriteLine("Please enter the substring:");
        //string substr = Console.ReadLine();
        //Console.WriteLine("Please enter the text: ");
        //string text = Console.ReadLine();

        string text = "We are living in an yellow submarine. We don't have anything else. Inside the submarine is very tight. So we are drinking all the day. We will move out of it in 5 days.";
        string substr = "in";
        Console.WriteLine("The substring \"{0}\" occured {1} times in the text!", substr, CountSubstrOccurenceCaseInsens(text, substr));
    }
}

