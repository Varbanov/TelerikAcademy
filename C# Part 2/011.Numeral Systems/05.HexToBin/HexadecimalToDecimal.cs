using System;
using System.Text;

class HexadecimalToDecimal
{
    //05.Write a program to convert hexadecimal numbers to binary numbers (directly).
    static string HexToBin(string hex)
    {
        StringBuilder dec = new StringBuilder();
        for (int i = 0; i < hex.Length; i++)
        {
            switch (hex[i])
            {
                case '0': dec.Append("0000");
                    break;
                case '1': dec.Append("0001");
                    break;
                case '2': dec.Append("0010");
                    break;
                case '3': dec.Append("0011");
                    break;
                case '4': dec.Append("0100");
                    break;
                case '5': dec.Append("0101");
                    break;
                case '6': dec.Append("0110");
                    break;
                case '7': dec.Append("0111");
                    break;
                case '8': dec.Append("1000");
                    break;
                case '9': dec.Append("1001");
                    break;
                case 'a':
                case 'A':
                    dec.Append("1010");
                    break;
                case 'b':
                case 'B':
                    dec.Append("1011");
                    break;
                case 'c':
                case 'C':
                    dec.Append("1100");
                    break;
                case 'd':
                case 'D':
                    dec.Append("1101");
                    break;
                case 'e':
                case 'E':
                    dec.Append("1110");
                    break;
                case 'f':
                case 'F':
                    dec.Append("1111");
                    break;
            }
        }
        return dec.ToString();
    }

    static void Main()
    {
        Console.Write("Please enter a hex number: ");
        string hex = Console.ReadLine();
        Console.WriteLine(HexToBin(hex));
    }
}

