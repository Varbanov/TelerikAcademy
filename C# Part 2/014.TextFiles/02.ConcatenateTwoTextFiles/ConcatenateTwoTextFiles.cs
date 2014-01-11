using System;
using System.Text;
using System.IO;

class ConcatenateTwoTextFiles
{
    //02.Write a program that concatenates two text files into another text file.

    static void ConcatTwoTextFiles(StreamReader reader1, StreamReader reader2)
    {
        //append text from first file to the result file
        //the output file is created in the folder of the current project
        using (reader1)
        {
            StreamWriter writer = new StreamWriter(@"../../output.txt", true, Encoding.GetEncoding("Windows-1251"));
            using (writer)
            {
                string currLine = reader1.ReadLine();
                while (currLine != null)
                {
                    writer.WriteLine(currLine);
                    currLine = reader1.ReadLine();
                }
            }
        }
        //append text from second file to the result file
        using (reader2)
        {
            StreamWriter writer = new StreamWriter(@"../../output.txt", true, Encoding.GetEncoding("Windows-1251"));
            using (writer)
            {
                string currLine = reader2.ReadLine();
                while (currLine != null)
                {
                    writer.WriteLine(currLine);
                    currLine = reader2.ReadLine();
                }
            }
        }
    }
    
    static void Main()
    {
        StreamReader reader1 = new StreamReader(@"../../ConcatenateTwoTextFiles.cs", Encoding.GetEncoding("Windows-1251"));
        StreamReader reader2 = new StreamReader(@"../../text2.txt", Encoding.GetEncoding("Windows-1251"));
        ConcatTwoTextFiles(reader2, reader1);
    }
}

