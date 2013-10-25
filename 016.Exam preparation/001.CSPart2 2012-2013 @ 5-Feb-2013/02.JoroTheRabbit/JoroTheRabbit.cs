using System;
using System.Collections.Generic;
using System.Text;

class JoroTheRabbit
{
    static int[] ExtractNumsFromInput(string input)
    {
        string[] tokens= input.Split(new char[] {',', ' '}, StringSplitOptions.RemoveEmptyEntries);
        int[] field = new int[tokens.Length];
        for (int i = 0; i < tokens.Length; i++)
        {
            field[i] = int.Parse(tokens[i]);
        }
        return field;
    }

    static int JoroJumps(int[] field)
    {
        int maxCounter = int.MinValue;

        for (int i = 0; i < field.Length; i++)
        {
            int startIndex = i;

            for (int step = 1; step <= field.Length; step++)
            {
                int tempCounter = 1;
                int nextIndex = (startIndex + step) % field.Length;
                    
                while (field[nextIndex] > field[startIndex])
                {
                    tempCounter++;
                    startIndex = nextIndex;
                    nextIndex = startIndex + step <= field.Length - 1 ? startIndex + step : startIndex + step - field.Length;
                }
                if (tempCounter > maxCounter)
                {
                    maxCounter = tempCounter;
                }
                startIndex = i;
            }
        }
        return maxCounter;
    }

    static void Main()
    {
        string input = Console.ReadLine();
        int[] field = ExtractNumsFromInput(input);
        Console.WriteLine(JoroJumps(field));
    }
}

