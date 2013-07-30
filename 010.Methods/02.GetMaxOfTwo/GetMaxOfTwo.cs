using System;

class GetMaxOfTwo
{
    //Write a method GetMax() with two parameters that returns the bigger of two integers.
    //Write a program that reads 3 integers from the console and prints the biggest of them using the method GetMax().
    static int GetMax(int num1, int num2)
    {
        if (num1 >= num2)
        {
            return num1;
        }
        else
        {
            return num2;
        }
    }

    static void Main()
    {
        //input
        int num1, num2, num3;
        do
        {
            Console.Write("Please enter number 1: ");
        } while (!int.TryParse(Console.ReadLine(), out num1));
        
        do
        {
            Console.Write("Please enter number 2: ");
        } while (!int.TryParse(Console.ReadLine(), out num2));
        
        do
        {
            Console.Write("Please enter number 3: ");
        } while (!int.TryParse(Console.ReadLine(), out num3));

        //solution
        int result = GetMax(GetMax(num1, num2), num3);
        Console.WriteLine("The biggest num is {0}", result);
    }
}
