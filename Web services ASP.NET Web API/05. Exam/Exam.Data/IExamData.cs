namespace Exam.Data
{
    using Exam.Data.Repositories;
using Exam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    public interface IExamData
    {
        IRepository<User> Users { get; }
        IRepository<Notification> Notifications { get; }
        IRepository<Game> Games { get; }
        IRepository<Model3> Model3s { get; }
        IRepository<Model4> Model4s { get; }
        IRepository<Model5> Model5s { get; }

        int SaveChanges();
    }
}
