namespace _01.Students
{
    using System;

    public class Student :IComparable<Student>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Course { get; set; }

        public Student(string firstName, string lastName, string course)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Course = course;
        }

        public override string ToString()
        {
            return this.LastName + " " + this.FirstName+ " " + this.Course;
        }

        public int CompareTo(Student other)
        {

            if (this.LastName == other.LastName)
            {
                return this.FirstName.CompareTo(this.FirstName);
            }
            else
            {
                return this.LastName.CompareTo(other.LastName);
            }
        }
    }
}
