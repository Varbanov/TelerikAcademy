using System;

class NumsBtwnNums
{
    //Write a program that reads two positive integer numbers and prints how many numbers p exist
    //between them such that the remainder of the division by 5 is 0 (inclusive). Example: p(17,25) = 2.

    static void Main()
    {
        //input
        uint firstNum, secondNum;
        do
        {
            Console.Write("Please enter the smaller integer:");
        } 
        while (!uint.TryParse(Console.ReadLine(), out firstNum));

        do
        {
            Console.Write("Please enter the bigger integer:");
        }
        while (!uint.TryParse(Console.ReadLine(), out secondNum) || secondNum < firstNum);

        //solution avoiding unnecessary iterations
        uint counter = 0;
        uint temp = firstNum;
        while (temp % 5 != 0 && temp < secondNum)
        {
            temp++;
        }

        if (temp % 5 == 0)
        {
            counter++;
            while (temp + 5 <= secondNum)
            {
                temp += 5;
                counter++;
            }
        }
        
        //output
        Console.WriteLine("The numbers between {0} and {1} divisible by 5 are {2}!", firstNum, secondNum, counter);

    }
}

