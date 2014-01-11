using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class AstrologicalDigits
{

    static int AstroDigit(string n)
    {
        int sum = 0;
        foreach (var digit in n)
        {
            bool isNum;
            int tempDigit;
            switch (digit)
            {
                case '1': isNum = true; tempDigit = 1;
                    break;
                case '2': isNum = true; tempDigit = 2;
                    break;
                case '3': isNum = true; tempDigit = 3;
                    break;
                case '4': isNum = true; tempDigit = 4;
                    break;
                case '5': isNum = true; tempDigit = 5;
                    break;
                case '6': isNum = true; tempDigit = 6;
                    break;
                case '7': isNum = true; tempDigit = 7;
                    break;
                case '8': isNum = true; tempDigit = 8;
                    break;
                case '9': isNum = true; tempDigit = 9;
                    break;
                default: isNum = false; tempDigit = 0;
                    break;
            }

            if (isNum)
            {
                sum += tempDigit;
            }
        }

        if (sum <= 9)
        {
            return sum;
        }
        else 
        {
            return AstroDigit(sum.ToString());
        }
    }

    static void Main()
    {
        string n = Console.ReadLine();
        Console.WriteLine(AstroDigit(n));
    }
}

