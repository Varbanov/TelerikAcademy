using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class EscapingSequence
{
    /* Declare two string variables and assign them with following value:
    The "use" of quotations causes difficulties.
	Do the above in two different ways: with and without using quoted strings.
     * */
    static void Main()
    {
        string firstVar = "The \"use\" of quotations causes difficulties.";

        string secondVar = @"The ""use"" of quotations causes difficulties.";

        Console.WriteLine(firstVar);
        Console.WriteLine(secondVar);
    }
}

