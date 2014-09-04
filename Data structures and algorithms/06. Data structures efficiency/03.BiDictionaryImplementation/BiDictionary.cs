namespace _03.BiDictionaryImplementation
{
    using System;
    using System.Collections.Generic;
    using Wintellect.PowerCollections;

    public class BiDictionary<K1, K2, T>
    {
        private MultiDictionary<K1, Triple> byKey1;
        private MultiDictionary<K2, Triple> byKey2;
        private MultiDictionary<Tuple<K1, K2>, Triple> byKey1Key2;

        public BiDictionary()
        {
            this.byKey1 = new MultiDictionary<K1, Triple>(true);
            this.byKey2 = new MultiDictionary<K2, Triple>(true);
            this.byKey1Key2 = new MultiDictionary<Tuple<K1, K2>, Triple>(true); 
        }

        public void Add(K1 key1, K2 key2, T value)
        {
            var triple = new Triple(key1, key2, value);

            this.byKey1.Add(key1, triple);
            this.byKey2.Add(key2, triple);

            var compositeKey = new Tuple<K1, K2>(key1, key2);
            this.byKey1Key2.Add(compositeKey, triple);
        }

        public List<T> FindByKey1(K1 key1)
        {
            var triples = this.byKey1[key1];
            var result = new List<T>();
            foreach (var triple in triples)
            {
                result.Add(triple.Value);
            }

            return result;
        }

        public List<T> FindByKey2(K2 key2)
        {
            var triples = this.byKey2[key2];
            var result = new List<T>();
            foreach (var triple in triples)
            {
                result.Add(triple.Value);
            }

            return result;
        }

        public List<T> FindByKey1AndKey2(K1 key1, K2 key2)
        {
            var compositeKey = new Tuple<K1, K2>(key1, key2);
            var triples = this.byKey1Key2[compositeKey];
            var result = new List<T>();
            foreach (var triple in triples)
            {
                result.Add(triple.Value);
            }

            return result;
        }

        private class Triple
        {
            public K1 Key1 { get; set; }
            public K2 Key2 { get; set; }
            public T Value { get; set; }

            public Triple(K1 key1, K2 key2, T value)
            {
                this.Key1 = key1;
                this.Key2 = key2;
                this.Value = value;
            }

            public bool Equals(Triple other)
            {
                if (other == null)
                {
                    return false;
                }

                return this.Key1.Equals(other.Key1) &&
                    this.Key2.Equals(other.Key2);
            }

            public override int GetHashCode()
            {
                return this.Key1.GetHashCode() ^ this.Key2.GetHashCode();
            }
        }
    }
}
