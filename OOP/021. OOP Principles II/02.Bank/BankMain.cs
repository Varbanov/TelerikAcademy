using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Bank
{
    class BankMain
    {
        /* 02. A bank holds different types of accounts for its customers: deposit accounts, 
         * loan accounts and mortgage accounts. Customers could be individuals or companies.
         * All accounts have customer, balance and interest rate (monthly based). Deposit 
         * accounts are allowed to deposit and withdraw money. Loan and mortgage accounts 
         * can only deposit money.
         * All accounts can calculate their interest amount for a given period (in months).
         * In the common case its is calculated as follows: number_of_months * interest_rate.
         * Loan accounts have no interest for the first 3 months if are held by individuals 
         * and for the first 2 months if are held by a company.
         * Deposit accounts have no interest if their balance is positive and less than 1000.
         * Mortgage accounts have ½ interest for the first 12 months for companies and no 
         * interest for the first 6 months for individuals.
         * Your task is to write a program to model the bank system by classes and interfaces.
         * You should identify the classes, interfaces, base classes and abstract actions and 
         * implement the calculation of the interest functionality through overridden methods.
        */

        static void Main()
        {
            Console.WriteLine("To easily check the hierarchy, \nplease just have a look at the BankClassDiagram \nfile included in the project. ;)\n");

            Individual ind = new Individual("Simona", "bgsi01", 23, Gender.female);
            Company com = new Company("X OOD", "12345", new Individual("Ivan Ivanov", "i1516", 45, Gender.male));
            Mortgage m1 = new Mortgage(ind, 1000, 5);
            Mortgage m2 = new Mortgage(com, 1000, 5);

            Console.WriteLine("Mortgage interest for individual for 5 months: {0}", m1.CalcInterest(5));
            Console.WriteLine("Mortgage interest for company for 5 months: {0}", m2.CalcInterest(5));




        }
    }
}
