using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Carpets
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        int slashCount = 0;

        //UPPER HALF
        for (int rows = 1, outerDot = (n / 2) - 1; rows <= n / 2 ; rows++, outerDot -= 1)
        {
            //outer dots
            string outerDots = new string('.', outerDot);
            Console.Write(outerDots);

            //left slashes
            if (rows % 2 != 0)
            {
                slashCount += 1;
            }

            for (int i = 0; i < slashCount - 1; i++)
            {
                Console.Write("/ ");
            }
            Console.Write("/");

            //inner dots
            if (rows % 2 == 0)
            {
                Console.Write("  ");
            }

            //right slashes
            for (int i = 0; i < slashCount - 1; i++)
            {
                Console.Write("\\ ");
            }
            Console.Write("\\");

            //outer dots
            Console.Write(outerDots);
            //end of line
            Console.WriteLine();
        }

        //LOWER HALF

        // if(...) = if the first line of the lower half is odd or even, i.e. if odd -> first line inner space is two, first line + 2 inner space = 2, etc.
        if (((n / 2) + 1) % 2 != 0) 
        {
            for (int rows = (n / 2) + 1, outerDot = 0; rows <= n; rows++, outerDot++)
            {
                //outer dots
                string outerDots = new string('.', outerDot);
                Console.Write(outerDots);

                //left slashes
                for (int i = 0; i < slashCount - 1; i++)
                {
                    Console.Write("\\ ");
                }
                Console.Write("\\");


                //inner dots
                if (((n / 2) + 1) % 2 == 0)
                {
                    if (rows % 2 == 0)
                    {
                        Console.Write("  ");
                    }
                }
                else if (rows % 2 != 0)
                {
                    Console.Write("  ");
                }

                //right slashes
                for (int i = 0; i < slashCount - 1; i++)
                {
                    Console.Write("/ ");
                }
                Console.Write("/");

                if (rows % 2 == 0)
                {
                    slashCount--;
                }

                //outer dots
                Console.Write(outerDots);

                //end of line
                Console.WriteLine();
            }
        }
        else
        //= if the first line of the lower half is even, i.e. if even -> no inner space on first line, first line + 2, first line + 4 etc.
        {
            for (int rows = (n / 2) + 1, outerDot = 0; rows <= n; rows++, outerDot++)
            {
                //outer dots
                string outerDots = new string('.', outerDot);
                Console.Write(outerDots);

                if (rows % 2 != 0)
                {
                    
                }

                //left slashes
                for (int i = 0; i < slashCount - 1; i++)
                {
                    Console.Write("\\ ");
                }
                Console.Write("\\");


                //inner dots
                if (rows % 2 != 0)
                {
                    Console.Write("  ");
                }
                
                else if (rows % 2 != 0)
                {
                    Console.Write("  ");
                }

                //right slashes
                for (int i = 0; i < slashCount - 1; i++)
                {
                    Console.Write("/ ");
                }
                Console.Write("/");

                if (rows % 2 == 0)
                {
                    slashCount--;
                }

                //outer dots
                Console.Write(outerDots);

                //end of line
                Console.WriteLine();
            }
        }
    }
}

