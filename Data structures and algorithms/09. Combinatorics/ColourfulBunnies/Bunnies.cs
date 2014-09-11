namespace ColourfulBunnies
{
    using System;
    using System.Collections.Generic;

    public class Bunnies
    {
        public static void Main()
        {
            int numberOfBunnies = int.Parse(Console.ReadLine());
            var bunniesAndAnswers = new Dictionary<int, int>();

            for (int i = 0; i < numberOfBunnies; i++)
            {
                int currentAnswer = int.Parse(Console.ReadLine());
                if (bunniesAndAnswers.ContainsKey(currentAnswer))
                {
                    bunniesAndAnswers[currentAnswer]++;
                }
                else
                {
                    bunniesAndAnswers[currentAnswer] = 1;
                }
            }

            var minBunniesCounter = 0;
            foreach (var pair in bunniesAndAnswers)
            {
                if (pair.Value <= 1)
                {
                    minBunniesCounter += pair.Key + 1;
                }
                else
                {
                    var groups = pair.Value / (pair.Key + 1);
                    var remainder = pair.Value % (pair.Key + 1);
                    minBunniesCounter += groups * (pair.Key + 1);
                    minBunniesCounter += remainder == 0 ? 0 : (pair.Key + 1);
                }
            }

            Console.WriteLine(minBunniesCounter);
        }
    }
}
