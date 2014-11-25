namespace Exam.Data
{
    using Exam.Data.Repositories;
using Exam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    public interface IBugData
    {
        IRepository<Bug> Bugs { get; }

        int SaveChanges();
    }
}
