using System;
using System.Collections.Generic;
using System.Text;

class PrintDifferentWords
{
    //Write a program that reads a string from the console and lists all 
    //different words in the string along with information how many times each word is found.

    static void CountDifferentWords(string text)
    {
        Dictionary<string, int> dict = new Dictionary<string, int>();
        string[] words = text.ToLower().Split(new char[] { ' ', ',', '.', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);

        foreach (var word in words)
        {
            //if found, increase counter, else add as found
            if (dict.ContainsKey(word))
            {
                dict[word]++;
            }
            else
            {
                dict.Add(word, 1);
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
        //Console.WriteLine("Please enter a string:");
        string text = " hehe hoho. hehe haha ohh!"; //Console.ReadLine();

        CountDifferentWords(text);
    }
}

