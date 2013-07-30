using System;
using System.Text;

class ReversingOfDigits
{
    //Write a method that reverses the digits of given decimal number. Example: 256  652
    static decimal ReverseDigitsOfDecimal(decimal num)
    {
        StringBuilder reverse = new StringBuilder();
        string numStr = num.ToString();
        //append each digit of num from right to left to reverse
        for (int i = numStr.Length - 1; i >= 0;  i--)
        {
            reverse.Append(numStr[i]);
        }
        decimal result = decimal.Parse(reverse.ToString());
        return result;
    }

    static void Main()
    {
        decimal num = ReverseDigitsOfDecimal(256m);
        Console.WriteLine(num);
    }
}
