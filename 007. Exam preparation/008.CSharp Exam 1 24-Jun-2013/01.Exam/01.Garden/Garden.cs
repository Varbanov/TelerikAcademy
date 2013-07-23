using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

class Garden
{
    static void Main()
    {
        System.Threading.Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;



        int tomatoSeeds, tomatoArea, cucumberSeeds, cucumberArea, potatoSeeds, potatoArea, carrotSeeds, carrotArea, cabbageSeeds, cabbageArea, beansSeeds;

        tomatoSeeds = int.Parse(Console.ReadLine());
        tomatoArea = int.Parse(Console.ReadLine());
        
        cucumberSeeds = int.Parse(Console.ReadLine());
        cucumberArea = int.Parse(Console.ReadLine());
        
        potatoSeeds = int.Parse(Console.ReadLine());
        potatoArea = int.Parse(Console.ReadLine());

        carrotSeeds = int.Parse(Console.ReadLine());
        carrotArea = int.Parse(Console.ReadLine());

        cabbageSeeds = int.Parse(Console.ReadLine());
        cabbageArea = int.Parse(Console.ReadLine());

        beansSeeds = int.Parse(Console.ReadLine());

        int beansArea = 250 - (tomatoArea + cucumberArea + potatoArea + carrotArea + cabbageArea);

        double totalCost = tomatoSeeds * 0.5 + cucumberSeeds * 0.4 + potatoSeeds * 0.25 + carrotSeeds * 0.6 + cabbageSeeds * 0.3 + beansSeeds * 0.4;


        Console.WriteLine("Total costs: {0:0.00}", totalCost);

        if (beansArea > 0)
        {
            Console.WriteLine("Beans area: {0}", beansArea);
        }
        else if (beansArea == 0)
        {
            Console.WriteLine("No area for beans");
        }
        else
        {
            Console.Write("Insufficient area");
        }


    }
}

