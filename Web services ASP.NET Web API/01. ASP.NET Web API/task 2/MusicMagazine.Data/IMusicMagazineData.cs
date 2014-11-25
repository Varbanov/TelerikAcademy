using MusicMagazine.Data.Repositories;
using MusicMagazine.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicMagazine.Data
{
   public interface IMusicMagazineData
    {
       IRepository<Album> Albums { get; }
       IRepository<Artist> Artists { get; }
       IRepository<Song> Songs { get; }

       void SaveChanges();
    }
}
