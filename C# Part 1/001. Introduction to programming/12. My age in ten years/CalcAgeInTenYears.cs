using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class CalcAgeInTenYears
{
    //* Write a program to read your age from the console and print how old you will be after 10 years.

    static void Main()
    {
        int age;
        do
        {
            Console.WriteLine("Please enter your age:");
        }
        while (!int.TryParse(Console.ReadLine(), out age));

        age += 10;
        Console.WriteLine("Ten years from now you will be {0} years old.", age);

    }
}

