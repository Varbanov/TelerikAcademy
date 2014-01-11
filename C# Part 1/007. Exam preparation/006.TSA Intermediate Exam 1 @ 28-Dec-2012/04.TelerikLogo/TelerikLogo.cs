using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class TelerikLogo
{
    static void Main()
    {
        int x = int.Parse(Console.ReadLine());

        int width = 2 * x - 1 + 2 * ((x + 1) / 2 - 1);

        //first line
        int firstOuterDot = (width - (2 * x) + 1) / 2;
        string firstOuterDots = new string('.', firstOuterDot);
        string firstInnerDots = new string('.', width - firstOuterDot * 2 - 2);
        Console.Write(firstOuterDots);
        Console.Write("*");
        Console.Write(firstInnerDots);
        Console.Write("*");
        Console.WriteLine(firstOuterDots);
        //


        int outerDot = (width - 2 * x + 1) / 2 - 1;
        int innerDot = 2 * x - 5;
        int middleDot = 1;
        int z = (x + 1) / 2;


        for (int i = 0; i < z -1; i++)
        {
            string outerDots = new string('.', outerDot);
            Console.Write(outerDots + "*");
            
            string middleDots = new string('.', middleDot);
            Console.Write(middleDots + "*");

            string innerDots = new string('.', innerDot);
            Console.Write(innerDots + "*");

            Console.Write(middleDots + "*");
            Console.Write(outerDots);

            outerDot--;
            middleDot += 2;
            innerDot -= 2;
            Console.WriteLine();
        }

        for (int i = innerDot; i > 0; i -= 2)
        {
            string innerDots = new string('.', i);
            string outerDots = new string('.', (width - i - 2) / 2);

            Console.WriteLine(outerDots + "*" + innerDots + "*" + outerDots);

        }

        //middle line
        int outerd = (width - 1) / 2;
        string middleLineDots = new string('.', outerd);
        Console.WriteLine(middleLineDots + "*" + middleLineDots);

        //lower part
        for (int i = 0, middle = 1; i < x - 1; i++)
        {
            outerd = (width - 2 - middle) / 2;
            string outerDots = new string('.', outerd);
            Console.Write(outerDots + "*");

            string middleDots = new string('.', middle);
            Console.Write(middleDots + "*");

            Console.WriteLine(outerDots);

            outerd--;
            middle += 2;

        }

        //final part
        int outer = (width - (2 * x)) / 2 + 2;

        for (int i = 0, inner = width - 2 * outer - 2; i < x - 2; i++, inner -= 2)
        {
            string outerdots = new string('.', outer);
            Console.Write(outerdots + "*");

            string innerdots = new string('.', inner);
            Console.WriteLine(innerdots + "*" + outerdots);

            outer++;
        }


        //final line
        int outerddd = (width - 1) / 2;
        string middleLineDotsss = new string('.', outerddd);
        Console.WriteLine(middleLineDotsss + "*" + middleLineDotsss);

    }
}

