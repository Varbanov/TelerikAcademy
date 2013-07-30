using System;

class SubstractTwoPolynomials
{
    //Write a method that adds two polynomials. Represent them as arrays of their coefficients as in the example below:
    //x^2 + 5 = 1x^2 + 0x + 5 = {5,0,1}
    static int[] SubstractPolynomials(int[] p1, int[] p2)
    {
        //check which polynomial is shorter
        bool firstIsShorter = p1.Length < p2.Length;
        int shorterLength, longerLength;
        if (firstIsShorter)
        {
            shorterLength = p1.Length;
            longerLength = p2.Length;
        }
        else
        {
            shorterLength = p2.Length;
            longerLength = p1.Length;
        }

        //sum coefficients to the most senior one of the shorter polynomial
        int[] sum = new int[longerLength];
        for (int i = 0; i < shorterLength; i++)
        {
            sum[i] = p1[i] - p2[i];
        }
        //add the rest of the coefficients of the longer polynomial
        for (int i = shorterLength; i < longerLength; i++)
        {
            if (firstIsShorter)
            {
                sum[i] = - p2[i];
            }
            else
            {
                sum[i] = p1[i];
            }
        }
        return sum;
    }

    static int[] MultiplyPolinomial(int[] p1, int[] p2)
    {
        int[] result = new int[p1.Length + p2.Length];
        //declare zeros at result polinom
        for (int i = 0; i < result.Length; i++)
        {
            result[i] = 0;
        }

        for (int i = 0; i < p1.Length; i++)
        {
            for (int j = 0; j < p2.Length; j++)
            {
                int index = i + j;
                result[index] += (p1[i] * p2[j]);
            }
        }
        return result;
    }


    static void PrintPolynomial(int[] arr)
    {
        for (int i = arr.Length - 1; i >= 0; i--)
        {
            if (arr[i] > 0 && i > 0 && i < arr.Length - 1)
                Console.Write("+ ");
            if (i == arr.Length - 1 && arr[i] == -1)
                Console.Write("-");

            if (i == 0 && arr[i] > 0)
            {
                Console.Write(" + ");
                if (arr[i] == 1)
                    Console.Write("{0}", arr[i]);
            }

            if (i == 0 && arr[i] < 0)
            {
                Console.Write(" ");
            }

            if (arr[i] > 1 || arr[i] < -1)
                Console.Write("{0}", arr[i]);
            if (i == 1 && arr[i] <= -1)
                Console.Write("- x");

            if (i > 1)
                Console.Write("x^{0} ", i);
            else if (i == 1 && arr[i] > 0)
                Console.Write("x");

        }


        Console.WriteLine();
    }

    static void Main()
    {
        //x^2 + 5
        int[] p1 = { 5, 0, 1 };
        //x^3 + 3x^2 + x + 1
        int[] p2 = { 1, 1, 3, 1 };
        int[] sum = SubstractPolynomials(p1, p2);

        PrintPolynomial(p1);
        Console.WriteLine("   -  ");
        PrintPolynomial(p2);
        Console.WriteLine("   =  ");
        PrintPolynomial(sum);
        Console.WriteLine();
        Console.WriteLine();

        int[] mult = MultiplyPolinomial(p1, p2);
        PrintPolynomial(p1);
        Console.WriteLine("   *  ");
        PrintPolynomial(p2);
        Console.WriteLine("   =  ");
        PrintPolynomial(mult);

    }
}
