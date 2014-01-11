using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.CTSMain
{
    class Student : ICloneable, IComparable<Student>
    {
        /*Define a class Student, which contains data about a student – first, middle and last name, SSN, permanent
         *address, mobile phone e-mail, course, specialty, university, faculty. Use an enumeration for the specialties, 
         *universities and faculties. Override the standard methods, inherited by  System.Object: Equals(), ToString(), 
         *GetHashCode() and operators == and !=.
        */

        //fields
        public string FirstName { get; private set; }
        public string MiddleName { get; private set; }
        public string LastName { get; private set; }
        public string SSN { get; private set; }
        public string Address { get; set; }
        public string MobilePhone { get; set; }
        public string E_mail { get; set; }
        public int Course { get; set; }
        public Specialty Specialty { get; set; }
        public University University { get; set; }
        public Faculty Faculty { get; set; }

        //constructors
        public Student(string firstName, string middleName, string lastName, string ssn, Specialty specialty, University uni, Faculty faculty)
        {
            this.FirstName = firstName;
            this.MiddleName = middleName;
            this.LastName = lastName;
            this.SSN = ssn;
            this.Specialty = specialty;
            this.University = uni;
            this.Faculty = faculty;
        }

        //Equals() overriden to compare students by SSN
        public override bool Equals(object obj)
        {
            if (!(obj is Student))
            {
                //also, if obj is null, false will be returned
                return false;
            }

            Student student = obj as Student;

            //using the static method ensures no nullref exception will be thrown
            if (!Object.Equals(this.SSN, student.SSN))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        //GetHashCode() overriden
        public override int GetHashCode()
        {
            return this.SSN.GetHashCode() ^ this.LastName.GetHashCode() ^ this.MobilePhone.GetHashCode();
        }

        //operators overriden
        public static bool operator ==(Student first, Student second)
        {
            return Student.Equals(first, second);

        }

        public static bool operator !=(Student first, Student second)
        {
            return !(first.Equals(second));
        }

        //ToString overriden
        public override string ToString()
        {
            StringBuilder res = new StringBuilder();
            res.Append(this.FirstName);
            res.Append("\n");
            res.Append(this.LastName);
            res.Append(String.Format("\nSSN: {0}", this.SSN));
            res.Append(String.Format("\nAddress: {0}", this.Address));
            res.Append(String.Format("\nMobile phone: {0}", this.MobilePhone));
            res.Append(String.Format("\nE-mail: {0}", this.E_mail));
            res.Append(String.Format("\nCourse: {0}", this.Course));
            res.Append(String.Format("\nSpecialty: {0}", this.Specialty));
            res.Append(String.Format("\nFaculty: {0}", this.Faculty));
            res.Append(String.Format("\nUniversity: {0}", this.University));
            return res.ToString();
        }

        //ICloneable implementation
        object ICloneable.Clone()
        {
            return this.Clone();
        }

        public Student Clone()
        {
            Student res = new Student(this.FirstName, this.MiddleName, this.LastName, this.SSN, this.Specialty, this.University, this.Faculty);
            res.Address = this.Address;
            res.MobilePhone = this.MobilePhone;
            res.E_mail = this.E_mail;
            res.Course = this.Course;
            return res;
        }

        //IComparable implementation by names and ssn
        public int CompareTo(Student otherS)
        {
            if (this.FirstName != otherS.FirstName)
            {
                return this.FirstName.CompareTo(otherS.FirstName);
            }
            else if (this.MiddleName != otherS.MiddleName)
            {
                return this.MiddleName.CompareTo(otherS.MiddleName);
            }
            else if (this.LastName != otherS.LastName)
            {
                return this.LastName.CompareTo(otherS.LastName);
            }
            else if (this.SSN != otherS.SSN)
            {
                return this.SSN.CompareTo(otherS.SSN);
            }
            else return 0;
        }
    }
}
