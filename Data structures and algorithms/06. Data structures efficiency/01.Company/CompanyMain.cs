namespace _01.Company
{
    using System;
    using System.Collections.Generic;
    using Wintellect.PowerCollections;

    public class CompanyMain
    {
        static List<Article> GetArticlesInPriceRange(decimal minPrice, decimal maxPrice, OrderedMultiDictionary<decimal, Article> data)
        {
            var matches = data.Range(minPrice, true, maxPrice, true);
            var result = new List<Article>();

            foreach (var price in matches)
            {
                foreach (var article in price.Value)
                {
                    result.Add(article);
                }
            }

            return result;
        }

        static void Main()
        {
            OrderedMultiDictionary<decimal, Article> articles = new OrderedMultiDictionary<decimal, Article>(true);

            for (int i = 0; i < 10000; i++)
            {
                decimal price = i;
                var article = new Article("barcode" + i, "vendor" + i, "title" + i, price);
                articles[price].Add(article);
            }

            var articlesInRange = GetArticlesInPriceRange(200, 300, articles);

            foreach (var a in articlesInRange)
            {
                Console.WriteLine(a);
            }

        }
    }
}
