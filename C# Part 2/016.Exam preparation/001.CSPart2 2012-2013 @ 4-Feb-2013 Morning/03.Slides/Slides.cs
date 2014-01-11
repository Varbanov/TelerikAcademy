using System;

class Slides
{
    static int w;
    static int h;
    static int d;
    static string[, ,] cuboid;

    struct Point
    {
        public int w, h, d;

        public Point(int width, int height, int depth)
        {
            w = width;
            h = height;
            d = depth;
        }
    }

    static void CuboidInput(out int w, out int h, out int d, out string[, ,] cuboid)
    {
        //dimensions input
        string inputDimensions = Console.ReadLine();
        string[] splittedDimensions = inputDimensions.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        w = int.Parse(splittedDimensions[0]);
        h = int.Parse(splittedDimensions[1]);
        d = int.Parse(splittedDimensions[2]);


        cuboid = new String[w, h, d];

        //cuboid input
        for (int height = 0; height < h; height++)
        {
            string[] layerParts = Console.ReadLine().Trim().Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);

            for (int depth = 0; depth < d; depth++)
            {
                string depthArr = layerParts[depth].Trim();
                string[] dArrays = depthArr.Split(new char[] { '(', ')' }, StringSplitOptions.RemoveEmptyEntries);

                for (int width = 0; width < w; width++)
                {
                    cuboid[width, height, depth] = dArrays[width];
                }
            }
        }
    }

    static Point InitializeStartingPoint()
    {
        //ball coordinates input
        string ballCoordinates = Console.ReadLine();
        string[] splitedCoordinates = ballCoordinates.Split(' ');

        int ballW = int.Parse(splitedCoordinates[0]);
        int ballD = int.Parse(splitedCoordinates[1]);

        Point cell = new Point(ballW, 0, ballD);
        return cell;
    }

    private static Point SlideBallToLowestButOneLayer(int w, int h, int d, string[, ,] cuboid, Point cell)
    {
        while (cell.h < h - 1)
        {
            string instructions = cuboid[cell.w, cell.h, cell.d];

            //slide
            if (instructions == "S F")
            {
                if (cell.d > 0)
                {
                    cell.d--;
                    cell.h++;
                }
                else
                {
                    break;
                }
            }
            else if (instructions == "S B")
            {
                if (cell.d < d - 1)
                {
                    cell.d++;
                    cell.h++;
                }
                else
                {
                    break;
                }
            }
            else if (instructions == "S L")
            {
                if (cell.w > 0)
                {
                    cell.w--;
                    cell.h++;
                }
                else
                {
                    break;
                }
            }
            else if (instructions == "S R")
            {
                if (cell.w < w - 1)
                {
                    cell.w++;
                    cell.h++;
                }
                else
                {
                    break;
                }
            }
            else if (instructions == "S FL")
            {
                if (cell.w > 0 && cell.d > 0)
                {
                    cell.w--;
                    cell.d--;
                    cell.h++;
                }
                else
                {
                    break;
                }
            }
            else if (instructions == "S FR")
            {
                if (cell.w < w - 1 && cell.d > 0)
                {
                    cell.w++;
                    cell.d--;
                    cell.h++;
                }
                else
                {
                    break;
                }
            }
            else if (instructions == "S BL")
            {
                if (cell.w > 0 && cell.d < d - 1)
                {
                    cell.w--;
                    cell.d++;
                    cell.h++;
                }
                else
                {
                    break;
                }
            }
            else if (instructions == "S BR")
            {
                if (cell.w < w - 1 && cell.d < d - 1)
                {
                    cell.w++;
                    cell.d++;
                    cell.h++;
                }
                else
                {
                    break;
                }
            }
            //teleport
            else if (instructions[0] == 'T')
            {
                string[] splittedTeleport = instructions.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                int teleportW = int.Parse(splittedTeleport[1]);
                int teleportD = int.Parse(splittedTeleport[2]);

                if (teleportW >= 0 && teleportW < w && teleportD >= 0 && teleportD < d)
                {
                    //TODO: moje da sum razmenil
                    cell.d = teleportD;
                    cell.w = teleportW;
                }
                else
                {
                    break;
                }
            }
            //empty
            else if (instructions == "E")
            {
                cell.h++;
            }
            //basket
            else if (instructions == "B")
            {
                break;
            }
            else throw new ArgumentException("Invalid Instruction!");
        }
        return cell;
    }

    static void CheckBallInBottomLayer(Point cell)
    {
        //bottom layer
        if (cell.h < h - 1)
        {
            Console.WriteLine("No");
            Console.WriteLine("{0} {1} {2}", cell.w, cell.h, cell.d);
        }
        else
        {
            while (cell.h == h - 1)
            {
                string instructions = cuboid[cell.w, cell.h, cell.d];

                if (instructions[0] == 'S')
                {
                    Console.WriteLine("Yes");
                    Console.WriteLine("{0} {1} {2}", cell.w, cell.h, cell.d);
                    break;
                }
                else if (instructions == "E")
                {
                    Console.WriteLine("Yes");
                    Console.WriteLine("{0} {1} {2}", cell.w, cell.h, cell.d);
                    break;
                }
                else if (instructions == "B")
                {
                    Console.WriteLine("No");
                    Console.WriteLine("{0} {1} {2}", cell.w, cell.h, cell.d);
                    break;
                }
                else if (instructions[0] == 'T')
                {
                    string[] splittedTeleport = instructions.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    int teleportW = int.Parse(splittedTeleport[1]);
                    int teleportD = int.Parse(splittedTeleport[2]);

                    if (teleportW >= 0 && teleportW < w && teleportD >= 0 && teleportD < d)
                    {
                        cell.w = teleportW;
                        cell.d = teleportD;
                    }
                    else
                    {
                        Console.WriteLine("No");
                        Console.WriteLine("{0} {1} {2}", cell.w, cell.h, cell.d);
                        break;
                    }
                }
            }
        }
    }

    static void Main()
    {
        CuboidInput(out w, out h, out d, out cuboid);
        Point cell = InitializeStartingPoint();
        cell = SlideBallToLowestButOneLayer(w, h, d, cuboid, cell);
        CheckBallInBottomLayer(cell);
    }

   


  

  
}

