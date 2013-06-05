using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class MissCat
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int[] cats = new int[10];

        for (int i = 0; i < n; i++)
        {
            int catNum = int.Parse(Console.ReadLine());

            switch (catNum)
            {
                case 1: cats[0]++;
                    break;
                case 2: cats[1]++;
                    break;
                case 3: cats[2]++;
                    break;
                case 4: cats[3]++;
                    break;
                case 5: cats[4]++;
                    break;
                case 6: cats[5]++;
                    break;
                case 7: cats[6]++;
                    break;
                case 8: cats[7]++;
                    break;
                case 9: cats[8]++;
                    break;
                case 10: cats[9]++;
                    break;
            }
        }

        int maxCat = 0;
        int maxIndex = 0;

        for (int i = cats.Length - 1; i >= 0; i--)
        {
            if (cats[i] >= maxCat)
            {
                maxCat = cats[i];
                maxIndex = i;
            }
        }

        Console.WriteLine(maxIndex + 1);

    }
}

