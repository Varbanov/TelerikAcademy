using System;
using System.IO;
using System.Text;

class PrintOddLinesOfFile
{
    //Write a program that reads a text file and prints on the console its odd lines.

    static void PrintOddLines(StreamReader reader)
    {
        using (reader)
        {
            string currLine = reader.ReadLine();
            //counting from one
            int counter = 1;
            while (currLine != null)
            {
                if (counter % 2 == 0)
                {
                    Console.WriteLine(currLine);
                }
                currLine = reader.ReadLine();
                counter++;
            }
        }
    }

    static void Main()
    {
        StreamReader reader = new StreamReader(@"..\..\PrintOddLinesOfFile.cs", Encoding.GetEncoding("Windows-1251"));
        //Това е кирилица първи ред
        //Това е кирилица втори ред
        PrintOddLines(reader);
    }
}

