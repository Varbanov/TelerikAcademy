using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class MissCat2011
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        byte[] num = new byte[n];
        List<int> cat = new List<int>();
        for (int i = 0; i < 10; i++)
        {
            cat.Add(0);
        }

        for (int i = 0; i < n; i++)
        {
            num[i] = byte.Parse(Console.ReadLine());

            switch (num[i])
            {
                case 1: cat[0]++;
                    break;
                case 2: cat[1]++;
                    break;
                case 3: cat[2]++;
                    break;
                case 4: cat[3]++;
                    break;
                case 5: cat[4]++;
                    break;
                case 6: cat[5]++;
                    break;
                case 7: cat[6]++;
                    break;
                case 8: cat[7]++;
                    break;
                case 9: cat[8]++;
                    break;
                case 10: cat[9]++;
                    break;
            }

        }
        int best = cat.Max();
        int bestIndex = cat.IndexOf(best);
        Console.WriteLine(bestIndex + 1);



    }
}

