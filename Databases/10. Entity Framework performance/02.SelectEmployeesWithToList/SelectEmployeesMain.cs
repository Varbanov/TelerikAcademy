namespace _02.SelectEmployeesWithToList
{
    using StudentSystem.Data;
    using System;
    using System.Diagnostics;
    using System.Linq;

    class SelectEmployeesMain
    {
        static void Main()
        {
            var dbContext = new TelerikAcademyEntities();
            var sw = new Stopwatch();

            sw.Start();
            var allEmployees = dbContext.Employees.ToList()
                                      .Select(e => e.Address).ToList()
                                      .Select(e => e.Town).ToList()
                                      .Where(e => e.Name == "Sofia");
            sw.Stop();
            var withTolist = sw.Elapsed;
            sw.Reset();

            sw.Start();
            var allEmployeesOptimized = dbContext.Employees
                                               .Select(e => e.Address)
                                               .Select(e => e.Town)
                                               .Where(e => e.Name == "Sofia").ToList();
            sw.Stop();
            var withoutToList = sw.Elapsed;
            Console.WriteLine("Elapsed time with ToList: " + withTolist);
            Console.WriteLine("Elapsed time without ToList: " + withoutToList);
        }
    }
}
