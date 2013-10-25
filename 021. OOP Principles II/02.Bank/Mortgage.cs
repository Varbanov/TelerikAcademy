using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Bank
{
    class Mortgage : Account, IDepositable
    {

        //constructor
        public Mortgage(Customer customer, decimal balance, decimal interestRate) 
            : base(customer, balance, interestRate)
        {
        }

        //implement idepositable
        public void DepositAmount(decimal amount)
        {
            //the more you deposit, the less the mortgage loan
            this.Balance -= amount;
        }

        //implement account
        public override decimal CalcInterest(int months)
        {
            if (months < 0)
            {
                throw new ArgumentException("The number of months must be positive!");
            }

            if (this.Customer is Company)
            {
                if (months > 12)
                {
                    return ((months - 12) * this.InterestRate) + ((12 * this.InterestRate) / 2);
                }
                else
                {
                    return (months * this.InterestRate) / 2;
                }
            }
            else if (months - 6 > 0)
            {
                return (months - 6) * this.InterestRate;
            }
            else
            {
                return 0;
            }
        }
    }
}
