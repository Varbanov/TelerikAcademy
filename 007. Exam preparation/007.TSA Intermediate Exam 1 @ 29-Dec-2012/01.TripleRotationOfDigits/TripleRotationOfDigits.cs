using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class TripleRotationOfDigits
{
    static int Rotation(int n)
    {
        string num = n.ToString();
        string last = num[num.Length - 1].ToString();

        StringBuilder res = new StringBuilder();

        res.Append(last);
        for (int i = 0; i < num.Length - 1; i++)
        {
            res.Append(num[i].ToString());
        }

        int result = int.Parse(res.ToString());
        return result;
    }

    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        n = Rotation(n);
        n = Rotation(n);
        n = Rotation(n);

        Console.WriteLine(n);
    }
}

