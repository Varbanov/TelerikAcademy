using System;
using System.Collections.Generic;
using System.Linq;

class CalculateSumAverageInListMain
{
    //01. Write a program that reads from the console a sequence of positive integer numbers. 
    //The sequence ends when empty line is entered. Calculate and print the sum and average
    //of the elements of the sequence. Keep the sequence in List<int>.
  
    static void Main()
    {
        var list = new List<int>();
        int currentNumber;
        Console.WriteLine("Enter an integer or hit enter to end: ");
        bool isNumber = int.TryParse(Console.ReadLine(), out currentNumber);
        while (isNumber)
        {
            Console.WriteLine("Enter an integer or hit enter to end: ");
            list.Add(currentNumber);
            isNumber = int.TryParse(Console.ReadLine(), out currentNumber);
        }

        var sum = list.Sum();
        double average = list.Count > 0 ? list.Average() : 0;
        Console.WriteLine("List: " + string.Join(", ", list));
        Console.WriteLine("SUM: {0}", sum);
        Console.WriteLine("Average: {0}", average);
    }
}