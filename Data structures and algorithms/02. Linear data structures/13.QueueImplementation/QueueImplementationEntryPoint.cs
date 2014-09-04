namespace _13.QueueImplementation
{
    using System;

    class QueueImplementationEntryPoint
    {
        //13.Implement the ADT queue as dynamic linked list. Use generics (LinkedQueue<T>) 
        //to allow storing different data types in the queue

        static void Main()
        {
            LinkedQueue<int> myQueue = new LinkedQueue<int>();
            for (int i = 0; i < 10; i++)
            {
                myQueue.Enqueue(i);
            }

            Console.WriteLine("The queue: " + string.Join(", ", myQueue));

            var dequeuedElement = myQueue.Dequeue();
            var peekedElement = myQueue.Peek();
            Console.WriteLine("Dequeued element: " + dequeuedElement);
            Console.WriteLine("Peeked element: " + peekedElement);
            Console.WriteLine("The new queue: " + string.Join(", ", myQueue));
        }
    }
}
