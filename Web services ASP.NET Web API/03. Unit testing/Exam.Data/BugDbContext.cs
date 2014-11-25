namespace Exam.Data
{
    using Exam.Data.Migrations;
    using Exam.Models;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class BugDbContext : IdentityDbContext<ApplicationUser>
    {
        public BugDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static BugDbContext Create()
        {
            return new BugDbContext();
        }

        public IDbSet<Bug> Model1 { get; set; }
    }
}
