using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Bank
{
    class Deposit : Account, IDepositable, IWithdrawable
    {
        //constructor
        public Deposit(Customer customer, decimal balance, decimal interestRate)
            : base(customer, balance, interestRate)
        {
        }

        //implement idepositable
        public void DepositAmount(decimal amount)
        {
            this.Balance += amount;
        }

        //implement iwithdrawable
        public void WithdrawAmount(decimal amount)
        {
            this.Balance -= amount;
        }

        //implement account
        public override decimal CalcInterest(int months)
        {
            if (months < 0)
            {
                throw new ArgumentException("The number of months must be positive!");
            }

            if (this.Balance > 0 && this.Balance < 1000)
            {
                return 0;
            }
            else
            {
                return months * this.InterestRate;
            }
        }
    }
}
