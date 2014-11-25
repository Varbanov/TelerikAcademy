using MusicMagazine.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MusicMagazine.Data;
using MusicMagazine.Model;

namespace MusicMagazine.Services.Controllers
{
    public class ArtistController : ApiController
    {
        MusicMAgazineDbCOntext db = new MusicMAgazineDbCOntext();

        public IQueryable<Artist> GetArtists()
        {
            return db.Artists;
        }
    }
}
