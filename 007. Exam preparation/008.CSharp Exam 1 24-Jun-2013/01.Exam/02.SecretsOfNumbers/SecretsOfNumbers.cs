using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class SecretsOfNumbers
{
    static void Main()
    {
        string n = Console.ReadLine();
        int specialSum = 0;

        for (int i = n.Length - 1; i >= 0; i--)
        {
            if ((n.Length - i) % 2 != 0)
            {
                switch (n[i])
                {
                    case '1': specialSum += (1 * (n.Length - i) * (n.Length - i));
                        break;
                    case '2': specialSum += (2 * (1 * (n.Length - i) * (n.Length - i)));
                        break;
                    case '3': specialSum += (3 * (1 * (n.Length - i) * (n.Length - i)));
                        break;
                    case '4': specialSum += (4 * (1 * (n.Length - i) * (n.Length - i)));
                        break;
                    case '5': specialSum += (5 * (1 * (n.Length - i) * (n.Length - i)));
                        break;
                    case '6': specialSum += (6 * (1 * (n.Length - i) * (n.Length - i)));
                        break;
                    case '7': specialSum += (7 * (1 * (n.Length - i) * (n.Length - i)));
                        break;
                    case '8': specialSum += (8 * (1 * (n.Length - i) * (n.Length - i)));
                        break;
                    case '9': specialSum += (9 * (1 * (n.Length - i) * (n.Length - i)));
                        break;
                }
            }
            else
            {
                switch (n[i])
                {
                    case '1': specialSum += (1 * (n.Length - i));
                        break;
                    case '2': specialSum += (2 * 2 * (n.Length - i));
                        break;
                    case '3': specialSum += (3 * 3 * (n.Length - i));
                        break;
                    case '4': specialSum += (4 * 4 * (n.Length - i));
                        break;
                    case '5': specialSum += (5 * 5 * (n.Length - i));
                        break;
                    case '6': specialSum += (6 * 6 * (n.Length - i));
                        break;
                    case '7': specialSum += (7 * 7 * (n.Length - i));
                        break;
                    case '8': specialSum += (8 * 8 * (n.Length - i));
                        break;
                    case '9': specialSum += (9 * 9 * (n.Length - i));
                        break;
                }
            }
        }
        Console.WriteLine(specialSum);

        int lastDigitOfSpecialSum = specialSum % 10;
        int r = (specialSum % 26) + 1;
        
        if (lastDigitOfSpecialSum == 0)
        {
            Console.WriteLine("{0} has no secret alpha-sequence", n);
        }
        else
        {
            int currCharIndex = 64 + r;
            for (int i = 0; i < lastDigitOfSpecialSum; i++)
            {
                if (currCharIndex <= 64 + 26)
                {
                    Console.Write((char)(currCharIndex));
                }
                else
                {
                    currCharIndex = 65;
                    Console.Write((char)(currCharIndex));
                }

                currCharIndex++;
            }
        }
    }
}

