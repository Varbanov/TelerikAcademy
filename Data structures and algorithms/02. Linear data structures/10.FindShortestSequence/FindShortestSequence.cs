namespace _10.FindShortestSequence
{
    using System;
    using System.Collections.Generic;

    class FindShortestSequence
    {

        static List<int> FindPath(int n, int m)
        {
            var sequence = new Queue<KeyValuePair<int, List<int>>>();
            var nAsKeyValuePair = new KeyValuePair<int, List<int>>(5, new List<int>());
            sequence.Enqueue(nAsKeyValuePair);
            KeyValuePair<int, List<int>> root;
            List<int> rootValue;

            while (true)
            {
                root = sequence.Dequeue();
                rootValue = root.Value;

                var firstOperation = new KeyValuePair<int, List<int>>(root.Key + 1, new List<int>());
                firstOperation.Value.AddRange(rootValue);
                firstOperation.Value.Add(root.Key);
                sequence.Enqueue(firstOperation);

                var secondOperation = new KeyValuePair<int, List<int>>(root.Key + 2, new List<int>());
                secondOperation.Value.AddRange(rootValue);
                secondOperation.Value.Add(root.Key);
                sequence.Enqueue(secondOperation);

                var thirdOperation = new KeyValuePair<int, List<int>>(root.Key * 2, new List<int>());
                thirdOperation.Value.AddRange(rootValue);
                thirdOperation.Value.Add(root.Key);
                sequence.Enqueue(thirdOperation);

                if (firstOperation.Key == m)
                {
                    firstOperation.Value.Add(firstOperation.Key);
                    return firstOperation.Value;
                }
                else if (secondOperation.Key == m)
                {
                    secondOperation.Value.Add(secondOperation.Key);
                    return secondOperation.Value;
                }
                else if (thirdOperation.Key == m)
                {
                    thirdOperation.Value.Add(thirdOperation.Key);
                    return thirdOperation.Value;
                }
            }
        }

        static void Main()
        {
            int n = 5;
            int m = 16;
            var path = FindPath(n, m);
            Console.WriteLine(string.Join(", ", path));
        }
    }
}
