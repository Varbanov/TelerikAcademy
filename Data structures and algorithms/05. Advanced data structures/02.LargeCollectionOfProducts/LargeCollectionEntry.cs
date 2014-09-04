namespace _02.LargeCollectionOfProducts
{
    using System;
    using System.Diagnostics;
    using Wintellect.PowerCollections;

    public class LargeCollectionEntry
    {
        public static Product[] GetProductsInRange(decimal lowestPrice, decimal highestPrice, int count, OrderedBag<Product> data)
        {
            var cheapestProduct = new Product("", lowestPrice);
            var mostExpensiveProduct = new Product("", highestPrice);
            var matches = data.Range(cheapestProduct, true, mostExpensiveProduct, true);

            if (matches.Count <= count)
            {
                return matches.ToArray();
            }

            var result = new Product[count];
            for (int i = 0; i < count; i++)
            {
                result[i] = matches[i];
            }

            return result;
        }

        public static OrderedBag<Product> FillProducts()
        {
            var bag = new OrderedBag<Product>((x,y) => x.Price.CompareTo(y.Price));
            for (int i = 0; i < 500000; i++)
            {
                var product = new Product("Product#" + i, i);
                bag.Add(product);
            }

            return bag;
        }

        static void Main()
        {
            var products = FillProducts();
            Stopwatch sw = new Stopwatch();

            sw.Start();
            for (int i = 0; i < 10000; i++)
            {
                var matches = GetProductsInRange(i, i + 300, 20, products);
            }

            sw.Stop();
            Console.WriteLine(sw.Elapsed);
        }
    }
}
