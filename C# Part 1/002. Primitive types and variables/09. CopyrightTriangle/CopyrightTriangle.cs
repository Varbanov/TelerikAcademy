using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    /*Write a program that prints an isosceles triangle of 9 copyright symbols ©. Use Windows Character Map
     * to find the Unicode code of the © symbol. Note: the © symbol may be displayed incorrectly. 00A9
     */
    static void Main()
    {
        //To have the copyright symbol printed correctly on your PC, please ensure you have chosen correct
        //Font (Consolas or Lucida Console) setting for your PC's Console
        
        Console.OutputEncoding = Encoding.UTF8;
        
        //Change numOfRows value to build a triangle as big as you want
        int numOfRows = 3;
        int blankMaxLegth = (2 * numOfRows - 1) / 2;
        for (int i = 1; i <= numOfRows; i++)
        {
            string blank = new String(' ', blankMaxLegth);
            string copyRight = new String('\u00A9', (i * 2) - 1);

            Console.Write("{0}{1}{2}", blank, copyRight, blank);
            Console.WriteLine();
            blankMaxLegth--;
        }
    }
}

