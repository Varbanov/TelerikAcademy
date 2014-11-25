namespace ForumSystem.Data
{
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using ForumSystem.Data.Models;

    public interface IForumSystemDbContext
    {
        IDbSet<User> Users { get; set; }

        IDbSet<Feedback> Feedbacks { get; set; }

        IDbSet<Post> Posts { get; set; }

        IDbSet<Tag> Tags { get; set; }

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        IDbSet<T> Set<T>() where T : class;

        int SaveChanges();

        void Dispose();
    }
}
