using System;

class ThreeIntsSum
{
    //Write a program that reads 3 integer numbers from the console and prints their sum.

    static void Main()
    {
        int firstNum;
        int secondNum;
        int thirdNum;

        //first int input
        do
        {
            Console.Write("Please enter first integer: ");
        } 
        while (!int.TryParse(Console.ReadLine(), out firstNum));

        //second int input
        do
        {
            Console.Write("Please enter second integer: ");
        }
        while (!int.TryParse(Console.ReadLine(), out secondNum));

        //third int input
        do
        {
            Console.Write("Please enter third integer: ");
        }
        while (!int.TryParse(Console.ReadLine(), out thirdNum));

        //sum and output
        long sum = firstNum + secondNum + thirdNum;
        Console.WriteLine("The sum of the three numbers is {0}!", sum);
    }
}

