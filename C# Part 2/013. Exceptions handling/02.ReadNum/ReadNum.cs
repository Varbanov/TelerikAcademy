using System;

class ReadNum
{
    //02. Write a method ReadNumber(int start, int end) that enters an integer number in given range [start…end].
    //If an invalid number or non-number text is entered, the method should throw an exception. 
    //Using this method write a program that enters 10 numbers:
    //a1, a2, … a10, such that 1 < a1 < … < a10 < 100

    static int ReadNumber(int start, int end)
    {
        int num;
        if (!int.TryParse(Console.ReadLine(), out num))
        {
            throw new FormatException("Invalid number!");
        }
        if (num <= start || num >= end)
        {
            throw new ArgumentOutOfRangeException(string.Format("The number must be between {0} and {1}! ", start, end));
        }
        return num;
    }

    static void Main()
    {
        try
        {
            int start = 1;
            int end = 100;
            int[] res = new int[10];
            for (int i = 0; i < 10; i++)
            {
                res[i] = ReadNumber(start, end);
                start = res[i];
            }
        }
        catch (ArgumentOutOfRangeException rangeEx)
        {
            Console.WriteLine(rangeEx.Message);
        }
        catch (FormatException fe)
        {
            Console.WriteLine(fe.Message);
        }
    }
}