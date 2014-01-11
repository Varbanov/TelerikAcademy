using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class PrintASCIItable
{
    /*Find online more information about ASCII (American Standard Code for Information Interchange) and
     * write a program that prints the entire ASCII table of characters on the console.
    */
    static void Main()
    {
        //To change readability options uncomment next line
        Console.OutputEncoding = Encoding.UTF8;

        Console.WriteLine("The extended ASCII table consists of the following symbols:");
        for (int i = 0; i <= 255; i++)
        {
            Console.Write((char) i + " ");
        }
    }
}

