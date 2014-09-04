namespace _13.QueueImplementation
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class LinkedQueue<T> : IEnumerable<T>
    {
        private LinkedList<T> Data { get; set; }

        public LinkedQueue()
        {
            this.Data = new LinkedList<T>();
        }

        public void Enqueue(T item)
        {
            this.Data.AddLast(item);
        }

        public T Dequeue()
        {
            T result = this.Data.First.Value;
            this.Data.RemoveFirst();
            return result;
        }

        public T Peek()
        {
            return this.Data.First.Value;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var node = this.Data.First;
            while (node != null)
            {
                yield return node.Value;
                node = node.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
