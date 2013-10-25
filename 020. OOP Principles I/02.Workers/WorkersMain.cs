using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Workers
{
    class WorkersMain
    {
        /*Define abstract class Human with first name and last name. Define new class Student which is 
         * derived from Human and has new field – grade. Define class Worker derived from Human with new 
         * property WeekSalary and WorkHoursPerDay and method MoneyPerHour() that returns money earned by
         * hour by the worker. Define the proper constructors and properties for this hierarchy. 
         * Initialize a list of 10 students and sort them by grade in ascending order (use LINQ or OrderBy()
         * extension method). Initialize a list of 10 workers and sort them by money per hour in descending order.
         * Merge the lists and sort them by first name and last name.
         */

        static List<Student> InitializeStudents()
        {
            List<Student> students = new List<Student>();
            int grade = 12;

            for (int i = 0; i < 10; i++)
            {
                string first = "Ivan" + i;
                string last = "Ivanov" + i;

                students.Add(new Student(first, last, grade));
                grade--;
            }

            return students;
        }

        static List<Worker> InitializeWorkers()
        {
            List<Worker> workers = new List<Worker>();
            decimal weekSalary = 200;
            int workHours = 4;

            for (int i = 0; i < 10; i++)
            {
                string first = "Ivan" + i;
                string last = "Ivanov" + i;
                workers.Add(new Worker(first, last, weekSalary, workHours));
                weekSalary += 100;
                workHours++;
            }

            return workers;
        }

        static void PrintStudents(IEnumerable<Student> students)
        {
            Console.WriteLine("Students:");
            foreach (var s in students)
            {
                Console.WriteLine("{0} {1} - {2}", s.FirstName, s.LastName, s.Grade);
            }

            Console.WriteLine("--------------");
        }

        static void PrintWorkers(IEnumerable<Worker> workers)
        {
            Console.WriteLine("Workers:");
            foreach (var w in workers)
            {
                Console.WriteLine("{0} {1} - Salary: {2}, Hours: {3}, Pay: {4:0.00}", w.FirstName, w.LastName, w.WeekSallary, w.WorkHoursPerDay, w.MoneyPerHour());
            }

            Console.WriteLine("--------------");
        }

        static IEnumerable<Human> SortHumansByName(List<Human> humans)
        {
            var sortedHumans =
                from h in humans
                orderby h.FirstName, h.LastName
                select h;

            return sortedHumans;
        }

        static void PrintHumansNames(IEnumerable<Human> humans)
        {
            foreach (var human in humans)
            {
                Console.WriteLine("{0} {1}", human.FirstName, human.LastName);
            }
        }

        static void Main()
        {
            List<Student> students = InitializeStudents();
            List<Worker> workers = InitializeWorkers();
            //print students
            PrintStudents(students);

            //sort students by grade and print them again
            var sorted = students.OrderBy(s => s.Grade);
            PrintStudents(sorted);

            //print workers
            PrintWorkers(workers);

            //sort workers by money per hour and print them again
            var sortedWorkers = workers.OrderByDescending(w => w.MoneyPerHour());
            PrintWorkers(sortedWorkers);

            //merge and sort
            List<Human> humans = new List<Human>();
            foreach (var s in students)
            {
                humans.Add(s);
            }
            foreach (var w in workers)
            {
                humans.Add(w);
            }

            var sortedHumans = SortHumansByName(humans);
            PrintHumansNames(sortedHumans);
        }
    }
}
