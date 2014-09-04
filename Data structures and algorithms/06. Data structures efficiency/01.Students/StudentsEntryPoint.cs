namespace _01.Students
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using Wintellect.PowerCollections;

    public class StudentsEntryPoint
    {
        private const string PATH = @"..\..\students.txt";

        public static SortedDictionary<string, OrderedBag<Student>> ReadStudents(string path)
        {
            var result = new SortedDictionary<string, OrderedBag<Student>>();

            using (var reader = new StreamReader("students.txt"))
            {
                var currentLine = reader.ReadLine();

                while (currentLine != null)
                {
                    var tokens = currentLine.Split(new char[] { ' ', '|', }, StringSplitOptions.RemoveEmptyEntries);
                    var course = tokens[2].Trim();
                    Student student = new Student(tokens[0].Trim(), tokens[1].Trim(), course);
                    
                    if (result.ContainsKey(course))
                    {
                        result[course].Add(student);
                    }
                    else
                    {
                        result[course] = new OrderedBag<Student>();
                        result[course].Add(student);
                    }

                    currentLine = reader.ReadLine();
                }

                return result;
            }


           // return result;
        }

        static void Main()
        {
            var students = ReadStudents(PATH);
            foreach (var course in students)
            {
                Console.WriteLine("COURSE " + course.Key);
                Console.WriteLine();
                foreach (var student in course.Value)
                {
                    Console.WriteLine(student);
                }

                Console.WriteLine();
            }

        }
    }
}
