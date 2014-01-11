using System;

class SortThreeNums
{
    //Sort 3 real values in descending order using nested if statements.

    static void Main()
    {
        //input
        float first, second, third;
        do
        {
            Console.Write("Please enter first integer:");
        } while (!float.TryParse(Console.ReadLine(), out first));

        do
        {
            Console.Write("Please enter second integer:");
        } while (!float.TryParse(Console.ReadLine(), out second));

        do
        {
            Console.Write("Please enter third integer:");
        } while (!float.TryParse(Console.ReadLine(), out third));

        //solution and output
        float greater, middle, smaller;

        if (first >= second)
        {
            if (first > third)
            {
                greater = first;
                if (second > third)
                {
                    middle = second;
                    smaller = third;
                }
                else
                {
                    middle = third;
                    smaller = second;
                }
            }
            else
            {
                greater = third;
                middle = first;
                smaller = second;
            }
        }
        else if (third <= second)
        {
            greater = second;
            if (first < third)
            {
                middle = third;
                smaller = first;
            }
            else
            {
                middle = first;
                smaller = third;
            }
        }
        else
        {
            greater = third;
            middle = second;
            smaller = first;
        }

        Console.WriteLine("{0} {1} {2}", greater, middle, smaller);
    }
}

