using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentSystem.Data;
using System.Diagnostics;

namespace TelerikAcademyConsoleClient
{
    class TelerikAcademyMain
    {


        static void Main()
        {
            TelerikAcademyEntities dbContext = new TelerikAcademyEntities();
            using (dbContext)
            {
                Stopwatch sw = new Stopwatch();
                sw.Start();
                //GetInfoWithInclude(dbContext);
                sw.Stop();
                var withInclude = sw.Elapsed;
                sw.Reset();

                sw.Start();
                GetInfoWithoutInclude(dbContext);
                sw.Stop();
                var withoutInclude = sw.Elapsed;
                Console.WriteLine("Elapsed time with include: " + withInclude);
                Console.WriteLine("Elapsed time without include: " + withoutInclude);

                //using the SQL Server Profiler for SQL Management Studio 2014:
                //with include - 1
                //without include - there are tens of queries in the profiler log
            }
        }

        static void GetInfoWithoutInclude(TelerikAcademyEntities dbContext)
        {
            foreach (var employee in dbContext.Employees)
            {
                Console.WriteLine("{0} {1}", employee.FirstName, employee.LastName);
                Console.WriteLine("{0}", employee.Department.Name);
                Console.WriteLine("{0}", employee.Address.Town.Name);
                Console.WriteLine();
            }
        }

        static void GetInfoWithInclude(TelerikAcademyEntities dbContext)
        {
            foreach (var employee in dbContext.Employees.Include("Address.Town").Include("Department"))
            {
                Console.WriteLine("{0} {1}", employee.FirstName, employee.LastName);
                Console.WriteLine("{0}", employee.Department.Name);
                Console.WriteLine("{0}", employee.Address.Town.Name);
                Console.WriteLine();
            }
        }


    }
}
