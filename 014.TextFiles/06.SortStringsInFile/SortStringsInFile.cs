using System;
using System.Text;
using System.Collections.Generic;
using System.IO;

class SortStringsInFile
{
    //Write a program that reads a text file containing a list of strings, sorts them and saves them to another text file. 
    //Example:
    /*
     * Ivan         George
     * Peter ---->  Ivan
     * Maria        Maria
     * George       Peter
    */

    static List<string> ReadStringListFromFile(string path)
    {
        StreamReader reader = new StreamReader(path, Encoding.GetEncoding("Windows-1251"));
        List<string> sortedStrings = new List<string>();

        using (reader)
        {
            string tempString = reader.ReadLine();
            while (tempString != null)
            {
                sortedStrings.Add(tempString);
                tempString = reader.ReadLine();
            }
        }
        sortedStrings.Sort();
        return sortedStrings;
    }

    static void WriteListToFile(List<string> input, string path)
    {
        StreamWriter writer = new StreamWriter(path, false, Encoding.GetEncoding("Windows-1251"));
        using (writer)
        {
            foreach (var str in input)
            {
                writer.WriteLine(str);
            }
        }
    }

    static void Main()
    {
        //input: the input and output files are in the main folder of the solution
        string inputPath = @"..\..\input.txt";
        string outputPath = @"..\..\output.txt";
        WriteListToFile(ReadStringListFromFile(inputPath), outputPath);
    }
}
