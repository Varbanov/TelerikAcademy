using System;

class InputIntDoubleOrString
{
    /*Write a program that, depending on the user's choice inputs int, double or string variable. 
    If the variable is integer or double, increases it with 1. If the variable is string, appends "*" 
     * at its end. The program must show the value of that variable as a console output. Use switch statement.
    */
    static void Main()
    {
        string userChoice;
        Console.WriteLine("Please enter \"integer\", \"double\" or \"string\" to choose type of data:");
        userChoice = Console.ReadLine();

        if (userChoice != "integer" && userChoice != "double" && userChoice != "string")
        {
            Main();
        }
        switch (userChoice)
        {
            case "integer": int inum;
                do
	            {
	                Console.Write("You chose integer! Please enter it: ");
	            } while (!int.TryParse(Console.ReadLine(), out inum));
                Console.WriteLine("\nYour new integer value: {0}", ++inum);
                break;
            case "double": double fnum; 
                do
                {
                    Console.Write("You chose double! Please enter it: ");
                } while (!double.TryParse(Console.ReadLine(), out fnum));
                Console.WriteLine("\nYour new double value: {0}", ++fnum);
                break;
            case "string": Console.WriteLine("You chose string! Please enter it: ");
                string str = Console.ReadLine();
                Console.WriteLine("Your new string value: {0}", str + "*");
                break;
        }
    }
}

