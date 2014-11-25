

using System.Linq;
namespace MusicMagazine.Data.Repositories
{
    public interface IRepository<T> where T: class
    {
        IQueryable<T> All();

        void Add(T Entity);

        void Update(T Entity);

        void Detach(T Entity);

        void SaveChanges();

        void Delete(T Entity);
      
    }
}
