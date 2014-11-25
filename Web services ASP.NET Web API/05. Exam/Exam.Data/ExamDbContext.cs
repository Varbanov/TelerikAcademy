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

    public class ExamDbContext : IdentityDbContext<User>
    {
        public ExamDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ExamDbContext, Configuration>());
        }

        public static ExamDbContext Create()
        {
            return new ExamDbContext();
        }

        public IDbSet<Notification> Notifications { get; set; }
        public IDbSet<Game> Games { get; set; }
        public IDbSet<Model3> Model3 { get; set; }
        public IDbSet<Model4> Model4 { get; set; }
        public IDbSet<Model5> Model5 { get; set; }

        // TODO maybe remove this 
        //public new void SaveChanges()
        //{
        //    base.SaveChanges();
        //}
    }
}
