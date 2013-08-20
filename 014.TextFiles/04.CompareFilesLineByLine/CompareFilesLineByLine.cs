using System;
using System.Text;
using System.IO;

class CompareFilesLineByLine
{
    //Write a program that compares two text files line by line and prints the number of lines that
    //are the same and the number of lines that are different. Assume the files have equal number of lines.

    static void Main()
    {
        int same = 0, different = 0;
        
        var file1 = File.ReadLines(@"..\..\file1.txt").GetEnumerator();
        foreach (var line2 in File.ReadLines(@"..\..\file2.txt")) 
        {
            if (!file1.MoveNext())
            {
                //MoveNext() returns true if a new line is read and false if there is no more lines to read
                break;
            }
            if (file1.Current == line2)
                same += 1;
            else
                different += 1;
        }
        Console.WriteLine("Same lines: {0}", same);
        Console.WriteLine("Different lines: {0}", different);
    }
}

