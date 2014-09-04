using System;
using System.Linq;
using Telerik.OpenAccess;
using DataAccessModel2;


namespace QuickStartBootstrapper
{
    class Program
    {
        static void Main(string[] args)
        {
            UpdateDatabase();

            using (var ctx = new FluentModel())
            {
                var pesho = new Stefan() { Name = "stefannnn" };
                ctx.Add(pesho);
                ctx.Delete(pesho);
                ctx.SaveChanges();

            }

            Console.Write("Database update complete! Press any key to close.");
            Console.ReadKey();
        }
        private static void UpdateDatabase()
        {
            using (var context = new DataAccessModel2.FluentModel())
            {
                var schemaHandler = context.GetSchemaHandler();
                EnsureDB(schemaHandler);
            }
        }
        private static void EnsureDB(ISchemaHandler schemaHandler)
        {
            string script = null;
            if (schemaHandler.DatabaseExists())
            {
                script = schemaHandler.CreateUpdateDDLScript(null);
            }
            else
            {
                schemaHandler.CreateDatabase();
                script = schemaHandler.CreateDDLScript();
            }
            if (!string.IsNullOrEmpty(script))
            {
                schemaHandler.ExecuteDDLScript(script);
            }
        }
    }
}