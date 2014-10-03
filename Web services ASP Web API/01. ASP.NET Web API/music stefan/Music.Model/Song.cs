using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace Music.Model
{
    public class Song
    {
        private ICollection<Album> albums;

        public Song()
        {
        }

        public Song(string title, Artist artist)
        {
            this.Title = title;
            this.Artist = artist;
            this.albums = new HashSet<Album>();
        }

        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public Artist Artist { get; set; }

        public int ArtistId { get; set; }


        public virtual ICollection<Album> Albums
        {
            get { return albums; }
            set { albums = value; }
        }
        
    }
}
