using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class ExtractSentencesWithGivenWord
{
    //08. Write a program that extracts from a given text all sentences containing given word.
    //Example: The word is "in". 
    //The text is:
    //We are living in a yellow submarine. We don't have anything else. Inside the submarine is very tight.
    //So we are drinking all the day. We will move out of it in 5 days.
    //The expected result is:
    //We are living in a yellow submarine.
    //We will move out of it in 5 days.
    //Consider that the sentences are separated by "." and the words – by non-letter symbols.

    static void ExtractSentences(string text, string word)
    {
        string[] sentences = text.Split('.');
        string pattern = @"\b" + word + @"\b";
        Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);

        for (int i = 0; i < sentences.Length; i++)
        {
            //check if the word is present in the sentence, if so, print the sentence
            Match match = regex.Match(sentences[i]);
            if (match.Success)
            {
                Console.WriteLine(sentences[i].Trim() + ".");
            }
        }
    }

    static void Main()
    {
        //Console.WriteLine("Please enter the text:");
        //string text = Console.ReadLine();
        //Console.WriteLine("Please enter the word to search for:");
        //string word = Console.ReadLine();
        string text = "We are living in a yellow submarine. We don't have anything else. Inside the submarine is very tight.So we are drinking all the day. We will move out of it in 5 days.";
        string word = "in";
        ExtractSentences(text, word);
    }
}

