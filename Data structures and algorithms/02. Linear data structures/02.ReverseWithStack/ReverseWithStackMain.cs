namespace _02.ReverseWithStack
{
    using System;
    using System.Collections.Generic;

    class ReverseWithStackMain
    {
        //Write a program that reads N integers from the console and reverses them using a stack. Use the Stack<int>class.

        static void Main()
        {
            int n;
            do
            {
                Console.WriteLine("Please enter integer \"N\": ");
            } while (!int.TryParse(Console.ReadLine(), out n));

            int currentNumber;
            var stack = new Stack<int>();
            for (int i = 0; i < n; i++)
            {
                do
                {
                    Console.WriteLine("Please enter integer \"{0}\": ", i + 1);
                } while (!int.TryParse(Console.ReadLine(), out currentNumber));

                stack.Push(currentNumber);
            }

            while (stack.Count > 0)
            {
                int poppedNumber = stack.Pop();
                Console.Write("{0}, ", poppedNumber);
            }
        }
    }
}
