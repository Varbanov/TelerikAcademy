using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class BankAccountDecl
{
        /*A bank account has a holder name (first name, middle name and last name), available amount of money (balance),
         * bank name, IBAN, BIC code and 3 credit card numbers associated with the account. Declare the variables needed
         * to keep the information for a single bank account using the appropriate data types and descriptive names.
         */
    static void Main()
    {
        string firstName = "Aa";
        string middleName = "Bb";
        string lastName = "Cc";
        string holderName = firstName + " " + middleName + " " + lastName;

        decimal moneyBalance = 2;
        string bankName = "BurkanBank";
        string ibanNum = "BGBUR123KAN";
        string bicNUm = "BURBGSF";
        string firstCardNum = "1111a";
        string secondCardNum = "2222b";
        string thirdCardNum = "3333c";

        Console.WriteLine("{0} has money ballance of {1} BGN in {2}, IBAN {3}, BIC {4}, Credit Card Numbers {5}; {6}; {7}", 
            holderName, moneyBalance, bankName, ibanNum, bicNUm, firstCardNum, secondCardNum, thirdCardNum);


    }
}

