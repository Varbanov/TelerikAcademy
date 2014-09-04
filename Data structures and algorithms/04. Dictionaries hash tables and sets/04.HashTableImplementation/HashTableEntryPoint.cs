using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace _04.HashTableImplementation
{
    class HashTableEntryPoint
    {
        static void PrintHashTableInfo<K, V>(HashTable<K, V> table)
        {
            foreach (var item in table)
            {
                Console.WriteLine(item.Key + " " + item.Value);
            }

            Console.WriteLine("Capacity: " + table.Capacity);
            Console.WriteLine("Count: " + table.Count);
            Console.WriteLine("Keys: " + string.Join(", ", table.Keys));
        }

        static void Main()
        {
            var table = new HashTable<int, string>();
            PrintHashTableInfo(table);

            table.Add(50, "Maria");
            for (int i = 0; i < 12; i++)
            {
                table.Add(i, "Elena");
            }

            PrintHashTableInfo(table);

            table.Remove(50);
            PrintHashTableInfo(table);

            table.Clear();
            PrintHashTableInfo(table);

            //PERFORMANCE TEST
            //var table = new HashTable<string, string>();
            //var list = new List<string>();

            //for (int i = 0; i < 100000; i++)
            //{
            //    table.Add(string.Format("key{0}", i), string.Format("item{0}", i));
            //    list.Add(string.Format("key{0}", i));
            //}

            //var sw = new Stopwatch();
            //sw.Start();
            //for (int i = 0; i < 1000; i++)
            //{
            //    table.Contains("pesho");
            //}
            //sw.Stop();
            //Console.WriteLine("my hash: " + sw.Elapsed);
            //sw.Reset();

            //sw.Start();
            //for (int i = 0; i < 1000; i++)
            //{
            //    list.Contains("pesho");
            //}
            //sw.Stop();
            //Console.WriteLine("my list: " + sw.Elapsed);
            //sw.Reset();
        }
    }
}
