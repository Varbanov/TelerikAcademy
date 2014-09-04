namespace _11.LinkedListImplementation
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class LinkedList<T> : IEnumerable<T>
    {
        ListItem<T> First { get;  set; }
        ListItem<T> Last { get; set; }
        public int Count { get; private set; }
        public void AddLast(T value)
        {
            var newItem = new ListItem<T>(value, null);
            if (this.First == null && this.Last == null)
            {
                this.First = newItem;
                this.Last = newItem;
            }
            else 
            {
                this.Last.Next = newItem;
                this.Last = newItem;
            }

            this.Count++;
        }

        public void AddFirst(T value)
        {
            var newItem = new ListItem<T>(value, null);
            if (this.First == null && this.Last == null)
            {
                this.First = newItem;
                this.Last = newItem;
            }
            else
            {
                newItem.Next = this.First;
                this.First = newItem;
            }

            this.Count++;
        }

        public void Clear()
        {
            this.First = null;
            this.Last = null;
        }


        public IEnumerator<T> GetEnumerator()
        {
            var currentNode = this.First;
            while (currentNode != null)
            {
                yield return currentNode.Value;
                currentNode = currentNode.Next;
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
