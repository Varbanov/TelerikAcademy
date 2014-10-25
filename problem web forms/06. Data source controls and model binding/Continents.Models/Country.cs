using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Continents.Models
{
    public class Country
    {
        private ICollection<Town> towns;

         public Country(IEnumerable<Town> towns)
            : this()
        {
            foreach (var t in towns)
            {
                this.towns.Add(t);
            }
        }

        public Country()
        {
            this.towns = new HashSet<Town>();
        }

        public virtual ICollection<Town> Towns
        {
            get { return towns; }
            set { towns = value; }
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Language { get; set; }
        public long Population { get; set; }
        public int ContinentId { get; set; }
        public virtual Continent Continent { get; set; }

    }
}
