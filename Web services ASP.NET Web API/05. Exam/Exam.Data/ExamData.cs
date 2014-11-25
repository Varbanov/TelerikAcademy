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

    public class ExamData : IExamData
    {
        private DbContext context;
        private IDictionary<Type, object> repositories;

        // TODO maybe remove this empty contructor using ninject
        public ExamData()
            : this(new ExamDbContext())
        {
        }

        public ExamData(ExamDbContext context)
        {
            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }

        public IRepository<User> Users 
        {
            get { return this.GetRepository<User>(); }
        }

        public IRepository<Notification> Notifications
        {
            get { return this.GetRepository<Notification>(); }

        }

        public IRepository<Game> Games
        {
            get { return this.GetRepository<Game>(); }
        }

       

        public IRepository<Model3> Model3s
        {
            get { return this.GetRepository<Model3>(); }

        }

        public IRepository<Model4> Model4s
        {
            get { return this.GetRepository<Model4>(); }

        }

        public IRepository<Model5> Model5s
        {
            get { return this.GetRepository<Model5>(); }

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
