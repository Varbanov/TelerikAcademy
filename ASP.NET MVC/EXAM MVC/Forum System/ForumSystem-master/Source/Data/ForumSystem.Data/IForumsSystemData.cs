namespace ForumSystem.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using ForumSystem.Data.Common.Repository;
    using ForumSystem.Data.Models;

    public interface IForumSystemData
    {
        IForumSystemDbContext Context { get; }

        IDeletableEntityRepository<Post> Posts { get; }

        IDeletableEntityRepository<Tag> Tags { get; }

        IRepository<User> Users { get; }

        IDeletableEntityRepository<Feedback> Feedbacks { get; }

        int SaveChanges();
    }
}