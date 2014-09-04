using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitytFramework.Data;

namespace EntityFrameworkClient
{
    class NorthwindEntryPoint
    {
        static void Main()
        {
            NorthwindEntities db = new NorthwindEntities();

            //using (db)
            //{
            //    foreach (var customer in db.Customers)
            //    {
            //        Console.WriteLine(customer.Country);
            //    } 
            //}

            //NorthwindDao.CloneDatabaseSchema();
            // NorthwindDao.FindCustomersByOrderYearAndCountry(5, "fas");
            //NorthwindDao.TryConcurrentChanges();
            //NorthwindDao.AddTransactionOrder();
            //NorthwindDao.GetTotalIncomeProcedure(2000, 2010, db.Suppliers.First().CompanyName);

        }
    }
}
