using Music.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace Music.WebServices.Models
{
    public class ArtistModel
    {
        public static Expression<Func<Artist, ArtistModel>> FromArtist
        {
            get
            {
                return a => new ArtistModel
                {
                    Name = a.Name,
                    Country = a.Country,
                    DateOfBirth = a.DateOfBirth,
                    Id = a.Id,
                };
            }
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public DateTime? DateOfBirth { get; set; }
    }
}