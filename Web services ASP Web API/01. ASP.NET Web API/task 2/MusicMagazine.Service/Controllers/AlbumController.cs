namespace MusicMagazine.Service.Controllers
{
    using MusicMagazine.Data;
    using MusicMagazine.Data.Repositories;
    using MusicMagazine.Model;
    using MusicMagazine.Service.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;
    public class AlbumController : ApiController
    {

        public IMusicMagazineData data;
        public AlbumController(IMusicMagazineData data)
        {
            this.data = data;
           
        }

        public AlbumController()
            :this(new MusicMagazineData())
        { 
        }

        [HttpGet]
        public IHttpActionResult All()
        {
           return Ok( this.data.Albums.All().Select(a => new AlbumModel
               {
                   Id = a.Id,
                   Title = a.Title
               })) ;
        }

        [HttpPost]
        public IHttpActionResult Create(AlbumModel album)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newAlbum = new Album
            {
                 Title = album.Title
            };

            this.data.Albums.Add(newAlbum);
            this.data.SaveChanges();

            return Ok(newAlbum);
        }

        [HttpPut]
        public IHttpActionResult Update(int id, Album album)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingAlbum = this.data.Albums.All().FirstOrDefault(a => a.Id == id);
            if (existingAlbum == null)
            {
                return BadRequest("Such album does not exist");
            }

            existingAlbum.Title = album.Title;
            album.Id = existingAlbum.Id;
            this.data.SaveChanges();
            return Ok(album);
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingAlbum = this.data.Albums.All().FirstOrDefault(a=> a.Id == id);
            if (existingAlbum == null)
            {
                return BadRequest("Such album does not exist");
            }

            this.data.Albums.Delete(existingAlbum);
            this.data.SaveChanges();
            return Ok();

        }

        [HttpPost]
        public IHttpActionResult AddSong(int id, int songId)
        {
            var album = this.data.Albums.All().FirstOrDefault(a => a.Id == id);
            if (album == null)
            {
                 return BadRequest("Such album does not exist");
            }

            var song = this.data.Songs.All().FirstOrDefault(s => s.Id == songId);
            if (song == null)
            {
                return BadRequest("Such song does not exist");
            }

            album.Songs.Add(song);
            
            this.data.SaveChanges();
            return Ok(album);
        }
    }
}
