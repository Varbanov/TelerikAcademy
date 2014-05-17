namespace Mines
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class MineSweeper
    {
        public static void Main()
        {
            const int MAX_POINTS = 35;
            string command = string.Empty;
            char[,] field = CreateField();
            char[,] bombs = InsertBombs();
            int playerPointsCounter = 0;
            bool hasExploded = false;
            List<Point> champions = new List<Point>(6);
            int row = 0;
            int col = 0;
            bool isNewlyStarted = true;
            bool gameWon = false;

            do
            {
                if (isNewlyStarted)
                {
                    Console.WriteLine("Let's play Mines! Try your luck and find the fields that are not mined! Hit \"Top\" to show highscores, hit \"Restart\" to start a new game, or hit \"Exit\" to quit.");
                    Draw(field);
                    isNewlyStarted = false;
                }

                Console.Write("Please Enter row and col: ");
                command = Console.ReadLine().Trim();
                if (command.Length >= 3)
                {
                    if (int.TryParse(command[0].ToString(), out row) &&
                    int.TryParse(command[2].ToString(), out col) &&
                        row <= field.GetLength(0) && col <= field.GetLength(1))
                    {
                        command = "turn";
                    }
                }

                switch (command)
                {
                    case "top":
                        GenerateHighScores(champions);
                        break;
                    case "restart":
                        field = CreateField();
                        bombs = InsertBombs();
                        Draw(field);
                        hasExploded = false;
                        isNewlyStarted = false;
                        break;
                    case "exit":
                        Console.WriteLine("See you next time!");
                        break;
                    case "turn":
                        if (bombs[row, col] != '*')
                        {
                            if (bombs[row, col] == '-')
                            {
                                PlayYourTurn(field, bombs, row, col);
                                playerPointsCounter++;
                            }

                            if (MAX_POINTS == playerPointsCounter)
                            {
                                gameWon = true;
                            }
                            else
                            {
                                Draw(field);
                            }
                        }
                        else
                        {
                            hasExploded = true;
                        }

                        break;

                    default:
                        {
                            Console.WriteLine("Error! Invalid command!");
                            break;
                        }
                }

                if (hasExploded)
                {
                    Draw(bombs);
                    Console.WriteLine("Game over! Your points are: {0}. Please enter your nickname", playerPointsCounter);
                    string currentName = Console.ReadLine();
                    Point currentPoints = new Point(currentName, playerPointsCounter);
                    if (champions.Count < 5)
                    {
                        champions.Add(currentPoints);
                    }
                    else
                    {
                        for (int i = 0; i < champions.Count; i++)
                        {
                            if (champions[i].Points < currentPoints.Points)
                            {
                                champions.Insert(i, currentPoints);
                                champions.RemoveAt(champions.Count - 1);
                                break;
                            }
                        }
                    }

                    champions.Sort((Point firstPoint, Point secondPoint) => firstPoint.Name.CompareTo(secondPoint.Name));
                    champions.Sort((Point firstPoint, Point secondPoint) => firstPoint.Points.CompareTo(secondPoint.Points));
                    GenerateHighScores(champions);

                    field = CreateField();
                    bombs = InsertBombs();
                    playerPointsCounter = 0;
                    hasExploded = false;
                    isNewlyStarted = true;
                }

                if (gameWon)
                {
                    Console.WriteLine("Congratulations! You opened {0} cells successfully", MAX_POINTS);
                    Draw(bombs);
                    Console.WriteLine("Enter your name: ");
                    string currentName = Console.ReadLine();
                    Point currentPoints = new Point(currentName, playerPointsCounter);
                    champions.Add(currentPoints);
                    GenerateHighScores(champions);
                    field = CreateField();
                    bombs = InsertBombs();
                    playerPointsCounter = 0;
                    gameWon = false;
                    isNewlyStarted = true;
                }
            }
            while (command != "exit");

            Console.WriteLine("Made in Bulgaria.");
            Console.Read();
        }

        private static void GenerateHighScores(List<Point> points)
        {
            Console.WriteLine("\nPoints:");
            if (points.Count > 0)
            {
                for (int i = 0; i < points.Count; i++)
                {
                    Console.WriteLine("{0}. {1} --> {2} cells", i + 1, points[i].Name, points[i].Points);
                }

                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("The highscores are empty t\n");
            }
        }

        private static void PlayYourTurn(char[,] field, char[,] bombs, int row, int col)
        {
            char numberOfBombs = CountBombs(bombs, row, col);
            bombs[row, col] = numberOfBombs;
            field[row, col] = numberOfBombs;
        }

        private static void Draw(char[,] field)
        {
            int fieldRows = field.GetLength(0);
            int fieldCols = field.GetLength(1);
            Console.WriteLine("\n    0 1 2 3 4 5 6 7 8 9");
            Console.WriteLine("   ---------------------");
            for (int i = 0; i < fieldRows; i++)
            {
                Console.Write("{0} | ", i);
                for (int j = 0; j < fieldCols; j++)
                {
                    Console.Write(string.Format("{0} ", field[i, j]));
                }

                Console.Write("|");
                Console.WriteLine();
            }

            Console.WriteLine("   ---------------------\n");
        }

        private static char[,] CreateField()
        {
            int fieldRows = 5;
            int fielsColumns = 10;
            char[,] board = new char[fieldRows, fielsColumns];
            for (int i = 0; i < fieldRows; i++)
            {
                for (int j = 0; j < fielsColumns; j++)
                {
                    board[i, j] = '?';
                }
            }

            return board;
        }

        private static char[,] InsertBombs()
        {
            int rows = 5;
            int cols = 10;
            char[,] field = new char[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    field[i, j] = '-';
                }
            }

            List<int> positions = new List<int>();
            while (positions.Count < 15)
            {
                Random random = new Random();
                int randomNum = random.Next(50);
                if (!positions.Contains(randomNum))
                {
                    positions.Add(randomNum);
                }
            }

            foreach (int posititon in positions)
            {
                int kol = posititon / cols;
                int red = posititon % cols;
                if (red == 0 && posititon != 0)
                {
                    kol--;
                    red = cols;
                }
                else
                {
                    red++;
                }

                field[kol, red - 1] = '*';
            }

            return field;
        }

        private static void InsertCellsBombNumber(char[,] field)
        {
            int fieldCols = field.GetLength(0);
            int fieldRows = field.GetLength(1);

            for (int i = 0; i < fieldCols; i++)
            {
                for (int j = 0; j < fieldRows; j++)
                {
                    if (field[i, j] != '*')
                    {
                        char bombCount = CountBombs(field, i, j);
                        field[i, j] = bombCount;
                    }
                }
            }
        }

        private static char CountBombs(char[,] field, int currentRow, int currentCol)
        {
            int sum = 0;
            int fieldRows = field.GetLength(0);
            int fieldCols = field.GetLength(1);

            if (currentRow - 1 >= 0)
            {
                if (field[currentRow - 1, currentCol] == '*')
                {
                    sum++;
                }
            }

            if (currentRow + 1 < fieldRows)
            {
                if (field[currentRow + 1, currentCol] == '*')
                {
                    sum++;
                }
            }

            if (currentCol - 1 >= 0)
            {
                if (field[currentRow, currentCol - 1] == '*')
                {
                    sum++;
                }
            }

            if (currentCol + 1 < fieldCols)
            {
                if (field[currentRow, currentCol + 1] == '*')
                {
                    sum++;
                }
            }

            if ((currentRow - 1 >= 0) && (currentCol - 1 >= 0))
            {
                if (field[currentRow - 1, currentCol - 1] == '*')
                {
                    sum++;
                }
            }

            if ((currentRow - 1 >= 0) && (currentCol + 1 < fieldCols))
            {
                if (field[currentRow - 1, currentCol + 1] == '*')
                {
                    sum++;
                }
            }

            if ((currentRow + 1 < fieldRows) && (currentCol - 1 >= 0))
            {
                if (field[currentRow + 1, currentCol - 1] == '*')
                {
                    sum++;
                }
            }

            if ((currentRow + 1 < fieldRows) && (currentCol + 1 < fieldCols))
            {
                if (field[currentRow + 1, currentCol + 1] == '*')
                {
                    sum++;
                }
            }

            return char.Parse(sum.ToString());
        }

        private class Point
        {
            private string name;
            private int points;

            public Point()
            {
            }

            public Point(string name, int points)
            {
                this.Name = name;
                this.Points = points;
            }

            public string Name
            {
                get { return this.name; }
                set { this.name = value; }
            }

            public int Points
            {
                get { return this.points; }
                set { this.points = value; }
            }
        }
    }
}
