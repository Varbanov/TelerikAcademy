using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music.Model
{
    public class Artist
    {
        private ICollection<Album> albums;
        private ICollection<Song> songs;


        public Artist()
        {
            this.albums = new HashSet<Album>();
            this.songs= new HashSet<Song>();
        }

        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        public string Country { get; set; }
        public DateTime? DateOfBirth { get; set; }

        public virtual ICollection<Album> Albums
        {
            get { return albums; }
            set { albums = value; }
        }

        public virtual ICollection<Song> Songs
        {
            get { return songs; }
            set { songs = value; }
        }
        

    }
}
