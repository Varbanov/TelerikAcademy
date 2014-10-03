using Exam.Data.Repositories;
using Exam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bugs.Tests
{
    public class BugFakeRepository : IRepository<Bug>
    {
        private IList<Bug> data;
        public BugFakeRepository()
        {
            this.data = new List<Bug>();
            this.data.Add(new Bug()
                {
                    Id = 0,
                    LogDate = DateTime.Now.Date,
                    Status = BugStatus.Pending,
                    Text = "The bug",
                });
        }

        public IQueryable<Bug> All()
        {
            return this.data.AsQueryable();
        }

        public void Add(Bug entity)
        {
            this.data.Add(entity);
        }

        public Bug Find(object id)
        {
            return this.data[0];
        }

        public void Update(Bug entity)
        {
            entity.Text = "updated";
        }

        public Bug Delete(Bug entity)
        {
            this.data.Remove(entity);
            return entity;
        }

        public Bug Delete(object id)
        {
            var bug = this.data[0];
            this.data.Remove(bug);
            return bug;
        }

        public void Detach(Bug entity)
        {
            this.data.Remove(entity);
        }

        public int SaveChanges()
        {
            return 0;
        }
    }
}
