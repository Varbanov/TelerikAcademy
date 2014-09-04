using System;

using _04.HashTableImplementation;
using System.Collections.Generic;

namespace _05.SetImplementation
{
    public class Set<T> : IEnumerable<T>
    {
        private HashTable<int, T> table;

        public Set()
        {
            this.table = new HashTable<int, T>();
        }

        public Set(HashTable<int, T> table)
        {
            this.table = table;
        }


        public Set<T> Union(Set<T> secondSet)
        { 
            var result = new Set<T>();
            foreach (var item in secondSet)
            {
                result.Add(item);
            }

            foreach (var item in this)
            {
                result.Add(item);
            }

            return result;
        }

        public Set<T> Intersect(Set<T> secondSet)
        {
            var result = new Set<T>();
            foreach (var element in this)
            {
                foreach (var secondElement in secondSet)
                {
                    if (element.Equals(secondElement))
                    {
                        result.Add(element);
                    }
                }
            }

            return result;
        }

        public void Add(T value)
        {
            var hash = value.GetHashCode();
            this.table.Add(hash, value);
        }

        public T Find(T value)
        {
            return this.table[value.GetHashCode()];
        }

        public bool Remove(T value)
        {
            return this.table.Remove(value.GetHashCode());
        }

        public int Count
        {
            get 
            {
                return this.table.Count;
            }
        }

        public void Clear()
        {
            this.table.Clear();
        }

        public bool Contains(T value)
        {
            return this.table.Contains(value.GetHashCode());
        }


        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in this.table)
            {
                yield return item.Value;
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
