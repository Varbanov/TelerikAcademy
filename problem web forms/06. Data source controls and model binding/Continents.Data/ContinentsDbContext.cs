using Continents.Data.Migrations;
using Continents.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Continents.Data
{
    public class ContinentsDbContext : DbContext
    {
        public ContinentsDbContext()
            : base("Continents")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ContinentsDbContext, Configuration>());
            //Database.SetInitializer(new DropCreateDatabaseAlways<ContinentsDbContext>());
        }


        public IDbSet<Continent> Continents { get; set; }
        public IDbSet<Country> Countries { get; set; }
        public IDbSet<Town> Towns{ get; set; }
    }
}
