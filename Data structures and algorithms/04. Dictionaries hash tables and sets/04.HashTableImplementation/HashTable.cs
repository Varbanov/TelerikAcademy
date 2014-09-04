namespace _04.HashTableImplementation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class HashTable<K, V> : IEnumerable<KeyValuePair<K, V>>
    {
        private const int initialSize = 16;
        public int count;
        private LinkedList<KeyValuePair<K, V>>[] Values { get; set; }

        public HashTable()
        {
            this.Values = new LinkedList<KeyValuePair<K, V>>[initialSize];
        }

        public int Count
        {
            get
            {
                return this.count;
            }

            private set
            {
                this.count = value;
            }
        }

        public int Capacity
        {
            get
            {
                return this.Values.Length;
            }
        }

        public K[] Keys
        {
            get
            {
                var keys = new K[this.Count];
                var counter = 0;
                foreach (var pair in this)
                {
                    keys[counter] = pair.Key;
                    counter++;
                }

                return keys;
            }
        }

        //indexer
        public V this[K key]
        {
            get
            {
                return this.Find(key);
            }

            set
            {
                this.Remove(key);
                this.Add(key, value);
            }
        }

        public bool Contains(K key)
        { 
            var hash = this.Hash(key);
            var list = this.Values[hash];
            if (list == null)
            {
                return false;
            }

            return list.Any(x => x.Key.Equals(key));
        }

        private V Find(K key)
        {
            var hash = this.Hash(key);
            var list = this.Values[hash];
            if (list == null)
            {
                throw new ArgumentException("The key does not exist in the table");
            }

            try
            {
                var pair = list.First(x => x.Key.Equals(key));
                return pair.Value;
            }
            catch (InvalidOperationException ex)
            {
                throw new ArgumentException("The key does not exist in the table", ex);
            }
        }

        public void Add(K key, V value)
        {
            var hash = this.Hash(key);
            var newPair = new KeyValuePair<K, V>(key, value);
            if (this.Values[hash] == null)
            {
                this.Values[hash] = new LinkedList<KeyValuePair<K, V>>();
            }

            var keyExists = this.Values[hash].Any(x => x.Key.Equals(key));
            if (keyExists)
            {
                throw new ArgumentException("The hash table already has key " + key);
            }

            this.Values[hash].AddLast(newPair);
            this.Count++;

            double maxLoad = 0.75;
            bool loadExceeded = ((double) this.Count / this.Capacity) >= maxLoad;
            if (loadExceeded)
            {
                this.ResizeAndReadd();
            }
        }

        public bool Remove(K key)
        {
            var hash = this.Hash(key);
            var list = this.Values[hash];
            if (list == null)
            {
                return false;
            }

            try
            {
                list.Remove(list.First(x => x.Key.Equals(key)));
                this.Count--;
                return true;
            }
            catch (System.InvalidOperationException)
            {
                return false;
            }
        }

        public void Clear()
        {
            this.Values = new LinkedList<KeyValuePair<K, V>>[initialSize];
            this.Count = 0;
        }

        private void ResizeAndReadd()
        {
            var oldValues = this.Values;
            this.Values = new LinkedList<KeyValuePair<K, V>>[this.Capacity * 2];
            this.Count = 0;

            //iterate over linked lists
            foreach (var list in oldValues)
            {
                if (list != null)
                {
                    //iterate over key-value pairs
                    foreach (var pair in list)
                    {
                        this.Add(pair.Key, pair.Value);
                    }
                }
            }
        }

        private int Hash(K key)
        {
            var hash = key.GetHashCode();
            hash = hash % this.Capacity;
            hash = Math.Abs(hash);
            return hash;
        }

        public IEnumerator<KeyValuePair<K, V>> GetEnumerator()
        {
            foreach (var list in this.Values)
            {
                if (list != null)
                {
                    foreach (var pair in list)
                    {
                        yield return pair;
                    }
                }
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
