using System;

class TriangleSurface
{
    //04. Write methods that calculate the surface of a triangle by given:
    //Side and an altitude to it; Three sides; Two sides and an angle between them. Use System.Math.

    static float CalculateTriangleSurface(float side, float altitude)
    {
        float surface = (side * altitude) / 2;
        return surface;
    }

    static float CalculateTriangleSurface(float sideA, float sideB, float sideC)
    {
        float p = (sideA + sideB + sideC)/2;
        float surface = (float) Math.Sqrt(p * (p - sideA) * (p - sideB) * (p - sideC));
        return surface;
    }

    static float CalculateTriangleSurface(float sideA, float sideB, int angleInDegrees)
    {
        //The angle, a, must be in radians. Multiply by Math.PI/180 to convert degrees to radians.
        float angleInRad = (float) (angleInDegrees * Math.PI) / 180;
        float surface = (float) Math.Sin(angleInRad) * sideA * sideB;
        return surface;
    }

    static void Main()
    {
        //user choice
        int choice;
        do
        {
            Console.WriteLine("Please type 1, 2 or 3 to choose input: \n1.side and altitude\n2.tree sides\n3.two sides and an angle between them");
        } while (!int.TryParse(Console.ReadLine(), out choice) || (choice != 1 && choice != 2 && choice != 3));

        //input
        if (choice == 1)
        {
            float side, alt;
            do
            {
                Console.Write("Please enter a side: ");
            } while (!float.TryParse(Console.ReadLine(), out side) || side <= 0);

            do
            {
                Console.Write("Please enter an altitude: ");
            } while (!float.TryParse(Console.ReadLine(), out alt) || alt <= 0);

            Console.WriteLine("Surface: " + CalculateTriangleSurface(side, alt));
        }
        else if (choice == 2)
        {
            float a, b, c;
            do
            {
                Console.Write("Please enter side A: ");
            } while (!float.TryParse(Console.ReadLine(), out a) || a <= 0);

            do
            {
                Console.Write("Please enter side B: ");
            } while (!float.TryParse(Console.ReadLine(), out b) || b <= 0);

            do
            {
                Console.Write("Please enter side C: ");
            } while (!float.TryParse(Console.ReadLine(), out c) || c <= 0);

            Console.WriteLine("Surface: " + CalculateTriangleSurface(a, b, c));
        }
        else
        {
            float a, b;
            int angle;

            do
            {
                Console.Write("Please enter side A: ");
            } while (!float.TryParse(Console.ReadLine(), out a) || a <= 0);

            do
            {
                Console.Write("Please enter side B: ");
            } while (!float.TryParse(Console.ReadLine(), out b) || b <= 0);

            do
            {
                Console.Write("Please enter angle: ");
            } while (!int.TryParse(Console.ReadLine(), out angle) || angle <= 0 || angle >= 180);
            
            Console.WriteLine(CalculateTriangleSurface(a,b,angle));
        }


    }
}
