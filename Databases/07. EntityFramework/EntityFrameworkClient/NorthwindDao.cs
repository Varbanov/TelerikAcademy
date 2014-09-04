using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitytFramework.Data;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;

namespace EntityFrameworkClient
{
    public static class NorthwindDao
    {
        private static NorthwindEntities db = new NorthwindEntities();

        public static void InsertCustomer(string customerId, string companyName)
        {
            using (db)
            {
                if (db.Customers.Any(x => x.CustomerID == customerId))
                {
                    throw new ArgumentException("The customerId already exists!");
                }

                var customer = new Customer();
                customer.CustomerID = customerId;
                customer.CompanyName = companyName;
                db.Customers.Add(customer);
                db.SaveChanges();
                Console.WriteLine("Successfully added new customer!");
            }
        }

        public static void Modify(string customerId, string newCompanyName)
        {
            using (db)
            {
                var customer = db.Customers.Where(x => x.CustomerID == customerId).FirstOrDefault();
                if (customer != null)
                {
                    customer.CompanyName = newCompanyName;
                    db.SaveChanges();
                }
            }
        }

        public static void Delete(string customerId)
        {
            using (db)
            {
                var customer = db.Customers.Where(x => x.CustomerID == customerId).FirstOrDefault();
                if (customer != null)
                {
                    db.Customers.Remove(customer);
                    db.SaveChanges();
                }
            }
        }

        // task 3
        public static void FindCustomersByOrderYearAndCountry(int year, string country)
        {
            using (db)
            {
                var customers = db.Customers.Where(c => c.Orders.Any(o => o.OrderDate.Value.Year == year &&
                    o.ShipCountry.ToLower() == country.ToLower()));

                foreach (var customer in customers)
                {
                    Console.WriteLine(customer.CustomerID + " " + customer.CompanyName);
                }
            }
        }

        //task 4
        public static void FindCustomersByOrderYearAndCountryNativeSql(int year, string country)
        {
            using (db)
            {
                string query = "SELECT c.CustomerID, c.CompanyName FROM Customers c" +
                    "INNER JOIN Orders o ON o.CustomerID = c.CustomerID" +
                    "WHERE (YEAR(o.OrderDate) = {0} AND o.ShipCountry = {1})";
                object[] parameters = { year, country };
                var sqlResult = db.Database.SqlQuery<string>(query, parameters);

                foreach (var customer in sqlResult)
                {
                    Console.WriteLine(customer);
                }
            }
        }

        //task 5 (no sales table is available)
        public static void FindSalesByRegionAndPeriod(string region, DateTime start, DateTime end)
        {
            using (db)
            {
                var sales = db.Orders.Where(o => o.ShipRegion == region &&
                    (DateTime)o.OrderDate > start &&
                    (DateTime)o.OrderDate <= end)
                    .Select(x => new { x.OrderID, x.OrderDate });

                foreach (var sale in sales)
                {
                    Console.WriteLine("{0} {1}", sale.OrderID, sale.OrderDate);
                }
            }
        }

        //task 6
        public static void CloneDatabaseSchema()
        {
            string script = "USE Twin ";
            string generatedScript = ((IObjectContextAdapter)db).ObjectContext.CreateDatabaseScript();
            script += generatedScript;

            SqlConnection connection = new SqlConnection(
                @"Server=.\SQLEXPRESS; Database=master; Integrated Security=true");

            connection.Open();
            using (connection)
            {
                string query = "USE master; CREATE DATABASE Twin ";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                SqlCommand cloningCmd = new SqlCommand(script, connection);
                cloningCmd.ExecuteNonQuery();
            }
        }

        //task 7
        public static void TryConcurrentChanges()
        {
            var firstCustomerId = GetFirstCustomerId();
            NorthwindEntities dbFirst = new NorthwindEntities();
            NorthwindEntities dbSecond = new NorthwindEntities();

            using (dbFirst)
            {
                using (dbSecond)
                {
                    var customer = dbFirst.Customers.First(x => x.CustomerID == firstCustomerId);
                    if (customer != null)
                    {
                        customer.CompanyName = "edited db";
                    }

                    var secondCustomer = dbFirst.Customers.First(x => x.CustomerID == firstCustomerId);
                    if (customer != null)
                    {
                        customer.CompanyName = "edited db2";
                    }

                    dbFirst.SaveChanges();
                    dbSecond.SaveChanges();
                }
            }
        }

        private static string GetFirstCustomerId()
        {
            using (db)
            {
                var id = db.Customers.First().CustomerID;
                return id;
            }
        }

        //task 9
        public static void AddTransactionOrder()
        {
            using (db)
            {
                Order order = new Order();
                order.CustomerID = db.Customers.First().CustomerID;

                db.Orders.Add(order);
                db.SaveChanges();
                Console.WriteLine("Successfully added new order!");
            }
        }

        //task 10
        public static void GetTotalIncomeProcedure(int startYear, int endYear, string companyName)
        {

            using (db)
            {
                var income = db.usp_FindTotalIncome(startYear, endYear, companyName);
                Console.WriteLine("Total income is: {0}", income.FirstOrDefault());
            }
        }


    }
}
