using System;
using System.Collections.Generic;
using System.Text;

class OneTaskIsNotEnough
{
    static int FindLastLamp()
    {
        int num = int.Parse(Console.ReadLine());
        int[] lamps = new int[num];
        for (int i = 0; i < lamps.Length; i++)
        {
            lamps[i] = i + 1;
        }

        bool[] turnedON = new bool[num];

        int step = 2;
        int lastLamp = 0;

        while (num > 0)
        {
            //reset boolean array
            Array.Clear(turnedON, 0, num -1);

            int currNum = 0;
            for (int i = 0; i < num; i += step)
            {
                turnedON[i] = true;
            }

            for (int i = 0; i < num; i++)
            {
                if (!turnedON[i])
                {
                    lamps[currNum] = lamps[i];
                    currNum++;
                    lastLamp = lamps[i];
                }
            }
            step++;
            num = currNum;
        }
        return lastLamp;
    }

    static void ExecuteCommandLine(string commands, ref int x,  ref int y, ref int direction)
    {
        for (int i = 0; i < commands.Length; i++)
        {
            char tempCom = commands[i];
            if (tempCom == 'L')
            {
                if (direction != 4)
                {
                    direction++;
                }
                else
                {
                    direction = 1;
                }
            }
            else if (tempCom == 'R')
            {
                if (direction != 1)
                {
                    direction--;
                }
                else
                {
                    direction = 4;
                }
            }
            else if (tempCom == 'S')
            {
                switch (direction)
                {
                    case 1: y++;
                        break;
                    case 2: x--;
                        break;
                    case 3: y--;
                        break;
                    case 4: x++;
                        break;

                    default: throw new ArgumentException("Invalid direction!");
                }
            }
        }
    }

    static string CheckRobot()
    {
        string commands = Console.ReadLine();
        int x = 0;
        int y = 0;
        int direction = 1;
        ExecuteCommandLine(commands, ref x, ref y, ref direction);
        ExecuteCommandLine(commands, ref x, ref y, ref direction);
        ExecuteCommandLine(commands, ref x, ref y, ref direction);
        ExecuteCommandLine(commands, ref x, ref y, ref direction);
        if (x == 0 && y == 0)
        {
            return "bounded";
        }
        else
            return "unbounded";
        //if (x == 0 && y == 0)
        //{
        //    return "bounded";
        //}
        //else
        //{
        //    ExecuteCommandLine(commands, ref x, ref y, ref direction);
        //}

        //if (x == 0 && y == 0)
        //{
        //    return "bounded";
        //}
        //else
        //{
        //    ExecuteCommandLine(commands, ref x, ref y, ref direction);
        //}

        //if (x == 0 && y == 0)
        //{
        //    return "bounded";
        //}
        //else
        //{
        //    ExecuteCommandLine(commands, ref x, ref y, ref direction);
        //}

        //if (x == 0 && y == 0)
        //{
        //    return "bounded";
        //}
        //else
        //{
        //    return "unbounded";
        //}

    }

    static void Main()
    {
        //first task
        int lastLamp = FindLastLamp();
        Console.WriteLine(lastLamp);

        //second task
        Console.WriteLine(CheckRobot());
        Console.WriteLine(CheckRobot());


    }
}

