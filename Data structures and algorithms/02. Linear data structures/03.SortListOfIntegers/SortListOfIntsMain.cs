namespace _03.SortListOfIntegers
{
    using System;
    using System.Collections.Generic;

    class SortListOfIntsMain
    {
        //03. Write a program that reads a sequence of integers (List<int>) ending with an empty line and sorts them in an increasing order.

        static void Main()
        {
            int currentNumber;
            var list = new List<int>();
            var line = string.Empty;

            do
            {
                Console.WriteLine("Please enter an integer or hit enter to end: ");
                line = Console.ReadLine();
                if (int.TryParse(line, out currentNumber))
                {
                    list.Add(currentNumber);
                }
            } while (!string.IsNullOrEmpty(line));

            list.Sort();
            if (list.Count > 0)
            {
                Console.WriteLine(string.Join(", ", list));
            }
            else
            {
                Console.WriteLine("The list is empty!");
            }
        }
    }
}
