using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class SequenceMembers
{
    //Write a program that prints the first 10 members of the sequence: 2, -3, 4, -5, 6, -7, ...

    static void Main()
    {
        for (int i = 2; i < 12; i++)
        {
            int num = i * (int) Math.Pow(-1, i);
            Console.Write("{0}, ", num);
        }
    }
}