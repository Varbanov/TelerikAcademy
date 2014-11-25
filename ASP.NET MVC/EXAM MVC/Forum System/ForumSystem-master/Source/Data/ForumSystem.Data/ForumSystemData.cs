namespace ForumSystem.Data
{
    using System;
    using System.Collections.Generic;
    using ForumSystem.Data.Common.Models;
    using ForumSystem.Data.Common.Repository;
    using ForumSystem.Data.Models;

    public class ForumSystemData : IForumSystemData, IDisposable
    {
        private readonly IForumSystemDbContext context;

        private readonly Dictionary<Type, object> repositories = new Dictionary<Type, object>();

        public ForumSystemData(IForumSystemDbContext context)
        {
            this.context = context;
        }

        public IForumSystemDbContext Context
        {
            get { return this.context; }
        }

        public IDeletableEntityRepository<Post> Posts
        {
            get { return this.GetDeletableEntityRepository<Post>(); }
        }

        public IDeletableEntityRepository<Tag> Tags
        {
            get { return this.GetDeletableEntityRepository<Tag>(); }
        }

        public IRepository<User> Users
        {
            get { return this.GetRepository<User>(); }
        }

        public IDeletableEntityRepository<Feedback> Feedbacks
        {
            get { return this.GetDeletableEntityRepository<Feedback>(); }
        }

        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }

        public void Dispose()
        {
            if (this.context != null)
            {
                this.context.Dispose();
            }
        }

        private IRepository<T> GetRepository<T>() where T : class
        {
            if (!this.repositories.ContainsKey(typeof(T)))
            {
                var type = typeof(GenericRepository<T>);
                this.repositories.Add(typeof(T), Activator.CreateInstance(type, this.context));
            }

            return (IRepository<T>)this.repositories[typeof(T)];
        }

        private IDeletableEntityRepository<T> GetDeletableEntityRepository<T>() where T : class, IDeletableEntity
        {
            if (!this.repositories.ContainsKey(typeof(T)))
            {
                var type = typeof(DeletableEntityRepository<T>);
                this.repositories.Add(typeof(T), Activator.CreateInstance(type, this.context));
            }

            return (IDeletableEntityRepository<T>)this.repositories[typeof(T)];
        }
    }
}
