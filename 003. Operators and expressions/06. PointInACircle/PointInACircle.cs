using System;

class PointInACircle
{
    /*Write an expression that checks if given point (x,  y) is within a circle K(O, 5).
    */
    static void Main()
    {
        //x input
        float xCoord;
        do
        {
            Console.Write("Please enter x coordinate: ");
        }
        while (!float.TryParse(Console.ReadLine(), out xCoord));

        //y input
        float yCoord;
        do
        {
            Console.Write("Please enter y coordinate: ");
        }
        while (!float.TryParse(Console.ReadLine(), out yCoord));

        //solution
        if ((xCoord * xCoord + yCoord * yCoord) < 25)
        {
            Console.WriteLine("The point ({0}, {1}) is within the circle (0, 5)!", xCoord, yCoord);
        }
        else if (((xCoord * xCoord + yCoord * yCoord) == 25))
        {
            Console.WriteLine("The point ({0}, {1}) lies on the circle (0, 5)!", xCoord, yCoord);
        }
        else
        {
            Console.WriteLine("The point ({0}, {1}) is outside the circle (0, 5)!", xCoord, yCoord);
        }
    }
}

