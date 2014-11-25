using MusicMagazine.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace MusicMagazine.Service
{
    public class SongController : ApiController
    {
        public IMusicMagazineData data;
        public SongController(IMusicMagazineData data)
        {
            this.data = data;
           
        }

        public SongController()
            :this(new MusicMagazineData())
        { 
        }

        [HttpGet]

        public IHttpActionResult All()
        {
           return Ok( this.data.Songs.All());
        }

        [HttpGet]

        public IHttpActionResult ById(int id)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var song = this.data.Songs.All().FirstOrDefault(s => s.Id == id);
            if (song == null)
            {
                BadRequest("No such song found");
            }

            return Ok(song);
        }

    }
}