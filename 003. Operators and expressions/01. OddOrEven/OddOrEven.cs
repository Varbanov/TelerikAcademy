using System;

class OddOrEven
{   
    /*Write an expression that checks if given integer is odd or even.
    */
    static void Main()
    {
        int num;

        //number input
        do
        {
            Console.Write("Please enter an integer: ");
        }
        while (!int.TryParse(Console.ReadLine(), out num));

        //result output
        if (num % 2 == 0)
        {
            Console.WriteLine("The number entered is even!");
        }
        else
        {
            Console.WriteLine("The number entered is odd!");
        }

    }
}

