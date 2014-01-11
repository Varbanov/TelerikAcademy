using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

class DeleteWordsWithPrefixes
{
    //11.Write a program that deletes from a text file all words that start with the prefix "test". 
    //Words contain only the symbols 0...9, a...z, A…Z, _.

    static void DeleteTestWords(string path)
    {
        StreamReader reader = new StreamReader(path);
        List<string> correctedLines = new List<string>();

        using (reader)
        {
            while (reader.Peek() != -1)
            {
                //read a line and append it to the stringbuilder
                StringBuilder line = new StringBuilder();
                line.Append(reader.ReadLine());

                while (true)
                {
                    //initialize the same string as the stringbuilder and search for test words in it
                    string str = line.ToString();

                    int index;
                    if (str.IndexOf("test") == 0)
                    {
                        //if the first word is a test word
                        index = 0;
                    }
                    else
                    {
                        //the whitespace ensures that test is at the beginning of a word
                        index = str.IndexOf(" test");
                        if (index == -1)
                            break;
                    }
                    //"word" will hold the whole test word that is found
                    StringBuilder word = new StringBuilder();
                    int seekAt;
                    if (index == 0)
                    {
                        seekAt = 0;
                    }
                    else
                    {
                        //if the test word is in the middle of the line, remove it with the unnecessary whitespace
                        seekAt = index + 1;
                        word.Append(" ");
                    }
                    while (seekAt < str.Length && (char.IsDigit(str[seekAt]) || char.IsLetter(str[seekAt]) || str[seekAt] == '_'))
                    {
                        word.Append(str[seekAt]);
                        seekAt++;
                    }
                    line.Replace(word.ToString(), "", index, word.Length);
                }
                //save output line
                correctedLines.Add(line.ToString().Trim());
            }
        }

        //overwrite file
        StreamWriter writer = new StreamWriter(@"..\..\output.txt");
        using (writer)
        {
            foreach (var line in correctedLines)
            {
                writer.WriteLine(line);
            }
        }
    }

    static void Main()
    {
        string path = @"..\..\input.txt";
        DeleteTestWords(path);
        //A more straightforward solution is to use regex...
    }
}
