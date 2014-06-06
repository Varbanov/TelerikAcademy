namespace Methods
{
    using System;

    public class Student
    {
        private DateTime birthDate;

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime BirthDate
        {
            get 
            {
                return this.birthDate; 
            }

            set
            {
                if (value.Year < 1920)
                {
                    throw new ArgumentException("The year of birth is invalid!");
                }

                this.birthDate = value;
            }
        }

        public string OtherInfo { get; set; }

        public bool IsOlderThan(Student other)
        {
            if (this.birthDate == null)
            {
                throw new ArgumentException("The birth date of the first student is not specified;");
            }

            if (this.birthDate == null)
            {
                throw new ArgumentException("The birth date of the second student is not specified;");
            }

            if (this.BirthDate <= other.BirthDate)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
