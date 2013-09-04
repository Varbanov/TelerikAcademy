using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class Dictionary
{
    //14. A dictionary is stored as a sequence of text lines containing words and their explanations.
    //Write a program that enters a word and translates it by using the dictionary. Sample dictionary:
    //.NET – platform for applications from Microsoft
    //CLR – managed execution environment for .NET
    //namespace – hierarchical organization of classes

    static void Translate(string word, string inputDict)
    {
        //keep in mind the dictionary is "sequence of text lines", so each line is a new word and its explanation
        string[] lines = inputDict.Split('\n');
        bool isFound = false;
        Regex regex = new Regex(@"(.*?) – (.+)");

        for (int i = 0; i < lines.Length; i++)
        {
            Match match = regex.Match(lines[i]);
            //check if the word is matched
            if (match.Groups[1].Value.ToLower() == word.ToLower())
            {
                Console.WriteLine("Your word: {0}\nExplanation: {1}", word, match.Groups[2].Value);
                isFound = true;
                break;
            }
        }

        if (!isFound)
        {
            Console.WriteLine("The dictionary does not contain the word \"{0}\"", word);
        }
    }

    static void Main()
    {
        string inputDict = ".NET – platform for applications from Microsoft \nCLR – managed execution environment for .NET\nnamespace – hierarchical organization of classes";
        Console.Write("Please enter a word from the dictionary: ");
        string word = Console.ReadLine();
        Translate(word, inputDict);
    }
}

