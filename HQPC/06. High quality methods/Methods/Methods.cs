namespace Methods
{
    using System;

    public class Methods
    {
        public static double CalcTriangleArea(double firstSide, double secondSide, double thirdSide)
        {
            if (firstSide <= 0 || secondSide <= 0 || thirdSide <= 0)
            {
                throw new ArgumentException("The sides must be positive numbers!");
            }

            if (firstSide >= secondSide + thirdSide || secondSide >= firstSide + thirdSide || thirdSide >= firstSide + secondSide)
            {
                throw new ArgumentException("Each side must be smaller than the sum of the other two!");
            }

            checked
            {
                double halfPerimeter = (firstSide + secondSide + thirdSide) / 2;
                double area = Math.Sqrt(halfPerimeter * (halfPerimeter - firstSide) * (halfPerimeter - secondSide) * (halfPerimeter - thirdSide));
                return area;
            }
        }

        public static string NumberToDigit(int number)
        {
            switch (number)
            {
                case 0: return "zero";
                case 1: return "one";
                case 2: return "two";
                case 3: return "three";
                case 4: return "four";
                case 5: return "five";
                case 6: return "six";
                case 7: return "seven";
                case 8: return "eight";
                case 9: return "nine";
                default: throw new ArgumentException("Invalid number!");
            }
        }

        public static int FindMax(params int[] elements)
        {
            if (elements == null || elements.Length == 0)
            {
                throw new ArgumentException("The elements array is either null or empty!");
            }

            int max = elements[0];
            for (int i = 1; i < elements.Length; i++)
            {
                if (elements[i] > max)
                {
                    max = elements[i];
                }
            }

            return max;
        }

        public static void PrintAsNumber(object number, string format)
        {
            decimal n;
            bool isNumber = decimal.TryParse(number.ToString(), out n);
            if (!isNumber)
            {
                throw new ArgumentException("The number is invalid!");
            }

            if (format == "f")
            {
                Console.WriteLine("{0:f2}", number);
            }
            else if (format == "%")
            {
                Console.WriteLine("{0:p0}", number);
            }
            else if (format == "r")
            {
                Console.WriteLine("{0,8}", number);
            }
            else
            {
                throw new ArgumentException("Invalid format! The format string can be \"f\",\"%\" or \"r\"!");
            }
        }

        public static double CalcDistance(double x1, double y1, double x2, double y2)
        {
            checked
            {
                double distance = Math.Sqrt(((x2 - x1) * (x2 - x1)) + ((y2 - y1) * (y2 - y1)));
                return distance;
            }
        }

        public static bool CheckIfHorizontal(double y1, double y2)
        {
            return y1 == y2;
        }

        public static bool CheckIfVertical(double x1, double x2)
        {
            return x1 == x2;
        }

        public static void Main()
        {
            var triangleArea = CalcTriangleArea(3, 4, 5);
            Console.WriteLine(triangleArea);

            var number = NumberToDigit(5);
            Console.WriteLine(number);

            var max = FindMax(5, -1, 3, 2, 14, 2, 3);
            Console.WriteLine(max);

            PrintAsNumber(1.3, "f");
            PrintAsNumber(0.75, "%");
            PrintAsNumber(2.30, "r");

            bool horizontal = CheckIfHorizontal(3, 3);
            bool vertical = CheckIfVertical(-1, -2.5);
            var distance = CalcDistance(3, -1, 3, 2.5);
            Console.WriteLine(distance);
            Console.WriteLine("Horizontal? " + horizontal);
            Console.WriteLine("Vertical? " + vertical);

            Student peter = new Student() { FirstName = "Peter", LastName = "Ivanov", BirthDate = new DateTime(1992, 3, 17) };
            peter.OtherInfo = "From Sofia";

            Student stella = new Student() { FirstName = "Stella", LastName = "Markova", BirthDate = new DateTime(1993, 11, 3) };
            stella.OtherInfo = "From Vidin, gamer, high results";

            Console.WriteLine("{0} older than {1} -> {2}", peter.FirstName, stella.FirstName, peter.IsOlderThan(stella));
        }
    }
}
