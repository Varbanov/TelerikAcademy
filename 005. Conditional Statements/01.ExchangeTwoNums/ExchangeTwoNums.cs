using System;

class ExchangeTwoNums
{
    //Write an if statement that examines two integer variables and exchanges their values 
    //if the first one is greater than the second one.

    static void Main()
    {
        //input
        int first, second;
        do
        {
            Console.Write("Please enter first integer:");
        } while (!int.TryParse(Console.ReadLine(), out first));

        do
        {
            Console.Write("Please enter second integer:");
        } while (!int.TryParse(Console.ReadLine(), out second));

        //solution and output
        if (first > second)
        {
            int temp = first;
            first = second;
            second = temp;
        }

        Console.WriteLine("First: {0}\nSecond: {1}", first, second);
    }
}
