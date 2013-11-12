using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.CTSMain
{
    class StudentMain
    {
        /*Define a class Student, which contains data about a student – first, middle and last name, SSN, permanent
         *address, mobile phone e-mail, course, specialty, university, faculty. Use an enumeration for the specialties, 
         *universities and faculties. Override the standard methods, inherited by  System.Object: Equals(), ToString(), 
         *GetHashCode() and operators == and !=.
        */

        static void Main()
        {
            //initialize students
            Student s = new Student("Ivan", "Ivanov", "Ivanov", "1713218", Specialty.Mathematics, University.SofiaUni, Faculty.FMI);
            Student p = new Student("Ivan", "Ivanov", "Ivanov", "713218", Specialty.Mathematics, University.SofiaUni, Faculty.FMI);
            s.Address = "sss";
            s.E_mail = "smail";

            //test Equals()
            Console.WriteLine(p);
            Console.WriteLine();
            Console.WriteLine(s);
            Console.WriteLine();
            Console.WriteLine(s.Equals(p));
            Console.WriteLine();

            //test Clone()
            Student k = s.Clone();
            k.Faculty = Faculty.FE;
            k.Address = "kkkkk";
            k.E_mail = "kmail";
            Console.WriteLine(k.ToString());
            
            //test CompareTo()
            Console.WriteLine("\nCompareTo:");
            Student c = new Student("Ivan", "Ivanov", "Ivanov", "13218", Specialty.Mathematics, University.SofiaUni, Faculty.FMI);
            Console.WriteLine(c.CompareTo(k));
        }
    }
}
