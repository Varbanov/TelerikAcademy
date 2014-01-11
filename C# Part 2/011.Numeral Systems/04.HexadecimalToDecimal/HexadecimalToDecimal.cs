using System;
using System.Text;

class HexadecimalToDecimal
{
    //4.Write a program to convert hexadecimal numbers to their decimal representation.

    static int HexToDec(string hex)
    {
        int dec = 0;
        for (int i = hex.Length - 1; i >= 0; i--)
        {
            int currDigit;
            switch (hex[i])
            {
                case 'A':
                case 'a':
                    currDigit = 10;
                    break;
                case 'B':
                case 'b':
                    currDigit = 11;
                    break;
                case 'C':
                case 'c':
                    currDigit = 12;
                    break;
                case 'D':
                case 'd':
                    currDigit = 13;
                    break;
                case 'E':
                case 'e':
                    currDigit = 14;
                    break;
                case 'F':
                case 'f':
                    currDigit = 15;
                    break;
                default: currDigit = int.Parse(hex[i].ToString());
                    break;
            }
            dec += currDigit * (int)Math.Pow(16, hex.Length-1-i);
        }
        return dec;
    }

    static void Main()
    {
        Console.WriteLine("Please enter a hex number: ");
        string hex = Console.ReadLine();
        Console.WriteLine(HexToDec(hex));
    }
}

