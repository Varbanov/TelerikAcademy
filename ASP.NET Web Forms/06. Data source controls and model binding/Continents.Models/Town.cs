using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Continents.Models
{
    public class Town
    {
        public Town()
        {
        }

        public Town(string name, long population)
        {
            this.Name = name;
            this.Population = population;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public long Population { get; set; }
        public int CountryId { get; set; }


    }
}
