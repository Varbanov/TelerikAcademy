using System;

class CompareTwoNumbers
{
    //Write a program that gets two numbers from the console and prints the greater of them. Don’t use if statements.
    static void Main()
    {
        //input
        float firstNum, secondNum;
        do
        {
            Console.Write("Please enter first number:");
        }
        while (!float.TryParse(Console.ReadLine(), out firstNum));

        do
        {
            Console.Write("Please enter second number:");
        }
        while (!float.TryParse(Console.ReadLine(), out secondNum));

        //solution and output
        float greaterNum = firstNum >= secondNum ? firstNum : secondNum;
        Console.WriteLine("The greater number is {0}!", greaterNum);

        /*another solution using Math.Max()
         * float greater = Math.Max(firstNum, secondNum);
         * Console.WriteLine(greater);
        */
    }
}

