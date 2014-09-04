using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitytFramework.Data;
using System.Data.Linq;

namespace EntitytFramework.Data
{
    public partial class Employee
    {
        public EntitySet<Territory> MyTerritory
        {
            get 
            {
                EntitySet<Territory> territories = new EntitySet<Territory>();
                territories.AddRange(this.Territories);
                return territories;
            }
        }
        
    }
}
