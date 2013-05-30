using System;

class QuadraticEquationSolver
{
    //Write a program that reads the coefficients a, b and c of a quadratic equation ax2+bx+c=0 and solves it (prints its real roots)
    static void Main()
    {
        //data input
        double a, b, c;
        do
        {
            Console.WriteLine("Enter coefficient \"a\" of ax^2 + bx + c:");
        }
        while (!double.TryParse(Console.ReadLine(), out a));

        do
        {  
            Console.WriteLine("Enter coefficient \"b\" of ax^2 + bx + c:");
        }
        while (!double.TryParse(Console.ReadLine(), out b));

        do
        {
            Console.WriteLine("Enter coefficien \"c\" of ax^2 + bx + c:");
        }
        while (!double.TryParse(Console.ReadLine(), out c));

        //solution and output
        double rootOne;
        double rootTwo;
        double d = b * b - (4 * a * c);
        if (d > 0)
        {
            rootOne = (-b + Math.Sqrt(d) / (2 * a));
            rootTwo = (-b - Math.Sqrt(d) / (2 * a));
            Console.WriteLine("The real roots of the equation are: \n{0} \n{1}", rootOne, rootTwo);
        }

        else if (d == 0)
        {
            rootOne = (-b + Math.Sqrt(d) / (2 * a));
            rootTwo = rootOne;
            Console.WriteLine("The equation has one double real root: \n{0}", rootOne);
        }

        else
        {
            Console.WriteLine("No real roots!");
        }
    }
}

