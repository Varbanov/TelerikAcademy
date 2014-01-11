using System;

class GreaterOfThreeInts
{
    //Write a program that finds the biggest of three integers using nested if statements.
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
        if (first >= second)
        {
            if (first > third)
            {
                Console.WriteLine("The first number is the biggest!");
            }
            else
            {
                Console.WriteLine("The third number is the biggest!");
            }
        }
        else if (second < third)
        {
            Console.WriteLine("The third number is the biggest!");
        }
        else Console.WriteLine("The second number is the biggest!");

    }
}

