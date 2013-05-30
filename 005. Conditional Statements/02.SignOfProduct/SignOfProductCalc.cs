using System;

class SignOfProductCalc
{
    //Write a program that shows the sign (+ or -) of the product of three real numbers
    //without calculating it. Use a sequence of if statements.

    static void Main()
    {
        //input
        int first, second, third;
        do
        {
            Console.Write("Please enter first integer:");
        } while (!int.TryParse(Console.ReadLine(), out first));

        do
        {
            Console.Write("Please enter second integer:");
        } while (!int.TryParse(Console.ReadLine(), out second));

        do
        {
            Console.Write("Please enter third integer:");
        } while (!int.TryParse(Console.ReadLine(), out third));

        //solution and output
        if (first == 0 || second == 0 || third == 0)
        {
            Console.WriteLine("The product is zero!");
            return;
        }
        if (first >= 0)
        {
            if (second >= 0 && third >= 0 || second < 0 && third < 0)
            {
                Console.WriteLine("The sign is \"+\"");
            }
            else if (second < 0 ^ third < 0 || third < 0 ^ second < 0)
            {
                Console.WriteLine("The sign is \"-\"");
            }
        }
        else
        {
            if (second < 0 ^ third < 0)
            {
                Console.WriteLine("The sign is \"+\"");
            }
            else if (second < 0 && third < 0 || second >= 0 && third >= 0)
            {
                Console.WriteLine("The sign is \"-\"");
            }
        }

    }
}

