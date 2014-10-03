namespace Exam.Data
{
    using Exam.Data.Repositories;
    using Exam.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class BugData : IBugData
    {
        private DbContext context;
        private IDictionary<Type, object> repositories;

        public BugData()
            : this(new BugDbContext())
        {
        }

        public BugData(BugDbContext context)
        {
            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }

        public IRepository<Bug> Bugs
        {
            get { return this.GetRepository<Bug>(); }

        }

        public int SaveChanges()
        {
           return this.context.SaveChanges();
        }


        private IRepository<T> GetRepository<T>() where T : class
        {
            var typeofModel = typeof(T);
            if (!this.repositories.ContainsKey(typeofModel))
            {
                var type = typeof(Repository<T>);
                this.repositories.Add(typeofModel, Activator.CreateInstance(type, this.context));
            }

            return (IRepository<T>)this.repositories[typeofModel];
        }



    }
}
