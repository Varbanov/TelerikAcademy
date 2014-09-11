namespace SubarraysSums
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.IO;

    public class SubarraySumsMain
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                var parameters = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                int k = int.Parse(parameters[1].Trim());
                var stringInput = Console.ReadLine().Split(new char[] { ' ' });
                int[] input = new int[stringInput.Length];
                for (int j = 0; j < input.Length; j++)
                {
                    input[j] = int.Parse(stringInput[j]);
                }
                SubarraysCombinator combinator = new SubarraysCombinator(input.Length - k, input);
                combinator.Generate();
                Console.WriteLine(combinator.SumOfAllSubarrays);
            }
        }
    }
}
