namespace _11.LinkedListImplementation
{
    using System;
    using System.Linq;

    public class ListItem<T>
    {
        public T Value { get; set; }
        public ListItem<T> Next { get; set; }

        public ListItem(T value, ListItem<T> next)
        {
            this.Value = value;
            this.Next = next;
        }

        public override string ToString()
        {
           var p = base.ToString() + "pesho";
           return p;
        }
    }
}
