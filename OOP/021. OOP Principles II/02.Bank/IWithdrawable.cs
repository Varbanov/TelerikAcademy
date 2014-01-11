using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Bank
{
    interface IWithdrawable
    {
        void WithdrawAmount(decimal amount);
    }
}
