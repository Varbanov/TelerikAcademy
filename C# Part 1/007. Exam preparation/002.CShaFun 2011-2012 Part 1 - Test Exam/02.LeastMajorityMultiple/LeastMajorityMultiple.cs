using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class LeastMajorityMultiple
{
    static void Main()
    {
        int[] nums = new int[5];

        for (int i = 0; i < 5; i++)
        {
            nums[i] = int.Parse(Console.ReadLine());
        }

        int result = 0;
        int counter = 1;
        while (true)
        {
            int numCounter = 0;

            for (int i = 0; i < 5; i++)
            {
                if (counter % nums[i] == 0)
                {
                    numCounter++;
                }
            }

            if (numCounter >= 3)
            {
                break;
            }
            counter++;
        }

        Console.WriteLine(counter);



    }
}

