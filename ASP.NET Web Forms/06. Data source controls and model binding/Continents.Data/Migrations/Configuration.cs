namespace Continents.Data.Migrations
{
    using Continents.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ContinentsDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
            //this.ContextKey = "Continents.Data.ContinentsDbContext";
        }

        protected override void Seed(ContinentsDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            Town[] bulgarianTowns = new Town[] 
            {
                new Town("Sofia", 1500000),
                new Town("Plovdiv", 500000),
                new Town("Varna", 300000),
                new Town("Burgas", 150000),
                new Town("Stara Zagora", 1200000),
                new Town("Dobrich", 90000),
                new Town("Veliko Tarnovo", 70000),
                new Town("Blagoevgrad", 70000),
                new Town("Sredets", 15000),
                new Town("Bansko", 15000),
                new Town("Pleven", 30000),
            };

            Town[] germanTowns = new Town[] 
            {
                new Town("Berlin", 1500000),
                new Town("Frankfurt", 500000),
                new Town("Altenberg", 300000),
                new Town("Adenau", 150000),
                new Town("Ahrensburg", 1200000),
                new Town("Badenhausen", 90000),
                new Town("Baden-Baden", 70000),
                new Town("Creglingen", 70000),
                new Town("Dachau", 15000),
                new Town("Dorfen", 15000),
                new Town("Eberswalde", 30000),
            };

            Town[] austrianTowns = new Town[] 
            {
                new Town("Vienna", 1539848),
                new Town("Graz", 237810),
                new Town("Salzburg", 300000),
                new Town("Linz", 203044),
                new Town("Feldkirch", 26730),
                new Town("Wolfsberg", 90000),
                new Town("Eisenstadt", 70000),
                new Town("Schwaz", 70000),
                new Town("Knittelfeld", 15000),
                new Town("Bischofshofen", 15000),
                new Town("Neustadt", 30000),
            };

            Country[] europeanCountries = new Country[] 
            {
                new Country(bulgarianTowns) { Name="Bulgaria", Population = 6000000, Language="Bulgarian"},
                new Country(germanTowns) { Name="Germany", Population = 80000000, Language="German"},
                new Country(austrianTowns) { Name="Austria", Population = 8000000, Language="Austrian"},
            };



            context.Continents.Add(new Continent(europeanCountries) { Name="Europe" });

            context.Continents.Add(new Continent(new Country[] {new Country(new Town[] {new Town("Montreal", 10000000L)}) { Name="Canada", Language="Canadian", Population = 405034}}) { Name = "North America" });
            context.Continents.Add(new Continent(new Country[] { new Country(new Town[] { new Town("Zair", 600000L) }) { Name = "Democratic Republic Congo", Language="Kikongo", Population=34875436 } }) { Name = "Africa" });


            context.SaveChanges();



        }
    }
}
