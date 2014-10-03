using Music.Data;
using Music.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music.ConsoleClient
{
    class Program
    {
        static void Main()
        {
            var ctx = new MusicDbContext();
            MusicData dbContext = new MusicData(ctx);

            for (int i = 0; i < 3; i++)
            {
                var artist = new Artist()
                {
                    Name = "Artist" + i,
                };

                dbContext.Artists.Add(artist);

                var album = new Album() { Title = "Album" + i};
                album.Artists.Add(artist);
                dbContext.Albums.Add(album);

                var song = new Song("Song" + i, artist);
                song.Albums.Add(album);
                dbContext.Songs.Add(song);
            }

            dbContext.SaveChanges();
        }
    }
}
