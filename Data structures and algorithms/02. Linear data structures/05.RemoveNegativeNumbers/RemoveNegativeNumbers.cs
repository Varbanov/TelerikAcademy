namespace _05.RemoveNegativeNumbers
{
    using System;
    using System.Collections.Generic;

    class RemoveNegativeNumbers
    {
        //Write a program that removes from given sequence all negative numbers. 

        static void Remove(List<int> input)
        {
            input.RemoveAll(x => x < 0);
        }

        static void Main()
        {
            var input = new List<int> { 1, -2, 3, -4 };
            Remove(input);
            Console.WriteLine(string.Join(", ", input));
        }
    }
}
