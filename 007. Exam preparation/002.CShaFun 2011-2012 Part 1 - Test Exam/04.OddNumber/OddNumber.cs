using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class OddNumber
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        Dictionary<long, int> nums = new Dictionary<long, int>();

        for (int i = 0; i < n; i++)
        {
            long temp = long.Parse(Console.ReadLine());

            if (nums.ContainsKey(temp))
            {
                nums.Remove(temp);
            }
            else
            {
                nums.Add(temp, 1);
            }
        }

        foreach (var num in nums)
        {
            Console.WriteLine(num.Key);
        }

    }
}

