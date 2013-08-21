using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

class ExtractOnlyTextFromXML
{
    //Write a program that extracts from given XML file all the text without the tags. 
    //Input: input.txt with valid xml text from the example
    //Output: Pesho, 21, Games, C#, Java

    static string ExtractTextFromXML(string path)
    {
        StringBuilder res = new StringBuilder();
        StreamReader reader = new StreamReader(path);

        using (reader)
        {
            while (reader.Peek() != -1)
            {
                string currLine = reader.ReadLine();
                int openIndex = currLine.IndexOf('>');
                
                //what I do next: find indexes of '>' and of '<', if present, and extract the substring in between
                while (openIndex != -1)
                {
                    int closeIndex = currLine.IndexOf('<', openIndex);
                    if (closeIndex != -1)
                    {
                        string token = currLine.Substring(openIndex + 1, closeIndex - openIndex - 1);
                        res.Append(token);
                        res.Append(", ");
                    }
                    openIndex = currLine.IndexOf('>', openIndex + 1);
                }
            }
        }
        return res.ToString();
    }

    static void Main()
    {
        string path = @"..\..\input.txt";
        var res = ExtractTextFromXML(path);
        Console.WriteLine(res);
    }
}
