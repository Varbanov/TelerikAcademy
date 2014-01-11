using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class CharUnicodeDeclaration
{
    /* Declare a character variable and assign it with the symbol that has Unicode code 72. 
     * Hint: first use the Windows Calculator to find the hexadecimal representation of 72. 48
    */
    static void Main()
    {
        char var = '\u0048';

        Console.WriteLine(var);
    }
}

