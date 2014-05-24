using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Statistics
{
    public void PrintStatistics(double[] array, int elementsCounter)
    {
        double max = double.MinValue;
        for (int i = 0; i < elementsCounter; i++)
        {
            if (array[i] > max)
            {
                max = array[i];
            }
        }

        this.PrintMax(max);

        double min = 0;
        for (int i = 0; i < elementsCounter; i++)
        {
            if (array[i] < min)
            {
                min = array[i];
            }
        }

        this.PrintMin(min);

        double sum = 0;
        for (int i = 0; i < elementsCounter; i++)
        {
            sum += array[i];
        }

        var average = sum / elementsCounter;
        this.PrintAverage(average);
    }

    private void PrintMin(double min)
    {
        Console.WriteLine("Min: " + min);
    }

    private void PrintAverage(double average)
    {
        Console.WriteLine("Average: " + average);
    }

    private void PrintMax(double max)
    {
        Console.WriteLine("Max: " + max);
    }
}