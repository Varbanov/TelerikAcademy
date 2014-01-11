using System;
using System.Globalization;

  class CircleAreaPerimeterCalc
  {
      //Write a program that reads the radius r of a circle and prints its perimeter and area.

      static void Main()
      {
          //to avoid misspelling of the decimal separator
          System.Threading.Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

          //radius input
          float radius;
          do
          {
              Console.WriteLine("Please enter the circle's radius: ");
          } 
          while (!float.TryParse(Console.ReadLine(), out radius));

          //solution and output
          float area = (float) Math.PI * radius * radius;
          float circumference = (float) Math.PI * 2 * radius;

          Console.WriteLine("Circumference: {0} \nCircle area: {1}", circumference, area);
      }
  }

