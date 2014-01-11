using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

class MathExpression
{
    static void Main()
    {
        System.Threading.Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

        double n = double.Parse(Console.ReadLine());
        double m = double.Parse(Console.ReadLine());
        double p = double.Parse(Console.ReadLine());

        double sin = Math.Sin((int) m % 180);

        double nominator = n * n + 1 / (m * p) + 1337;
        double denominator = n - 128.523123123 * p;

        double result = nominator / denominator + sin;

        Console.WriteLine("{0:0.000000}", result);

    }
}

