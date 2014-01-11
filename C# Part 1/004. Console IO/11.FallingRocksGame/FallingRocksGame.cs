using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Rocks are the symbols ^, @, *, &, +, %, $, #, !, ., ;, - 
//* Implement the "Falling Rocks" game in the text console. A small dwarf stays at the bottom of the screen and can move left and
//right (by the arrows keys). A number of rocks of different sizes and forms constantly fall down and you need to avoid a crash.

class FallingRocksGame
{
    static char[] rockCharType = { '^', '@', '*', '&', '+', '%', '$', '#', '!', '.', ';', '-' };
    static Random randomGenerator = new Random();
    static Queue<Rocks> QueueOfRocks = new Queue<Rocks>();
    static int initialDwarfPosition = Console.WindowWidth / 2 - 1;
    static string dwarf = "Dzhu";
    static bool collision = false;
    static int scores = 0;
    static bool startNewGameIntroSkip = true;
    static int speedSleepTime = 250;
    static string scoreFilePath = Directory.GetCurrentDirectory() + @"\bestScore.txt";
    static int level = 2;
    static int levelNumOfRocksOnScreen = 61; //30 lines * 2 rocks on line = queue.count
    static ConsoleColor[] Colors = { ConsoleColor.Blue, ConsoleColor.Cyan, ConsoleColor.DarkBlue, ConsoleColor.DarkCyan, ConsoleColor.DarkGray, ConsoleColor.DarkGreen, ConsoleColor.DarkMagenta, ConsoleColor.DarkRed, ConsoleColor.DarkYellow, ConsoleColor.Gray, ConsoleColor.Green, ConsoleColor.Magenta, ConsoleColor.Red, ConsoleColor.White, ConsoleColor.Yellow };

    private static void RockFallCreation()
    {
        //initialize instances of Rocks class
        for (int i = 0; i < level; i++)
        {
            Rocks rock = new Rocks(' ', 0, 0, 0);
            rock.RockInitialCol = randomGenerator.Next(0, Console.WindowWidth);
            rock.RockInitialRow = 0;
            rock.RockType = rockCharType[randomGenerator.Next(0, 12)];
            rock.RockColorIndex = randomGenerator.Next(0, 15);
            QueueOfRocks.Enqueue(rock);
        }
        //dispose of instances that went out of screen
        while (QueueOfRocks.Count > levelNumOfRocksOnScreen)
        {
            QueueOfRocks.Dequeue();
        }
    }

    private static void DrawRockFall()
    {
        //allocate and draw the instances of Rocks created on the screen and move rocks downwards
        foreach (Rocks item in QueueOfRocks)
        {
            if (item.RockInitialRow < Console.WindowHeight - 2)
            {
                Console.SetCursorPosition(item.RockInitialCol, item.RockInitialRow);
                Console.ForegroundColor = Colors[item.RockColorIndex];
                Console.Write(item.RockType);
                Console.ResetColor();

            }
            if (item.RockInitialRow == Console.WindowHeight - 2)
            {
                if (item.RockInitialCol < initialDwarfPosition || item.RockInitialCol > initialDwarfPosition + 2)
                {
                    Console.SetCursorPosition(item.RockInitialCol, item.RockInitialRow);
                    Console.Write(item.RockType);
                }
            }
            item.UpdateRockLocation();

        }
        System.Threading.Thread.Sleep(150);
        Console.Clear();
    }

    private static void DrawDwarf()
    {
        //Draw the dwarf that is controlled by the player
        Console.ForegroundColor = ConsoleColor.Red;
        Console.SetCursorPosition(initialDwarfPosition, Console.WindowHeight - 2);
        Console.Write(dwarf);
        Console.ResetColor();
    }

    private static void DwarfLefMove()
    {
        //left control
        if (initialDwarfPosition > 0)
        {
            initialDwarfPosition--;
        }
    }

    private static void DwarfRightMove()
    {
        //right control
        if (initialDwarfPosition < Console.WindowWidth - 4)
        {
            initialDwarfPosition++;
        }
    }

    private static void ConsoleFrame()
    {
        //set the settings of the play frame needed
        Console.SetWindowSize(80, 30);
        Console.BufferWidth = Console.WindowWidth;
        Console.BufferHeight = Console.WindowHeight;
        Console.OutputEncoding = Encoding.UTF8;
    }

    private static void Collision()
    {
        //check if the dwarf got hit by an instance of Rocks
        foreach (Rocks item in QueueOfRocks)
        {
            if (item.RockInitialRow == Console.WindowHeight - 2)
            {
                if (item.RockInitialCol >= initialDwarfPosition && item.RockInitialCol <= initialDwarfPosition + 3)
                {
                    collision = true;
                }
            }
        }

        //if hit, break game
        if (collision)
        {
            DrawDwarf();
            foreach (var item in QueueOfRocks)
            {
                if (item.RockInitialRow <= Console.WindowHeight - 2)
                {
                    Console.SetCursorPosition(item.RockInitialCol, item.RockInitialRow);
                    Console.Write(item.RockType);
                }
            }
            DrawDwarf();
            Console.SetCursorPosition(Console.WindowWidth / 2 - 10, 5);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("GAME OVER!");
            Console.SetCursorPosition(Console.WindowWidth / 2 - 10, 6);
            Console.Write("YOUR SCORES ARE: {0}", scores);
            Console.SetCursorPosition(Console.WindowWidth / 2 - 10, 7);

            //implements best scores counter
            if (File.Exists(scoreFilePath))
            {
                int readTxtScores = int.Parse(File.ReadAllText(scoreFilePath));
                if (scores > readTxtScores)
                {
                    Console.WriteLine("BEST SCORES: {0}", scores);
                    File.WriteAllText(scoreFilePath, Convert.ToString(scores));
                }
                else
                {
                    Console.WriteLine("BEST SCORES: {0}", readTxtScores);
                }
            }
            else
            {
                Console.WriteLine("BEST SCORES: {0}", scores);
                File.WriteAllText(scoreFilePath, Convert.ToString(scores));
            }


            //implements menu control
            Console.SetCursorPosition(Console.WindowWidth / 2 - 10, 8);
            Console.WriteLine("FOR NEW GAME PRESS \'N\'");
            Console.SetCursorPosition(Console.WindowWidth / 2 - 10, 9);
            Console.WriteLine("TO EXIT PRESS ANY OTHER KEY");
            Console.SetCursorPosition(3, Console.WindowHeight - 1);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("\u00A9 Created by xxx \u00A9");
            Console.ResetColor();

            ConsoleKeyInfo keyPlayorQuit = Console.ReadKey();
            if (keyPlayorQuit.Key == ConsoleKey.N)
            {
                startNewGameIntroSkip = false;
                collision = false;
                Console.Clear();
                QueueOfRocks.Clear();
                scores = 0;
                initialDwarfPosition = Console.WindowWidth / 2 - 1;
                Main();
            }
        }
    }

    private static void Scores()
    {
        //implements ongoing scores counter and difficulty level
        Console.SetCursorPosition(3, Console.WindowHeight - 1);
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("\u00A9 Created by xxx \u00A9   Your scores are: {0}.", scores);
        foreach (Rocks item in QueueOfRocks)
        {
            if (item.RockType == '$')
            {
                scores += 50;
            }
        }

        if (scores > 10000)
        {
            speedSleepTime = 130;
        }
        if (scores > 15000)
        {
            speedSleepTime = 100;
        }
        if (scores > 25000)
        {
            level = 3;
            speedSleepTime = 0;
        }
        levelNumOfRocksOnScreen = 90; // 30 lines x 3 rocks on line = queue.count=90

    }

    private static void StartGame()
    {
        //intro
        if (startNewGameIntroSkip == true)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Title = "Dwarf \u00A9 v.1.0";

            string wellcomeText1 = "A small dwarf with the name Dhzu lives at the foot of the Dwarfy Mountain \ncliff, in constant struggle to survive the rocks rolling down to the very unseenbottom of the abyss. Embark on a fairy journey with Dzhu and help him survive.\n    Use the arrow keys to navigate Dzhu through the emerald rockfall. \n    Press any key to start new game.";

            Console.SetCursorPosition(5, 5);
            foreach (char item in wellcomeText1)
            {
                Console.Write(item);
                System.Threading.Thread.Sleep(10);
            }

            Console.SetCursorPosition(15, 13);
            Console.WriteLine("Created by xxx \u00A9");
            Console.ResetColor();
            ConsoleKeyInfo keyStartGame = Console.ReadKey();
        }
    }

    static void Main()
    {
        ConsoleFrame();
        StartGame();

        while (true)
        {
            while (Console.KeyAvailable)
            {
                ConsoleKeyInfo key = Console.ReadKey();
                if (key.Key == ConsoleKey.LeftArrow)
                {
                    DwarfLefMove();
                }
                if (key.Key == ConsoleKey.RightArrow)
                {
                    DwarfRightMove();
                }
            }

            DrawDwarf();
            Scores();
            RockFallCreation();
            DrawRockFall();
            Collision();
            if (collision)
            {
                return;
            }
        }
    }
}


