using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class ShipDamage
{
    static void Main()
    {
        int sx1 = int.Parse(Console.ReadLine());
        int sy1 = int.Parse(Console.ReadLine());
        int sx2 = int.Parse(Console.ReadLine());
        int sy2 = int.Parse(Console.ReadLine());
        int h = int.Parse(Console.ReadLine());

        int cx1 = int.Parse(Console.ReadLine());
        int cy1 = int.Parse(Console.ReadLine());
        
        int cx2 = int.Parse(Console.ReadLine());
        int cy2 = int.Parse(Console.ReadLine());
        
        int cx3 = int.Parse(Console.ReadLine());
        int cy3 = int.Parse(Console.ReadLine());



        //ensure s1 is always the left and down coordinate of the ship
        int width = Math.Abs(sx1 - sx2);
        int height = Math.Abs(sy1 - sy2); 
        sx1 = Math.Min(sx1, sx2);
        sy1 = Math.Min(sy1, sy2);

        //c1
        int firstShotY;

        if (cy1 >= h)
        {
            firstShotY = -(cy1 - h) + h;
        }
        else
        {
            firstShotY = Math.Abs(cy1 - h) + h; 
        }

        //c2
        int secondShotY;

        if (cy2 >= h)
        {
            secondShotY = -(cy2 - h) + h;
        }
        else
        {
            secondShotY = Math.Abs(cy2 - h) + h;
        }

        //c3
        int thirdShotY;

        if (cy3 >= h)
        {
            thirdShotY = -(cy3 - h) + h;
        }
        else
        {
            thirdShotY = Math.Abs(cy3 - h) + h;
        }

        //damage c1
        decimal damage = 0;

        //left and right side
        if (((cx1 == sx1) || (cx1 == sx1 + width)) && firstShotY > sy1 && firstShotY < sy1 + height)
        {
            damage += 0.5m;
        }

        //upper and lower side
        if ((firstShotY == sy1 || firstShotY == sy1 + height) && cx1 > sx1 && cx1 < sx1 + width)
        {
            damage += 0.5m;
        }

        //corners
        if ((cx1 == sx1 && (firstShotY == sy1 || firstShotY == sy1 + height)) || 
            (cx1 == sx1 + width && (firstShotY == sy1 || firstShotY == sy1 + height)))
        {
            damage += 0.25m;
        }

        //inside
        if ((cx1 > sx1 && cx1 < sx1 + width) && (firstShotY > sy1 && firstShotY < sy1 + height))
        {
            damage += 1;
        }

        //damage c2

        //left and right side
        if (((cx2 == sx1) || (cx2 == sx1 + width)) && secondShotY > sy1 && secondShotY < sy1 + height)
        {
            damage += 0.5m;
        }

        //upper and lower side
        if ((secondShotY == sy1 || secondShotY == sy1 + height) && cx2 > sx1 && cx2 < sx1 + width)
        {
            damage += 0.5m;
        }

        //corners
        if ((cx2 == sx1 && (secondShotY == sy1 || secondShotY == sy1 + height)) ||
            (cx2 == sx1 + width && (secondShotY == sy1 || secondShotY == sy1 + height)))
        {
            damage += 0.25m;
        }

        //inside
        if ((cx2 > sx1 && cx2 < sx1 + width) && (secondShotY > sy1 && secondShotY < sy1 + height))
        {
            damage += 1;
        }

        //damage c2

        //left and right side
        if (((cx3 == sx1) || (cx3 == sx1 + width)) && thirdShotY > sy1 && thirdShotY < sy1 + height)
        {
            damage += 0.5m;
        }

        //upper and lower side
        if ((thirdShotY == sy1 || thirdShotY == sy1 + height) && cx3 > sx1 && cx3 < sx1 + width)
        {
            damage += 0.5m;
        }

        //corners
        if ((cx3 == sx1 && (thirdShotY == sy1 || thirdShotY == sy1 + height)) ||
            (cx3 == sx1 + width && (thirdShotY == sy1 || thirdShotY == sy1 + height)))
        {
            damage += 0.25m;
        }

        //inside
        if ((cx3 > sx1 && cx3 < sx1 + width) && (thirdShotY > sy1 && thirdShotY < sy1 + height))
        {
            damage += 1;
        }


        Console.WriteLine("{0:0}%", damage * 100);
    }
}

