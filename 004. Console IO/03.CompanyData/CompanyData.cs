using System;

class CompanyData
{
    /*A company has name, address, phone number, fax number, web site and manager. The manager
     * has first name, last name, age and a phone number. Write a program that reads the information 
     * about a company and its manager and prints them on the console.
    */
    static void Main()
    {
        //declare variables
        string nameCmp, addressCmp, phoneCmpNum, faxCmpNum, webSite, firstNameMngr, familyNameMngr, phoneMngrNum;
        byte age;

        //input
        Console.Write("Please enter the company name:");
        nameCmp = Console.ReadLine();
        Console.Write("Please enter the company address:");
        addressCmp = Console.ReadLine();
        Console.Write("Please enter the company phone number:");
        phoneCmpNum = Console.ReadLine();
        Console.Write("Please enter the company fax number:");
        faxCmpNum = Console.ReadLine();
        Console.Write("Please enter the company website:");
        webSite = Console.ReadLine();
        Console.Write("Please enter the manager's first name:");
        firstNameMngr = Console.ReadLine();
        Console.Write("Please enter the manager's family name:");
        familyNameMngr = Console.ReadLine();
        Console.Write("Please enter the manager's age:");
        age = byte.Parse(Console.ReadLine());
        Console.Write("Please enter the manager's phone number");
        phoneMngrNum = Console.ReadLine();

        //output
        Console.WriteLine("Company: {0}\nAddress: {1}\nTelephone: {2}\nFax: {3}\nWebsite: {4}\nManager: {5} {6}\nAge: {7}\nPhone number: {8}",
            nameCmp, addressCmp, phoneCmpNum, faxCmpNum, webSite, firstNameMngr, familyNameMngr, age, phoneMngrNum);




    }
}

