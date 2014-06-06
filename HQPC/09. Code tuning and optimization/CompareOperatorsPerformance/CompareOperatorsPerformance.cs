namespace CompareOperatorsPerformance
{
    using System;
    using System.Diagnostics;

    public class CompareOperatorsPerformance
    {
        public static void Main()
        {
            const int ITERATIONS = 10000000;
            Console.WriteLine("INT:");
            OperatorsPerformanceInt(ITERATIONS, 1);
            Console.WriteLine("LONG:");
            OperatorsPerformanceInt(ITERATIONS, 1L);
            Console.WriteLine("FLOAT:");
            OperatorsPerformanceInt(ITERATIONS, 1f);
            Console.WriteLine("DOUBLE:");
            OperatorsPerformanceInt(ITERATIONS, 1d);
            Console.WriteLine("DECIMAL:");
            OperatorsPerformanceInt(ITERATIONS, 1M);
        }

        private static void OperatorsPerformanceInt(int iterations, int number)
        {
            Stopwatch stopwatch = new Stopwatch();

            // add
            stopwatch.Start();
            for (int i = 0; i < iterations; i++)
            {
                number = number + 1;
            }

            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed + " Add");
            stopwatch.Reset();

            // substract
            number = 1;
            stopwatch.Start();
            for (int i = 0; i < iterations; i++)
            {
                number = number - 1;
            }

            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed + " Substract");
            stopwatch.Reset();

            // increment
            number = 1;
            stopwatch.Start();
            for (int i = 0; i < iterations; i++)
            {
                number++;
            }

            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed + " Increment");
            stopwatch.Reset();

            // multiply
            number = 1;
            stopwatch.Start();
            for (int i = 0; i < iterations; i++)
            {
                number = number * 1;
            }

            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed + " Multiply");
            stopwatch.Reset();

            // divide
            number = 1;
            stopwatch.Start();
            for (int i = 0; i < iterations; i++)
            {
                number = number / 1;
            }

            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed + " Divide");
        }

        private static void OperatorsPerformanceInt(int iterations, long number)
        {
            Stopwatch stopwatch = new Stopwatch();

            // add
            stopwatch.Start();
            for (int i = 0; i < iterations; i++)
            {
                number = number + 1L;
            }

            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed + " Add");
            stopwatch.Reset();

            // substract
            number = 1L;
            stopwatch.Start();
            for (int i = 0; i < iterations; i++)
            {
                number = number - 1L;
            }

            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed + " Substract");
            stopwatch.Reset();

            // increment
            number = 1L;
            stopwatch.Start();
            for (int i = 0; i < iterations; i++)
            {
                number++;
            }

            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed + " Increment");
            stopwatch.Reset();

            // multiply
            number = 1L;
            stopwatch.Start();
            for (int i = 0; i < iterations; i++)
            {
                number = number * 1L;
            }

            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed + " Multiply");
            stopwatch.Reset();

            // divide
            number = 1L;
            stopwatch.Start();
            for (int i = 0; i < iterations; i++)
            {
                number = number / 1L;
            }

            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed + " Divide");
        }

        private static void OperatorsPerformanceInt(int iterations, float number)
        {
            Stopwatch stopwatch = new Stopwatch();

            // add
            stopwatch.Start();
            for (int i = 0; i < iterations; i++)
            {
                number = number + 1f;
            }

            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed + " Add");
            stopwatch.Reset();

            // substract
            number = 1f;
            stopwatch.Start();
            for (int i = 0; i < iterations; i++)
            {
                number = number - 1f;
            }

            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed + " Substract");
            stopwatch.Reset();

            // increment
            number = 1f;
            stopwatch.Start();
            for (int i = 0; i < iterations; i++)
            {
                number++;
            }

            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed + " Increment");
            stopwatch.Reset();

            // multiply
            number = 1f;
            stopwatch.Start();
            for (int i = 0; i < iterations; i++)
            {
                number = number * 1f;
            }

            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed + " Multiply");
            stopwatch.Reset();

            // divide
            number = 1f;
            stopwatch.Start();
            for (int i = 0; i < iterations; i++)
            {
                number = number / 1f;
            }

            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed + " Divide");
        }

        private static void OperatorsPerformanceInt(int iterations, double number)
        {
            Stopwatch stopwatch = new Stopwatch();

            // add
            stopwatch.Start();
            for (int i = 0; i < iterations; i++)
            {
                number = number + 1d;
            }

            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed + " Add");
            stopwatch.Reset();

            // substract
            number = 1d;
            stopwatch.Start();
            for (int i = 0; i < iterations; i++)
            {
                number = number - 1d;
            }

            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed + " Substract");
            stopwatch.Reset();

            // increment
            number = 1d;
            stopwatch.Start();
            for (int i = 0; i < iterations; i++)
            {
                number++;
            }

            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed + " Increment");
            stopwatch.Reset();

            // multiply
            number = 1L;
            stopwatch.Start();
            for (int i = 0; i < iterations; i++)
            {
                number = number * 1d;
            }

            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed + " Multiply");
            stopwatch.Reset();

            // divide
            number = 1d;
            stopwatch.Start();
            for (int i = 0; i < iterations; i++)
            {
                number = number / 1d;
            }

            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed + " Divide");
        }

        private static void OperatorsPerformanceInt(int iterations, decimal number)
        {
            Stopwatch stopwatch = new Stopwatch();

            // add
            stopwatch.Start();
            for (int i = 0; i < iterations; i++)
            {
                number = number + 1M;
            }

            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed + " Add");
            stopwatch.Reset();

            // substract
            number = 1M;
            stopwatch.Start();
            for (int i = 0; i < iterations; i++)
            {
                number = number - 1M;
            }

            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed + " Substract");
            stopwatch.Reset();

            // increment
            number = 1M;
            stopwatch.Start();
            for (int i = 0; i < iterations; i++)
            {
                number++;
            }

            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed + " Increment");
            stopwatch.Reset();

            // multiply
            number = 1M;
            stopwatch.Start();
            for (int i = 0; i < iterations; i++)
            {
                number = number * 1M;
            }

            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed + " Multiply");
            stopwatch.Reset();

            // divide
            number = 1M;
            stopwatch.Start();
            for (int i = 0; i < iterations; i++)
            {
                number = number / 1M;
            }

            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed + " Divide");
        }
    }
}
