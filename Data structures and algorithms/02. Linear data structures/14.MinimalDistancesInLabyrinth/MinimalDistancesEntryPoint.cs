namespace _14.MinimalDistancesInLabyrinth
{
    public class MinimalDistancesEntryPoint
    {
        static void Main()
        {
            int[,] input = new int[,]
                {
                    { 0, 0, 0, -1, 0, -1 },
                    { 0, -1, 0, -1, 0, -1 },
                    { 0, 0, -1, 0, -1, 0 },
                    { 0, -1, 0, 0, 0, 0 },
                    { 0, 0, 0, -1, -1, 0 },
                    { 0, 0, 0, -1, 0, -1 },
                };

            var labyrinth = new Labyrinth(input);
            labyrinth.PrintStringifiedPathData(2, 1);


        }
    }
}
