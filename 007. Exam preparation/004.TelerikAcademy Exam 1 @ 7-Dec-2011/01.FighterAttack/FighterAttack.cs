using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class FighterAttack
{
    static void Main()
    {
        int px1, py1, px2, py2, fx, fy, d;

        px1 = int.Parse(Console.ReadLine());
        py1 = int.Parse(Console.ReadLine());
        px2 = int.Parse(Console.ReadLine());
        py2 = int.Parse(Console.ReadLine());
        fx = int.Parse(Console.ReadLine());
        fy = int.Parse(Console.ReadLine());
        d = int.Parse(Console.ReadLine());

        //ensure p1 is the left down corner
        int length = Math.Abs(px1 - px2);
        int width = Math.Abs(py1 - py2);
        px1 = Math.Min(px1, px2);
        py1 = Math.Min(py1, py2);

        int shotX = fx + d;
        int shotForwardX = fx + d + 1;

        int leftShotX = fx + d;
        int leftShotY = fy + 1;

        int rightShotX = fx + d;
        int rightShotY = fy - 1;

        //solution
        int damage = 0;
        //central shot
        if (shotX >= px1 && shotX <= px1 + length && fy >= py1 && fy <= py1 + width)
        {
            damage += 100;
        }

        //left shot
        if (leftShotX >= px1 && leftShotX <= px1 + length && leftShotY >= py1 && leftShotY <= py1 + width)
        {
            damage += 50;
        }

        //right shot
        if (rightShotX >= px1 && rightShotX <= px1 + length && rightShotY >= py1 && rightShotY <= py1 + width)
        {
            damage += 50;
        }

        //forward shot
        if (shotForwardX >= px1 && shotForwardX <= px1 + length && fy >= py1 && fy <= py1 + width)
        {
            damage += 75;
        }



        Console.WriteLine(damage + "%");

    }
}

