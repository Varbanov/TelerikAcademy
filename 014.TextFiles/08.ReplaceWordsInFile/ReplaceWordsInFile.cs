using System;
using System.Text;
using System.IO;

class ReplaceWordsInFile
{
    //08.Modify the solution of the previous problem to replace only whole words (not substrings).
    //07.Write a program that replaces all occurrences of the substring "start" with the
    //substring "finish" in a text file. Ensure it will work with large files (e.g. 100 MB).

    static void ReplaceStartWithFinish(string inputPath, string outputPath)
    {
        StreamReader reader = new StreamReader(inputPath);
        StreamWriter writer = new StreamWriter(outputPath);
        using (reader)
        using (writer)
        {
            string currLine = reader.ReadLine();
            while (currLine != null)
            {
                int start = 0;
                int index = currLine.IndexOf("start");
                StringBuilder line = new StringBuilder();

                if (index != -1)
                {
                    //while string start is present
                    while (index != -1)
                    {
                        //if "start" is a separate word, append line to it + finish and proceed with the rest of the line
                        if ((index > 0 && !char.IsLetter(currLine[index - 1]) || index == 0) && 
                            ((index + 5 <= currLine.Length - 1 && !char.IsLetter(currLine[index + 5])) || index + 5 > currLine.Length - 1))
                        {
                            for (int i = start; i < index; i++)
                            {
                                line.Append(currLine[i]);
                            }
                            line.Append("finish");
                            start = index + 5;
                        }
                        //if "start" is a substring, append the line as is to the current position and proceed with the rest of the line
                        else
                        {
                            int counter = 0;
                            for (int i = start; i <= index + 4; i++)
                            {
                                line.Append(currLine[i]);
                                counter++;
                            }
                            start = start + counter;
                        }
                        index = currLine.IndexOf("start", start);
                        //if no more "start" substrings are found, append the rest of the line as is
                        if (index < 0 && start < currLine.Length)
                        {
                            for (int i = start; i < currLine.Length; i++)
                            {
                                line.Append(currLine[i]);
                            }
                        }
                    }
                    currLine = reader.ReadLine();
                    writer.WriteLine(line);
                }
            }
        }
    }

    static void Main()
    {
        ReplaceStartWithFinish(@"..\..\input.txt", @"..\..\output.txt");

        /*A more straightforward solution is to append a whole line in a Stringbuilder object line and manipulate it as in the following example:
          
            StringBuilder line = new StringBuilder();
            while (reader.Peek() != -1)
            {
                line.Clear();
                line.Append(reader.ReadLine());
                string currentLine = line.ToString();
                int seekFromIndex = 0;
                while (true)
                {
                    int index = currentLine.IndexOf("start", seekFromIndex);
                    if (index == -1)
                    {
                        break;
                    }
                    if ((index != 0 && char.IsLetter(currentLine[index - 1])) ||
                        (index != currentLine.Length - 5 && char.IsLetter(currentLine[index + 5])))
                    {
                        seekFromIndex = index + 5;
                        continue;
                    }
                    line.Replace("start", "end", index, 5);
                    seekFromIndex = index + 3;
                }
                writer.WriteLine(line);

            }
          */

    }
}