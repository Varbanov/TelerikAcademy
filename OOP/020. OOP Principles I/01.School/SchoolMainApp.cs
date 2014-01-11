using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.School
{
    /*We are given a school. In the school there are classes of students. Each class has a set of teachers. 
     * Each teacher teaches a set of disciplines. Students have name and unique class number. Classes have
     * unique text identifier. Teachers have name. Disciplines have name, number of lectures and number of
     * exercises. Both teachers and students are people. Students, classes, teachers and disciplines could
     * have optional comments (free text block).
     * Your task is to identify the classes (in terms of  OOP) and their attributes and operations, encapsulate 
     * their fields, define the class hierarchy and create a class diagram with Visual Studio.
    */

    class SchoolMainApp
    {
        static void Main()
        {
            //instantiate class
            SchoolClass schoolClass = new SchoolClass("1234");
            //add students
            schoolClass.AddStudent(new Student("Mariana Dimitrova", "20"));
            schoolClass.AddStudent(new Student("Ivan Ivanov", "21"));
            schoolClass.AddStudent(new Student("Maria Ivanova", "22"));
            schoolClass.AddStudent(new Student("Dimitur Dimitrov", "23"));
            Console.WriteLine("--------------------------------");
            //add teachers
            Teacher one = new Teacher("Ms Ivanova");
            one.AddDiscipline(new Discipline("Biology", 30, 30));
            Teacher two = new Teacher("Ms Dimitrova");
            two.AddDiscipline(new Discipline("Geography", 30, 30));
            two.AddDiscipline(new Discipline("History", 30, 20));
            schoolClass.AddTeacher(one);
            schoolClass.AddTeacher(two);
            schoolClass.AddTeacher(one);
            Console.WriteLine("--------------------------");

            Console.WriteLine("------------------------");
            schoolClass.PrintStudents();
            Console.WriteLine("-----------------");
            schoolClass.PrintTeachers();
            Console.WriteLine("------------------");
            schoolClass.AddComment("comment");
            schoolClass.AddComment("second comment");
            Console.WriteLine("Comments of the class:");
            schoolClass.ViewComments();
        }
    }
}
