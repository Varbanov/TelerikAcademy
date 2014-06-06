namespace InheritanceAndPolymorphism
{
    using System;
    using System.Collections.Generic;

    public class CoursesExamples
    {
        public static void Main()
        {
            List<string> students = new List<string>() { "Peter", "Maria" };
            string lab = "Ultimate";

            LocalCourse localCourse = new LocalCourse("Databases", "Ivan Ivanov", students, lab);
            Console.WriteLine(localCourse);

            localCourse.Lab = "Enterprise";
            Console.WriteLine(localCourse);
            Console.WriteLine(localCourse);

            localCourse.TeacherName = "Svetlin Nakov";
            localCourse.Students.Add("Milena");
            localCourse.Students.Add("Todor");
            Console.WriteLine(localCourse);

            string town = "The town";
            OffsiteCourse offsiteCourse = new OffsiteCourse("PHP and WordPress Development", "Mario Peshev", new List<string>() { "Thomas", "Ani", "Steve" }, town);
            Console.WriteLine(offsiteCourse);
        }
    }
}
