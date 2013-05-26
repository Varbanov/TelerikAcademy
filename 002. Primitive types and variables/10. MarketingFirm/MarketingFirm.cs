using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class MarketingFirm
{
  /* A marketing firm wants to keep record of its employees. Each record would have the following characteristics
  * – first name, family name, age, gender (m or f), ID number, unique employee number (27 560 000 to 27569999). 
  * Declare the variables needed to keep the information for a single employee using appropriate data types and descriptive names.
    */
    static void Main()
    {
        string firstName = "Nako";
        string familyName = "Nakov";
        byte age = 25;
        char gender = 'f';
        int idNum = 1234567;
        int employeeNum = 27569990;

        Console.WriteLine("Employee {0} {1}, gender {2} {3} years old, ID number {4}, employee number {5}",
            firstName, familyName, gender, age, idNum, employeeNum);
    }
}

