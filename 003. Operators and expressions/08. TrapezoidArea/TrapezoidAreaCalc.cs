using System;

class TrapezoidAreaCalc
{
    /* Write an expression that calculates trapezoid's area by given sides a and b and height h.
    */
    static void Main()
    {
        //input
        float sideA;
        do
        {
            Console.Write("Please enter side a: ");
        }
        while (!float.TryParse(Console.ReadLine(), out sideA));

        float sideB;
        do
        {
            Console.Write("Please enter side b: ");
        }
        while (!float.TryParse(Console.ReadLine(), out sideB));

        float height;
        do
        {
            Console.Write("Please enter height: ");
        }
        while (!float.TryParse(Console.ReadLine(), out height));

        //solution and output
        float area = ((sideA + sideB) / 2) * height;
        Console.WriteLine("The area of the trapezoid is {0}", area);

    }
}

