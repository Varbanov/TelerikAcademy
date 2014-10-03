using Music.Data.Repositories;
using Music.Model;

namespace Music.Data
{
    public interface IMusicData
    {
        IRepository<Album> Albums { get; }
        IRepository<Artist> Artists { get; }
        IRepository<Song> Songs { get; }

        void SaveChanges();
    }
}
