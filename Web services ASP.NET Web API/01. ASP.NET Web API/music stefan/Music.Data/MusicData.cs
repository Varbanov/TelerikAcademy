﻿using Music.Data.Repositories;
using Music.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music.Data
{
    public class MusicData : IMusicData
    {
        private IMusicDbContext context;
        private IDictionary<Type, object> repositories;


        public MusicData()
            : this(new MusicDbContext())
        {
        }

        public MusicData(IMusicDbContext context)
        {
            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }

        public IRepository<Album> Albums
        {
            get
            {
                return this.GetRepository<Album>();
            }
        }

        public IRepository<Artist> Artists
        {
            get 
            {
                return this.GetRepository<Artist>();
            }
        }

        public IRepository<Song> Songs
        {
            get
            {
                return this.GetRepository<Song>();
            }
        }

        public void SaveChanges()
        {
            this.context.SaveChanges();
        }


        private IRepository<T> GetRepository<T>() where T : class
        {
            var typeofModel = typeof(T);
            if (!this.repositories.ContainsKey(typeofModel))
            {
                var type = typeof(Repository<T>);
                this.repositories.Add(typeofModel, Activator.CreateInstance(type, this.context));
            }

            return (IRepository<T>)this.repositories[typeofModel];
        }
    }
}
