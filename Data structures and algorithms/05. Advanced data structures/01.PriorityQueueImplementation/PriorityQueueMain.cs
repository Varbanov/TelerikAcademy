namespace _01.PriorityQueueImplementation
{
    using System;

    public class Pesho
    {
        public int id { get; set; }
        public Pesho(int id)
        {
            this.id = id;
        }
    }

    class PriorityQueueMain
    {
        public static void Main()
        {
            var queue = new PriorityQueue<string>();

            queue.Enqueue("Pesho");
            queue.Enqueue("Ivan");
            queue.Enqueue("Maria");
            queue.Enqueue("Stamat");
            queue.Enqueue("Bai Ivan");

            Console.WriteLine(queue.Dequeue());
            Console.WriteLine(queue.Dequeue());
            Console.WriteLine(queue.Dequeue());
            Console.WriteLine(queue.Dequeue());
            Console.WriteLine(queue.Dequeue());
        }
    }
}
