using System;

class RectangleAreaCalc
{
    /*Write an expression that calculates rectangle’s area by given width and height.
    */
    static void Main()
    {
        float width;
        float height;
        
        //width input
        do
        {
            Console.Write("Please enter rectangle's width: ");
        }
        while (!float.TryParse(Console.ReadLine(), out width));
        
        //height input
        do
        {
            Console.Write("Please enter rectangle's height: ");
        }
        while (!float.TryParse(Console.ReadLine(), out height));

        //calculation expression
        float area = width * height;
        
        //result output
        Console.WriteLine("The rectangle's area is {0}!", area);
    }
}

