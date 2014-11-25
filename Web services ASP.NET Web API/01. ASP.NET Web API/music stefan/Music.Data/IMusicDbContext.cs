using Music.Model;
using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace Music.Data
{
    public interface IMusicDbContext
    {
        IDbSet<Album> Albums { get; set; }
        IDbSet<Artist> Artists { get; set;} 
        IDbSet<Song> Songs { get; set; }

        void SaveChanges();

        IDbSet<TEntity> Set<TEntity>() where TEntity : class;
        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

    }
}
