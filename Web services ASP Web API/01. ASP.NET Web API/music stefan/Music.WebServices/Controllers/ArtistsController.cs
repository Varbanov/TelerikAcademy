using Music.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using Music.WebServices.Models;
using Music.Model;

namespace Music.WebServices.Controllers
{
    public class ArtistsController : ApiController
    {
        private IMusicData data;

        public ArtistsController()
            : this(new MusicData())
        {
        }

        public ArtistsController(IMusicData data)
        {
            this.data = data;
        }

        [HttpGet]
        public IHttpActionResult All()
        {
            var artists = this.data
                .Artists
                .All()
                .Select(ArtistModel.FromArtist);

            return this.Ok(artists);
        }

        [HttpGet]
        public IHttpActionResult ById(int id)
        {
            var artist = this.data
                .Artists
                .All()
                .Where(a => a.Id == id)
                .Select(ArtistModel.FromArtist)
                .FirstOrDefault();

            if (artist == null)
            {
                return this.BadRequest("Artist does not exist!");
            }

            return this.Ok(artist);
        }

        [HttpPost]
        public IHttpActionResult Create(ArtistModel artist)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(ModelState);
            }

            var newArtist = new Artist
            {
                Name = artist.Name,
                Country = artist.Country,
                DateOfBirth = artist.DateOfBirth
            };

            this.data.Artists.Add(newArtist);
            this.data.SaveChanges();

            artist.Id = newArtist.Id;
            return this.Ok(newArtist);
        }

        [HttpPut]
        public IHttpActionResult Update(int id, ArtistModel artist)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(ModelState);
            }

            var existingArtist = this.data
                .Artists
                .All()
                .FirstOrDefault(a => a.Id == id);
            if (existingArtist == null)
            {
                return this.BadRequest("Artist does not exist!");
            }

            existingArtist.Name = artist.Name;
            existingArtist.Country = artist.Country;
            existingArtist.DateOfBirth = artist.DateOfBirth;

            this.data.SaveChanges();

            artist.Id = existingArtist.Id;
            return this.Ok(artist);
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var existingArtist = this.data
                .Artists
                .All()
                .FirstOrDefault(a => a.Id == id);

            if (existingArtist == null)
            {
                return BadRequest("Artist does not exists!");
            }

            this.data.Artists.Delete(existingArtist);
            this.data.SaveChanges();

            return Ok();
        }

        [HttpPost]
        public IHttpActionResult AddSong(int artistId, int songId)
        {
            var artist = this.data
                .Artists
                .All()
                .FirstOrDefault(a => a.Id == artistId);

            if (artist == null)
            {
                return BadRequest("Artist does not exist - invalid id!");
            }

            var song = this.data
                .Songs
                .All()
                .FirstOrDefault(s => s.Id == songId);

            if (song == null)
            {
                return BadRequest("Song does not exist - invalid id!");
            }

            artist.Songs.Add(song);
            this.data.SaveChanges();

            return Ok();
        }

        public IHttpActionResult AddAlbum(int artistId, string albumId)
        {
            var artist = this.data
                .Artists
                .All()
                .FirstOrDefault(a => a.Id == artistId);

            if (artist == null)
            {
                return BadRequest("Artist does not exists - invalid id!");
            }

            Guid theAlbumId = Guid.Parse(albumId);
            var album = this.data
                .Albums
                .All()
                .FirstOrDefault(s => s.Id == theAlbumId);

            if (album == null)
            {
                return BadRequest("Album does not exists - invalid id!");
            }

            artist.Albums.Add(album);
            this.data.SaveChanges();

            return Ok();
        }

    }
}
