using System;
using System.Text;
using System.IO;
using System.Collections.Generic;

class DeleteOddLines
{
    //09.Write a program that deletes from given text file all odd lines. The result should be in the same file.

    static void DeleteLines(string path)
    {
        //read lines and save them in a list
        StreamReader reader = new StreamReader(path);
        List<string> lines = new List<string>();
        using (reader)
        {
            while (reader.Peek() != -1)
            {
                lines.Add(reader.ReadLine());
            }
        }
        //rewrite file with even lines only (first line is odd;)
        StreamWriter writer = new StreamWriter(path);
        using (writer)
        {
            for (int i = 1; i < lines.Count; i+=2)
            {
                writer.WriteLine(lines[i]);
            }
        }
    }

    static void Main()
    {
        string path = @"..\..\input.txt";
        DeleteLines(path);
    }
}
