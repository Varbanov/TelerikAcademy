using System;
using System.Text;
using System.IO;

class InsertLineNumbersInFile
{
    //03. Write a program that reads a text file and inserts line numbers in front of each of its lines.
    //The result should be written to another text file.

    static void InsertLineNums(StreamReader reader, StreamWriter writer)
    {
        using (reader)
        {
            string currLine = reader.ReadLine();
            int num = 1;
            using (writer)
            {
                while (currLine != null)
                {
                    writer.WriteLine("{0} {1}", num, currLine);
                    currLine = reader.ReadLine();
                    num++;
                }
            }
        }
    }

    static void Main()
    {
        //the input file is the .cs file of the project
        //the output file is in created in the main directory of the current project.
        StreamReader reader = new StreamReader(@"..\..\input.txt", Encoding.GetEncoding("Windows-1251"));
        StreamWriter writer = new StreamWriter(@"..\..\output.txt", false, Encoding.GetEncoding("Windows-1251"));
        //solution
        InsertLineNums(reader, writer);

    }
}

