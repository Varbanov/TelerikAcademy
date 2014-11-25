namespace ForumSystem.Data.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using ForumSystem.Common;
    using ForumSystem.Data.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    internal sealed class Configuration : DbMigrationsConfiguration<ForumSystemDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.RandomGenerator = new RandomGenerator();

            // TODO: Remove in production
            this.AutomaticMigrationDataLossAllowed = true;
        }

        public RandomGenerator RandomGenerator { get; set; }

        protected override void Seed(ForumSystemDbContext context)
        {
            if (context.Posts.Any())
            {
                return;
            }

            for (int i = 0; i < 10; i++)
            {
                var user = this.SeedUser(context);
                var threeTags = this.SeedThreeTags(context);

                var post = new Post()
                {
                    Author = user,
                    Content = "content " + this.RandomGenerator.GetRandomString(5, 20),
                    CreatedOn = DateTime.Now,
                    Title = "title " + this.RandomGenerator.GetRandomString(5, 20),
                    Tags = threeTags,
                };

                context.Posts.Add(post);
                context.SaveChanges();

                foreach (var tag in threeTags)
                {
                    tag.Posts.Add(post);
                }
            }
        }

        private System.Collections.Generic.ICollection<Tag> SeedThreeTags(ForumSystemDbContext context)
        {
            List<Tag> tags = new List<Tag>();

            for (int i = 0; i < 3; i++)
            {
                var tag = new Tag()
                {
                    Name = this.RandomGenerator.GetRandomStringExact(5),
                    CreatedOn = DateTime.Now,
                };

                context.Tags.Add(tag);
                tags.Add(tag);
            }

            context.SaveChanges();
            return tags;
        }

        private User SeedUser(ForumSystemDbContext context)
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            var userManager = new UserManager<User>(new UserStore<User>(context));

            userManager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 2,
                RequireNonLetterOrDigit = false,
                RequireDigit = false,
                RequireLowercase = false,
                RequireUppercase = false,
            };

            var userName = this.RandomGenerator.GetRandomString(2, 10) + "@forumsystem.com";

            var user = new User { UserName = userName, Email = userName };
            userManager.Create(user, "qq");
            return user;
        }
    }
}
