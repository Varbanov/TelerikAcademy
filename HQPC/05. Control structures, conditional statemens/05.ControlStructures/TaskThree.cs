using System;

public class TaskThree
{
    public void TaskThreeMethod(int[] array, int expectedValue)
    {
        for (int i = 0; i < 100; i++)
        {
            Console.WriteLine(array[i]);
            if (i % 10 != 0)
            {
                continue;
            }

            if (array[i] == expectedValue)
            {
                Console.WriteLine("Value Found");
                break;
            }
        }
    }
}