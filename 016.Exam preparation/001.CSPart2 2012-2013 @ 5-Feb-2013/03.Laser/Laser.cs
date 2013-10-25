using System;

class Laser
{
    private static bool[, ,] CuboidInput()
    {
        //cuboid dimensions
        string size = Console.ReadLine();
        string[] sizeTokens = size.Split(' ');
        int w = int.Parse(sizeTokens[0]);
        int h = int.Parse(sizeTokens[1]);
        int d = int.Parse(sizeTokens[2]);
        bool[, ,] cuboid = new bool[w, h, d];

        //blue edges
        for (int width = 0; width < w; width++)
        {
            cuboid[width, 0, 0] = true;
            cuboid[width, h - 1, 0] = true;
            cuboid[width, 0, d - 1] = true;
            cuboid[width, h - 1, d - 1] = true;
        }

        //green edges
        for (int height = 0; height < h; height++)
        {
            cuboid[0, height, 0] = true;
            cuboid[0, height, d - 1] = true;
            cuboid[w - 1, height, 0] = true;
            cuboid[w - 1, height, d - 1] = true;
        }

        //red edges
        for (int depth = 0; depth < d-1; depth++)
        {
            cuboid[0, 0, depth] = true;
            cuboid[w - 1, 0, depth] = true;
            cuboid[0, h - 1, depth] = true;
            cuboid[w - 1, h - 1, depth] = true;
        }
        return cuboid;
    }

    private static void StartInput(out int startW, out int startH, out int startD)
    {
        //starting point
        string start = Console.ReadLine();
        string[] startTokens = start.Split(' ');
        startW = int.Parse(startTokens[0]) - 1;
        startH = int.Parse(startTokens[1]) - 1;
        startD = int.Parse(startTokens[2]) - 1;
    }

    private static void LaserStrike(bool[, ,] cuboid, int startW, int startH, int startD, int dirW, int dirH, int dirD)
    {
        int w, h, d;
        w = cuboid.GetLength(0);
        h = cuboid.GetLength(1);
        d = cuboid.GetLength(2);
        int nextW, nextH, nextD;

        while (true)
        {
            cuboid[startW, startH, startD] = true;
            //width
            switch (dirW)
            {
                case 0:
                    nextW = startW;
                    break;
                case 1:
                    if (startW + dirW >= w)
                    {
                        dirW = -1;
                    }
                    nextW = startW + dirW;
                    break;
                case -1:
                    if (startW + dirW < 0)
                    {
                        dirW = 1;
                    }
                    nextW = startW + dirW;                    
                    break;
                default: throw new ArgumentException("Invalid width!");
            }
            //height
            switch (dirH)
            {
                case 0:
                    nextH = startH;
                    break;
                case 1:
                    if (startH + dirH >= h)
                    {
                        dirH = -1;
                    }
                    nextH = startH + dirH;
                    break;
                case -1:
                    if (startH + dirH < 0)
                    {
                        dirH = 1;
                    }
                    nextH = startH + dirH;
                    break;
                default: throw new ArgumentException("Invalid height!");
            }
            //depth
            switch (dirD)
            {
                case 0:
                    nextD = startD;
                    break;
                case 1:
                    if (startD + dirD >= d)
                    {
                        dirD = -1;
                    }
                    nextD = startD + dirD;
                    break;
                case -1:
                    if (startD + dirD < 0)
                    {
                        dirD = 1;
                    }
                    nextD = startD + dirD;
                    break;
                default: throw new ArgumentException("Invalid depth!");
            }

            if (cuboid[nextW, nextH, nextD] == true)
            {
                break;
            }
            else
            {
                startW = nextW;
                startH = nextH;
                startD = nextD;
            }
        }

        Console.WriteLine("{0} {1} {2}", startW + 1, startH+1, startD+ 1);
    }

    private static void DirectionInput(out int dirW, out int dirH, out int dirD)
    {
        string direction = Console.ReadLine();
        string[] directionTokens = direction.Split(' ');
        dirW = int.Parse(directionTokens[0]);
        dirH = int.Parse(directionTokens[1]);
        dirD = int.Parse(directionTokens[2]);
    }

    static void Main()
    {
        bool[, ,] cuboid = CuboidInput();
        int startW, startH, startD;
        StartInput(out startW, out startH, out startD);
        int dirW, dirH, dirD;
        DirectionInput(out dirW, out dirH, out dirD);

        LaserStrike(cuboid, startW, startH, startD, dirW, dirH, dirD);
    }
   
}

