using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Bank
{
    class Loan : Account, IDepositable
    {
        //constructor
        public Loan(Customer customer, decimal balance, decimal interestRate)
            : base(customer, balance, interestRate)
        {
        }

        //implement idepositable
        public void DepositAmount(decimal amount)
        {
            //the more you deposit, the less the loan
            this.Balance -= amount;
        }

        //implement account
        public override decimal CalcInterest(int months)
        {
            if (months < 0)
            {
                throw new ArgumentException("The number of months must be positive!");
            }

            if (this.Customer is Company && months - 3 > 0)
            {
                return (months - 3) * this.InterestRate;
            }
            else if (months - 2 > 0)
            {
                return (months - 2) * this.InterestRate;
            }
            else
            {
                return 0;
            }
        }
    }
}
