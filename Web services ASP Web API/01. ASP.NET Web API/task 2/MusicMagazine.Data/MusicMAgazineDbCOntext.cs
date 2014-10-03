namespace MusicMagazine.Data
{
    using MusicMagazine.Data.Migrations;
    using MusicMagazine.Model;
    using System.Data.Entity;

   public class MusicMAgazineDbCOntext : DbContext, IMusicMagazineDbContext
    {
        public MusicMAgazineDbCOntext()
            : base("MusicMagazineConnection")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MusicMAgazineDbCOntext, Configuration>());
        }

        public virtual IDbSet<Artist> Artists { get; set; }

        public virtual IDbSet<Album> Albums { get; set; }

        public virtual IDbSet<Song> Songs { get; set; }


        public new void SaveChanges()
        {
            base.SaveChanges();
        }

        public new IDbSet<TEntity> Set<TEntity>() where TEntity : class
        {
           return base.Set<TEntity>();
        }
    }
}
