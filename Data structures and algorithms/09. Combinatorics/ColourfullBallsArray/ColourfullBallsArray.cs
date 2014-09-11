using System;
using System.Collections.Generic;

namespace ColorBalls
{
    class ColorBalls
    {
        static int count = 1;
        static Char[] ballsToCharArray;
        static void Main()
        {
            string balls = Console.ReadLine();
            ballsToCharArray = balls.ToCharArray();

            Array.Sort(ballsToCharArray);
            Permutate(0, ballsToCharArray.Length);
            Console.WriteLine(count);
        }

        static void Permutate(int start, int n)
        {
            count++;

            for (int left = n - 2; left >= start; left--)
            {
                for (int right = left + 1; right < n; right++)
                {
                    if (ballsToCharArray[left] != ballsToCharArray[right])
                    {
                        var temp = ballsToCharArray[left];
                        ballsToCharArray[left] = ballsToCharArray[right];
                        ballsToCharArray[right] = temp;

                        Permutate(left + 1, n);
                    }
                }

                var firstElement = ballsToCharArray[left];
                for (int i = left; i < n - 1; i++)
                {
                    ballsToCharArray[i] = ballsToCharArray[i + 1];
                }

                ballsToCharArray[n - 1] = firstElement;
            }
        }
    }
}
