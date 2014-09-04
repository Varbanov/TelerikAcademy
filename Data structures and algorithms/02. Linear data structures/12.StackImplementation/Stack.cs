namespace _12.StackImplementation
{
    using System;
    using System.Collections.Generic;

    public class Stack<T> : IEnumerable<T>
    {
        private T[] Data { get; set; }
        private int FirstFreeIndex { get; set; }
        private int capacity;

        public Stack(int capacity)
        {
            this.Data = new T[capacity];
        }

        public Stack()
        {
            this.Data = new T[2];
        }

        public int Capacity
        {
            get { return this.Data.Length; }
            private set { this.capacity = value; }
        }

        public void Push(T item)
        {
            if (this.FirstFreeIndex < this.Capacity)
            {
                this.Data[FirstFreeIndex] = item;
                FirstFreeIndex++;
            }
            else
            {
                int newCapacity = this.Capacity * 2;
                T[] resizedData = new T[newCapacity];
                for (int i = 0; i < this.Capacity; i++)
                {
                    resizedData[i] = this.Data[i];
                }

                resizedData[FirstFreeIndex] = item;
                FirstFreeIndex++;
                this.Data = resizedData;
                this.Capacity = newCapacity;
            }
        }

        public T Pop()
        {
            this.FirstFreeIndex--;
            return this.Data[FirstFreeIndex];
        }


        public IEnumerator<T> GetEnumerator()
        {
            int currentIndex = 0;
            while (currentIndex < this.FirstFreeIndex)
            {
                yield return this.Data[currentIndex];
                currentIndex++;
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
