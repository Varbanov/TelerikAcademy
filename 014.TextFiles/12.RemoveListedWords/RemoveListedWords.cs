using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;

class RemoveListedWords
{
    //12.Write a program that removes from a text file all words listed in given another text file. Handle all possible exceptions in your methods.

    static void RemoveWords(string inputPath, string listedWordsPath)
    {
        List<string> list = ExtractList(listedWordsPath);
        List<string> outputLines = new List<string>();
        StreamReader reader = new StreamReader(inputPath);
        using (reader)
        {
            while (reader.Peek() != -1)
            {
                string currLine = reader.ReadLine();

                for (int i = 0; i < list.Count; i++)
                {
                    //match each word from the list in the current line and replace it with empty string if matched
                    string currWord = "\\b" + list[i] + "\\b";
                    currLine = Regex.Replace(currLine, currWord, "");
                }
                outputLines.Add(currLine);
            }
        }
        //overwrite the file
        StreamWriter writer = new StreamWriter(inputPath);
        using (writer)
        {
            foreach (var line in outputLines)
            {
                writer.WriteLine(line);
            }
        }
    }

    private static List<string> ExtractList(string listedWordsPath)
    {
        //read listed words and return them in a list
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
            string path = @"..\..\input.txt";
            string listPath = @"..\..\list.txt";
            RemoveWords(path, listPath);
        }
        catch (DirectoryNotFoundException)
        {
            Console.Error.WriteLine("The directory of either the input file or the list file is missing");

        }
        catch (FileNotFoundException)
        {
            Console.Error.WriteLine("The input file or the list file is missing!");
        }
        catch (IOException)
        {
            Console.Error.WriteLine("An input/output error occured");
        }
    }
}

