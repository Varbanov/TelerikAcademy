using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music.Model
{
    public class Album
    {
        private ICollection<Artist> artists;
        private ICollection<Song> songs;

        public Album()
        {
            this.Id = Guid.NewGuid();
            this.artists = new HashSet<Artist>();
            this.songs = new HashSet<Song>();
        }

        [Key]
        public Guid Id { get; set; }
        public string Title { get; set; }

        public ICollection<Artist> Artists
        {
            get { return artists; }
            set { artists = value; }
        }

        public ICollection<Song> Songs
        {
            get { return songs; }
            set { songs = value; }
        }

    }
}
