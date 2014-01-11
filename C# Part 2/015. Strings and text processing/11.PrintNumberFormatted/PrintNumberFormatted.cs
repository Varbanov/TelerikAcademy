using System;

class PrintNumberFormatted
{
    //11. Write a program that reads a number and prints it as a decimal number, hexadecimal number, 
    //percentage and in scientific notation. Format the output aligned right in 15 symbols.

    static void PrintFormatted(int number)
    {
        Console.WriteLine("{0,15:D}", number); //decimal
        Console.WriteLine("{0,15:X}", number); //hexadecimal
        Console.WriteLine("{0,15:P}", number); //percentage
        Console.WriteLine("{0,15:E}", number); //scientific notation
    }

    static void Main()
    {
        //input
        int num;
        do
        {
        Console.Write("Please enter an integer:");
            
        } while (!int.TryParse(Console.ReadLine(), out num));
        //solution
        PrintFormatted(num);
    }
}
