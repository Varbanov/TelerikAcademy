using System;
using System.Text;
using System.IO;

class ReplaceSubstringInFile
{
    //Write a program that replaces all occurrences of the substring "start" with the
    //substring "finish" in a text file. Ensure it will work with large files (e.g. 100 MB).

    static void ReplaceStartWithFinish(string inputPath, string outputPath)
    {
        StreamReader reader = new StreamReader(inputPath);
        StreamWriter writer = new StreamWriter(outputPath);
        using (reader)
        {
            using (writer)
            {
            string currLine = reader.ReadLine();
                while (currLine != null)
                {
                    string replaced = currLine.Replace("start", "finish");
                    currLine = reader.ReadLine();
                    writer.WriteLine(replaced);
                }
            }
        }
    }

    static void Main()
    {
        ReplaceStartWithFinish(@"..\..\input.txt", @"..\..\output.txt");
        //to replace the two files and obtain the result in the input.txt file, uncomment the next line
        //File.Replace(@"..\..\output.txt", @"..\..\input.txt", @"..\..\last_input.txt");
    }
}

