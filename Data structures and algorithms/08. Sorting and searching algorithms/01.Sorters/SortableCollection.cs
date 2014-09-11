namespace SortingHomework
{
    using System;
    using System.Collections.Generic;

    public class SortableCollection<T> where T : IComparable<T>
    {
        private readonly IList<T> items;

        public SortableCollection()
        {
            this.items = new List<T>();
        }

        public SortableCollection(IEnumerable<T> items)
        {
            this.items = new List<T>(items);
        }

        public IList<T> Items
        {
            get
            {
                return this.items;
            }
        }

        public void Sort(ISorter<T> sorter)
        {
            sorter.Sort(this.items);
        }

        public bool LinearSearch(T item)
        {
            foreach (var element in this.Items)
            {
                if (element.CompareTo(item) == 0)
                {
                    return true;
                }
            }

            return false;
        }

        public bool BinarySearch(T item)
        {
            this.Sort(new Quicksorter<T>());

            int start = 0;
            int end = this.items.Count - 1;
            int resultIndex = -1;
            while (start <= end)
            {
                int middle = (start + end) / 2;
                if (item.CompareTo(this.items[middle]) < 0)
                {
                    end = middle - 1;
                }
                else if (item.CompareTo(this.items[middle]) > 0)
                {
                    start = middle + 1;
                }
                else
                {
                    resultIndex = middle;
                    break;
                }
            }

            return resultIndex != -1;
        }

        public void Shuffle()
        {
            Random random = new Random();

            for (int i = this.items.Count - 1; i > 0; i--)
            {
                int randomIndex = random.Next(0, i);

                T swapValue = this.items[i];
                this.items[i] = this.items[randomIndex];
                this.items[randomIndex] = swapValue;
            }
        }

        public void PrintAllItemsOnConsole()
        {
            for (int i = 0; i < this.items.Count; i++)
            {
                if (i == 0)
                {
                    Console.Write(this.items[i]);
                }
                else
                {
                    Console.Write(" " + this.items[i]);
                }
            }

            Console.WriteLine();
        }
    }
}
