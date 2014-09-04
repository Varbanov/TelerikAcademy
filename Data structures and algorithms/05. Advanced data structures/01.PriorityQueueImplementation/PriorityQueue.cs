namespace _01.PriorityQueueImplementation
{
    using System;

    public class PriorityQueue<T>
        where T : IComparable<T>
    {
        private BinaryHeap<T> heap;

        public PriorityQueue()
            : this(null)
        { 
        }

        public PriorityQueue(BinaryHeap<T> heap)
        {
            if (heap == null)
            {
                this.heap = new BinaryHeap<T>();
            }
            else
            {
                this.heap = heap;
            }
        }

        public void Enqueue(T element)
        {
            this.heap.Add(element);
        }

        public T Dequeue()
        {
            return this.heap.RemoveTop();
        }

        public T Peek()
        {
            return this.heap.Peek();
        }

        public void Clear()
        {
            this.heap.Clear();
        }
    }
}
