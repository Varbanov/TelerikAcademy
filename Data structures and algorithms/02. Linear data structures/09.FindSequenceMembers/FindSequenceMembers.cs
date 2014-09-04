namespace _09.FindSequenceMembers
{
    using System;
    using System.Collections.Generic;

    class FindSequenceMembers
    {
        //09. We are given the following sequence: S1 = N; S2 = S1 + 1; S3 = 2*S1 + 1; S4 = S1 + 2; S5 = S2 + 1; S6 = 2*S2 + 1; S7 = S2 + 2; ... 
        //Using the Queue<T> class write a program to print its first 50 members for given N. Example: N=2 2, 3, 5, 4, 4, 7, 5, 6, 11, 7, 5, 9, 6, ...

        static IList<int> GetFiftyMembers(int n)
        {
            var result = new List<int>();
            result.Add(n);
            var queue = new Queue<int>();
            queue.Enqueue(n);

            while (result.Count < 50)
            {
                var first = queue.Dequeue();
                var second = first + 1;
                var third = 2 * first + 1;
                var fourth = first + 2;

                queue.Enqueue(second);
                queue.Enqueue(third);
                queue.Enqueue(fourth);

                result.Add(second);
                result.Add(third);
                result.Add(fourth);
            }

            return result;
        }

        static void Main()
        {
            var sequence50 = GetFiftyMembers(2);
            Console.WriteLine(string.Join(", ", sequence50));
        }
    }
}
