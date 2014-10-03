﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicMagazine.Model
{
    public class Song
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int Year { get; set; }

        public string Genre { get; set; }

        public int ArtistId { get; set; }

        public virtual Artist Artist { get; set; }
    }
}
