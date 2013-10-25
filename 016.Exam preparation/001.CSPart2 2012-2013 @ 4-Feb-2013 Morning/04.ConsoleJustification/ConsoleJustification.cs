using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class ConsoleJustification
{
    static void Main()
    {
        //input
        int n = int.Parse(Console.ReadLine());
        int w = int.Parse(Console.ReadLine());
        
        StringBuilder text = new StringBuilder();
        for (int i = 0; i < n; i++)
        {
            text.Append(Console.ReadLine());
            text.Append(" ");
        }
        //extract all the words in the text
        string[] words = text.ToString().Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);

        int endWordIndex = 0;
        int startWordIndex = 0;
        int lineLength = words[0].Length;
        StringBuilder line = new StringBuilder();

        while (endWordIndex < words.Length - 1)
        {
            line.Clear();
            while (endWordIndex < words.Length - 1 && lineLength + words[endWordIndex + 1].Length < w)
            {
                //count how many words, separated from each other by a single whitespace, can be
                //written on a single line with length less than w, and extract the indexes of
                //the first and the last word
                lineLength += words[endWordIndex + 1].Length + 1;
                endWordIndex++;
            }

            //calculate gaps length
            int gaps = endWordIndex - startWordIndex;
            int lengthOfGaps;
            int excessiveGaps;

            //the if-else ensures that no divide by zero exception will occur if gaps == 0
            if (gaps > 0)
            {
                lengthOfGaps = (w - lineLength) / gaps + 1;

                //excessive gaps are always less than the number of gaps, so they
                //can always be distributed among the first gaps, one at a gap
                excessiveGaps = (w - lineLength) % gaps;
            }
            else
            {
                lengthOfGaps = 0;
                excessiveGaps = 0;
            }

            for (int word = startWordIndex; word <= endWordIndex; word++)
            {
                //construct a whole justified line
                line.Append(words[word]);
                if (word < endWordIndex)
                {
                    line.Append(new String(' ', lengthOfGaps));

                    if (excessiveGaps > 0)
                    {
                        line.Append(" ");
                        excessiveGaps--;
                    }
                }
            }

            Console.WriteLine(line);

            if (endWordIndex + 1 < words.Length)
            {
                //the if ensures that  [endwordIndex + 1] is always a valid index in the words[] array
                //in case the last line is reached and it consists of more than one word
                lineLength = words[endWordIndex + 1].Length;
            }
            endWordIndex++;
            startWordIndex = endWordIndex;
        }

        if (startWordIndex < words.Length)
        {
            Console.WriteLine(words[startWordIndex]);
        }
    }
}

