using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class ANacci
{
    static int Next(int first, int second)
    {
        int third;
        if ((first + second) > 26)
        {
            third = (first + second) % 26;
        }
        else
        {
            third = (first + second);
        }
        return third;
    }

    static void Main()
    {
        string f = Console.ReadLine();
        string s = Console.ReadLine();
        int lines = int.Parse(Console.ReadLine());

        int first = (int)f[0] - 64;
        int second = (int)s[0] - 64;

        if (lines == 1)
        {
            Console.WriteLine((char)(first + 64));
        }
        else if (lines == 2)
        {
            int third = Next(first, second);

            Console.WriteLine((char)(first + 64));
            Console.Write((char)(second + 64));
            Console.WriteLine((char)(third + 64));
        }
        else if (lines > 2)
        {
            //first two lines
            int third = Next(first, second);
            Console.WriteLine((char)(first + 64));
            Console.Write((char)(second + 64));
            Console.WriteLine((char)(third + 64));
            first = second;
            second = third;
            //next lines
            for (int i = 1; i <= lines - 2; i++)
            {
                int next = Next(first, second);
                string blanks = new string(' ', i);
                Console.Write((char)(next + 64));
                Console.Write(blanks);

                first = second;
                second = next;
                next = Next(first, second);
                Console.Write((char)(next + 64));

                first = second;
                second = next;

                Console.WriteLine();
            }

        }

        
    }
}

