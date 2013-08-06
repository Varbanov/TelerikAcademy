using System;
using System.Text;

class BinToHex
{
    //06.Write a program to convert binary numbers to hexadecimal numbers (directly).

    static void BinaryToHexadecimal(string bin)
    {
        StringBuilder hex = new StringBuilder();

        int power = 0;
        int tempNum = 0;
        for (int i = bin.Length - 1; i >= 0; i--)
        {
            tempNum += int.Parse(bin[i].ToString()) * (int) Math.Pow(2, power);
            if (power == 3 || i == 0)
            {
                power = -1;
                switch (tempNum)
                {
                    case 10: hex.Append('A');
                        break;
                    case 11: hex.Append('B');
                        break;
                    case 12: hex.Append('C');
                        break;
                    case 13: hex.Append('D');
                        break;
                    case 14: hex.Append('E');
                        break;
                    case 15: hex.Append('F');
                        break;
                    case 16: hex.Append('A');
                        break;
                    default: hex.Append(tempNum);
                        break;
                }
                tempNum = 0;
            }
            power++;
        }
        for (int i = hex.Length - 1; i >= 0; i--)
        {
            Console.Write(hex[i]);
        }
        Console.WriteLine();
    }

    static void Main()
    {
        Console.Write("Please enter a binary number: ");
        string bin = Console.ReadLine();
        BinaryToHexadecimal(bin);
    }
}
