using System;

class ConvertBinaryToDecimal
{
    //02.Write a program to convert binary numbers to their decimal representation.

    static int ConvertBinToDec(string binary)
    {
        int decimalN = 0;
        for (int position = 0; position < binary.Length; position++)
        {
            //update position
            decimalN = decimalN << 1;
            //add 1 if present
            if (binary[position] == '1')
            {
                decimalN ^= 1;
            }
        }
        return decimalN;
    }

    static void Main()
    {
        Console.Write("Please enter a binary number: ");
        string binary = Console.ReadLine();
        Console.WriteLine(ConvertBinToDec(binary));
    }
}

