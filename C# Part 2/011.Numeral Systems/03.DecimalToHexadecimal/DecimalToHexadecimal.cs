using System;
using System.Text;

class DecimalToHexadecimal
{
    //03.Write a program to convert decimal numbers to their hexadecimal representation.

    static void Main()
    {
        int n;
        do
        {
            Console.Write("Please enter an integer n [n > 0]: ");
        } while (!int.TryParse(Console.ReadLine(), out n) || n < 0);

        StringBuilder hex = new StringBuilder();
        while (n > 0)
        {
            if ((n % 16) < 10)
            {
                hex.Append(n % 16);
            }
            else
            {
                switch (n % 16)
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
                }
            }
            n /= 16;
        }
        for (int i = hex.Length - 1; i >= 0; i--)
        {
            Console.Write(hex[i]);
        }
        Console.WriteLine();
    }
}
