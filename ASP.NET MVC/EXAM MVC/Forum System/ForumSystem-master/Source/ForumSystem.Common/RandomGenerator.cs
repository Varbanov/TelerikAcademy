namespace ForumSystem.Common
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class RandomGenerator
    {
        public const string AllLeters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private Random random = new Random();

        public int GetRandomInt(int min, int max)
        {
            return this.random.Next(min, max + 1);
        }

        public string GetRandomStringExact(int length, string charsToUse = AllLeters)
        {
            var result = new char[length];
            for (int i = 0; i < length; i++)
            {
                result[i] = charsToUse[this.random.Next(0, charsToUse.Length)];
            }

            return new string(result);
        }

        public string GetRandomString(int min, int max, string charsToUse = AllLeters)
        {
            return this.GetRandomStringExact(this.random.Next(min, max + 1), charsToUse);
        }

        public string GetRandomNumericString(int length)
        {
            StringBuilder sb = new StringBuilder(length);

            for (int i = 0; i < length; i++)
            {
                sb.Append(this.random.Next(1, 10));
            }

            return sb.ToString();
        }
    }
}
