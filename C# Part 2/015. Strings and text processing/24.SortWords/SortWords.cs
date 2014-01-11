using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class SortWords
{
    //Write a program that reads a list of words, separated by spaces and prints the list in an alphabetical order.

    static void SortWordsAlphabetically(string input)
    {
        string[] words = input.Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);

        Array.Sort(words);
        foreach (var item in words)
        {
            Console.WriteLine(item);
        }
    }

    static void Main()
    {
        //input
        //Console.WriteLine("Enter string of words separated by whitespaces");
        string input = "Write a program that reads a list of words"; //Console.ReadLine();

        SortWordsAlphabetically(input);
    }

    
}
