namespace CompareOperatorsPerformance
{
    using System;
    using System.Diagnostics;

    public class SqrtSinLogPerformance
    {
        public static void Main()
        {
            int ITERATIONS = 10000000;

            Console.WriteLine("SQRT:");
            SquareRootPerformance(ITERATIONS, 1f);
            SquareRootPerformance(ITERATIONS, 1d);
            SquareRootPerformance(ITERATIONS, 1M);

            Console.WriteLine("LOG:");
            LogPerformance(ITERATIONS, 1f);
            LogPerformance(ITERATIONS, 1d);
            LogPerformance(ITERATIONS, 1M);

            Console.WriteLine("SIN:");
            SinPerformance(ITERATIONS, 1f);
            SinPerformance(ITERATIONS, 1d);
            SinPerformance(ITERATIONS, 1M);
        }

        private static void SinPerformance(int iterations, decimal number)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            for (int i = 0; i < iterations; i++)
            {
                Math.Sin((double)number);
            }

            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed);
        }

        private static void SinPerformance(int iterations, double number)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            for (int i = 0; i < iterations; i++)
            {
                Math.Sin(number);
            }

            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed);
        }

        private static void SinPerformance(int iterations, float number)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            for (int i = 0; i < iterations; i++)
            {
                Math.Sin(number);
            }

            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed);
        }

        private static void LogPerformance(int iterations, float number)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            for (int i = 0; i < iterations; i++)
            {
                Math.Log(number);
            }

            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed);
        }

        private static void LogPerformance(int iterations, decimal number)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            for (int i = 0; i < iterations; i++)
            {
                Math.Log((double)number);
            }

            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed);
        }

        private static void LogPerformance(int iterations, double number)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            for (int i = 0; i < iterations; i++)
            {
                Math.Log(number);
            }

            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed);
        }

        private static void SquareRootPerformance(int iterations, float number)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            for (int i = 0; i < iterations; i++)
            {
                Math.Sqrt(number);
            }

            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed);
        }

        private static void SquareRootPerformance(int iterations, double number)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            for (int i = 0; i < iterations; i++)
            {
                Math.Sqrt(number);
            }

            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed);
        }

        private static void SquareRootPerformance(int iterations, decimal number)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            for (int i = 0; i < iterations; i++)
            {
                Math.Sqrt((double)number);
            }

            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed);
        }
    }
}
