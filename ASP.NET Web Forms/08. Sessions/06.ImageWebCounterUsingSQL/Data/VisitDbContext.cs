using _06.ImageWebCounterUsingSQL.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace _06.ImageWebCounterUsingSQL.Data
{
    public class VisitDbContext : DbContext
    {
        public VisitDbContext()
            : base("Visits")
        {
        }

        public IDbSet<Visit> Visits { get; set; }
    }
}