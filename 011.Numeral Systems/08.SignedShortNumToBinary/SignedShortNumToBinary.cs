using System;
using System.Text;

class SignedShortNumToBinary
{
    //09.Write a program that shows the binary representation of given 16-bit signed integer number (the C# type short).
    static string ConvertShortToBin(int num)
    {
        StringBuilder reversed = new StringBuilder();
        if (num > 0)
        {
            while (num > 0)
            {
                reversed.Append(num % 2);
                num /= 2;
            }
        }
        else
        {
            int leftBitsNum = ~(Math.Abs(num) - 1);
            for (int i = 0; i < 15; i++)
            {
                reversed.Append((leftBitsNum & 1).ToString());
                leftBitsNum >>= 1;
            }
            reversed.Append("1");
        }
        //reversing
        StringBuilder result = new StringBuilder();
        for (int i = reversed.Length - 1; i >= 0; i--)
        {
            result.Append(reversed[i]);
        }
        return result.ToString();

    }

    static void Main()
    {
        //data input
        short num;
        do
        {
            Console.Write("Please enter a short number: ");
        } while (!short.TryParse(Console.ReadLine(), out num));

        //data output
        string res = ConvertShortToBin(num);
        for (int i = 0; i < res.Length; i++)
        {
            if (i % 4 == 0)
                Console.Write(" ");
            Console.Write(res[i]);
        }
        Console.WriteLine();
    }
}

