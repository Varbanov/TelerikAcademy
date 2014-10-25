using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Data;
using TicTacToe.Models;

namespace TicTacToe.Tests
{
    public class FakeRepository<T> : IRepository<T>
        where T: class
    {
        private List<T> data = new List<T>();
        private int cchangedEntitiesCounter = 0;

        public IQueryable<T> All()
        {
            return this.data.AsQueryable();
        }

        public T GetById(object id)
        {
            int theId = (int) id;
            return this.data[theId];
        }

        public void Add(T entity)
        {
            this.data.Add(entity);
            cchangedEntitiesCounter++;
        }

        public void Update(T entity)
        {
            if (!this.data.Contains(entity))
            {
                throw new ArgumentException("No such entity");
            }
            cchangedEntitiesCounter++;
        }

        public void Delete(T entity)
        {
            this.data.Remove(entity);
            cchangedEntitiesCounter++;
        }

        public void Delete(object id)
        {
            int theId = (int) id;
            var entity = this.data[theId];
            this.data.RemoveAt(theId);
            cchangedEntitiesCounter++;
        }

        public int SaveChanges()
        {
            var result = cchangedEntitiesCounter;
            cchangedEntitiesCounter = 0;
            return result;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
