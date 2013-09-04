using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class PrintDifferentLetters
{
    //21. Write a program that reads a string from the console and prints all different letters in the 
    //string along with information how many times each letter is found. 

    static void CountDifferentLetters(string text)
    {
        Dictionary<char, int> dict = new Dictionary<char, int>();

        foreach (var letter in text)
        {
            //if found, increase counter, else add as found
            if (dict.ContainsKey(letter))
            {
                dict[letter]++;
            }
            else
            {
                dict.Add(letter, 1);
            }
        }
        //output
        foreach (var item in dict)
        {
            Console.WriteLine("{0} - {1}", item.Key, item.Value);
        }
    }

    static void Main()
    {
        //input
        string text = "fsfsf asfsa . afsas s.";
        CountDifferentLetters(text);
    }
}

