﻿namespace ForumSystem.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using ForumSystem.Data.Common.Models;
    using ForumSystem.Data.Migrations;
    using ForumSystem.Data.Models;
    using Microsoft.AspNet.Identity.EntityFramework;
  
    public class ForumSystemDbContext : IdentityDbContext<User>, IForumSystemDbContext
    {
        public ForumSystemDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ForumSystemDbContext, Configuration>());
        }

        public IDbSet<Tag> Tags { get; set; }

        public IDbSet<Post> Posts { get; set; }

        public IDbSet<Feedback> Feedbacks { get; set; }

        public static ForumSystemDbContext Create()
        {
            return new ForumSystemDbContext();
        }

        public override int SaveChanges()
        {
            this.ApplyAuditInfoRules();
            return base.SaveChanges();
        }

        public new IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }

        private void ApplyAuditInfoRules()
        {
            // Approach via @julielerman: http://bit.ly/123661P
            foreach (var entry in
                this.ChangeTracker.Entries()
                    .Where(
                        e =>
                        e.Entity is IAuditInfo && ((e.State == EntityState.Added) || (e.State == EntityState.Modified))))
            {
                var entity = (IAuditInfo)entry.Entity;

                if (entry.State == EntityState.Added)
                {
                    if (!entity.PreserveCreatedOn)
                    {
                        entity.CreatedOn = DateTime.Now;
                    }
                }
                else
                {
                    entity.ModifiedOn = DateTime.Now;
                }
            }
        }
    }
}
