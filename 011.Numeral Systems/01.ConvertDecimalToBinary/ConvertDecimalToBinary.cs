using System;
using System.Text;

class ConvertDecimalToBinary
{
    //01.Write a program to convert decimal numbers to their binary representation.

    static void ConvertDecToBin(int num)
    {
        Console.WriteLine("Decimal: {0}", num);
        StringBuilder binary = new StringBuilder();
        if (num == 0)
        {
            Console.WriteLine("Binary: \n0");
            return;
        }
        else if (num > 0)
        {
            //slower solution, but using the presentation slides
            while (num > 0)
            {
                binary.Append((num % 2).ToString());
                num /= 2;
            }
        }
        else if (num < 0)
        {
            for (int i = 0; i < 31; i++)
            {
                binary.Append(((num >> i) & 1).ToString());
            }
        }
        //output
        Console.WriteLine("Binary:");
        for (int i = binary.Length - 1; i >= 0; i--)
        {
            Console.Write(binary[i]);
        }
        Console.WriteLine();
    }

    static void Main()
    {
        //test
        int num;
        do
        {
            Console.Write("Please enter an int number: ");
        } while (!int.TryParse(Console.ReadLine(), out num));

        ConvertDecToBin(num);
    }
}
