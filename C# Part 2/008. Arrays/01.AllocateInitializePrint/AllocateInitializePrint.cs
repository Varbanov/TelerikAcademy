using System;

class AllocateInitializePrint
{
    //Write a program that allocates array of 20 integers and initializes each element by its
    //index multiplied by 5. Print the obtained array on the console.

    static void Main()
    {
        int[] array = new int[20];
        for (int i = 0; i < 20; i++)
        {
            array[i] = 5 * i;
            Console.Write("{0,3}", array[i]);
        }
    }
}

