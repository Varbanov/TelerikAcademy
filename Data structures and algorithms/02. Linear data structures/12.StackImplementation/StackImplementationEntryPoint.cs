namespace _12.StackImplementation
{
    using System;

    class StackImplementationEntryPoint
    {
        //12.Implement the ADT stack as auto-resizable array. Resize the capacity
        //on demand (when no space is available to add / insert a new element).

        static void Main()
        {
            Stack<int> myStack = new Stack<int>();
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Old Capacity " + myStack.Capacity);
                myStack.Push(i + 10);
                Console.WriteLine("New Capacity " + myStack.Capacity);
                Console.WriteLine(string.Join(", ", myStack));
                Console.WriteLine("--------");
            }
        }
    }
}
