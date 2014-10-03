using Exam.Data;
using Exam.Data.Repositories;
using Exam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bugs.Tests
{
    public class BugFakeData : IBugData
    {
        BugFakeRepository data;

        public BugFakeData()
        {
            this.data = new BugFakeRepository();
        }

        public IRepository<Bug> Bugs
        {
            get { return this.data; }
        }

        public int SaveChanges()
        {
            return this.data.SaveChanges();
        }
    }
}
