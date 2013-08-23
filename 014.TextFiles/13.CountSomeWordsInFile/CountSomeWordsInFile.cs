using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;

class CountSomeWordsInFile
{
    //Write a program that reads a list of words from a file words.txt and finds how many times 
    //each of the words is contained in another file test.txt. The result should be written in 
    //the file result.txt and the words should be sorted by the number of their occurrences in 
    //descending order. Handle all possible exceptions in your methods.

    private static Dictionary<string, int> CountWords(string inputPath, string listOfWordsPath)
    {
        List<string> list = ExtractList(listOfWordsPath);
        StreamReader reader = new StreamReader(inputPath);
        Dictionary<string, int> result = new Dictionary<string, int>();

        using (reader)
        {
            while (reader.Peek() != -1)
            {
                string currline = reader.ReadLine();

                for (int i = 0; i < list.Count; i++)
                {
                    Regex word = new Regex("\\b" + list[i] + "\\b");

                    foreach (Match match in word.Matches(currline))
                    {
                        //for each word met, if already met - increase counter, else - start counting it
                        if (result.ContainsKey(list[i]))
                        {
                            result[list[i]]++;
                        }
                        else
                        {
                            result.Add(list[i], 1);
                        }
                    }
                }
            }
        }
        return result;
    }

    private static void WriteDictionaryToFile(Dictionary<string, int> dict)
    {
        StreamWriter writer = new StreamWriter(@"..\..\result.txt");
        using (writer)
        {
            foreach (var token in dict)
            {
                writer.WriteLine("{0} - {1}", token.Key, token.Value);
            }
        }
    }

    private static List<string> ExtractList(string listedWordsPath)
    {
        //read all the listed words from the file and return them in a list object
        StreamReader reader = new StreamReader(listedWordsPath);
        List<string> list = new List<string>();
        using (reader)
        {
            while (reader.Peek() != -1)
            {
                list.Add(reader.ReadLine().Trim());
            }
        }

        return list;
    }

    static void Main()
    {
        try
        {
            //all the files are in the main directory of the current project
            string inputPath = @"..\..\input.txt";
            string listPath = @"..\..\words.txt";
            var count = CountWords(inputPath, listPath);
            WriteDictionaryToFile(count);
        }
        catch (DirectoryNotFoundException e)
        {
            Console.Error.WriteLine("The directory of either the input file or the list file is missing" + e.Message);
        }
        catch (FileNotFoundException e)
        {
            Console.Error.WriteLine("The input file or the list file is missing!" + e.Message);
        }
        catch (IOException e)
        {
            Console.Error.WriteLine("An input/output error occured" + e.Message);
        }
    }
}

