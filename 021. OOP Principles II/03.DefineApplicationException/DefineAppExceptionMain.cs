using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace _03.DefineApplicationException
{
    class DefineAppExceptionMain
    {
        /* 03.Define a class InvalidRangeException<T> that holds information about an error condition 
         * related to invalid range. It should hold error message and a range definition [start … end].
         * Write a sample application that demonstrates the InvalidRangeException<int> and 
         * InvalidRangeException<DateTime> by entering numbers in the range [1..100] and 
         * dates in the range [1.1.1980 … 31.12.2013].
        */

        static void CauseInvalidRangeExceptionInt(int min, int max)
        {
            Console.WriteLine("Please enter a number outside the range [{0}..{1}]:", min, max);
            int num = int.Parse(Console.ReadLine());
            if (num < min || num > max)
            {
                throw new InvalidRangeException<int>("The number entered is not in range!", min, max);
            }
        }

        static void CauseInvalidRangeExceptionDateTime(DateTime min, DateTime max)
        {
            Console.WriteLine("Please enter a date in the format dd.mm.yy outside the range {0} and {1}.", min.Date.ToShortDateString(), max.Date.ToShortDateString());
            string str = Console.ReadLine();
            DateTime d = DateTime.ParseExact(str,"dd.MM.yyyy", CultureInfo.InvariantCulture);


            if (d < min || d > max)
            {
                throw new InvalidRangeException<DateTime>("The date entered is not in range!", min, max);
            }

        }

        static void Main()
        {
            try
            {
                //CauseInvalidRangeExceptionInt(1, 100);
                CauseInvalidRangeExceptionDateTime(new DateTime(1980, 1, 1), new DateTime(2013, 12, 31)); 
            }
            catch (InvalidRangeException<int> ir)
            {
                Console.WriteLine(ir.Message);
            }
            catch (InvalidRangeException<DateTime> ir)
            {
                Console.WriteLine(ir.Message);
            }
        }
    }
}
