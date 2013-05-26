using System;

class PointInCircleOutRectangle
{
    /*Write an expression that checks for given point (x, y) if it is within the circle K( (1,1), 3) and out of the rectangle
     * R(top=1, left=-1, width=6, height=2).
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
        bool withinCircle = ((xCoord - 1) * (xCoord - 1)) + ((yCoord - 1) * (yCoord - 1)) < 9;
        bool outOfRectangle = (xCoord < -1 || xCoord > 5) || (yCoord < -1 || yCoord > 1);

        //output
        if (withinCircle && outOfRectangle)
        {
            Console.WriteLine("The point is within the circle and out of the rectangle!");
        }
        else
        {
            if (withinCircle)
            {
                Console.WriteLine("The point is within the circle, BUT is NOT out of the rectangle!");
            }
            else if (outOfRectangle)
            {
                Console.WriteLine("The point is out of the rectangle, BUT is NOT within the circle!");
            }
            else 
            {
                Console.WriteLine("The point is NEITHER within the circle, NOR out of the rectangle!");
            }
        }
    }
}

