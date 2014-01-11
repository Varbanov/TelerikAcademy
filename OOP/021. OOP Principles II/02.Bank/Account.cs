using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Bank
{
    abstract class Account
    {
        //fields
        public Customer Customer {get; private set;}
        private decimal balance;
        private decimal interestRate;

        //properties
        public virtual decimal Balance
        {
            get { return balance; }
            set { balance = value; }
        }

        public decimal InterestRate
        {
            get { return interestRate; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Interest rate must be greater or equal to 0.");
                else
                    interestRate = value;
            }
        }

        //constructor
        public Account(Customer customer, decimal balance, decimal interestRate)
        {
            this.Customer = customer;
            this.Balance = balance;
            this.InterestRate = interestRate;
        }

        public abstract decimal CalcInterest(int months);

    }
}
