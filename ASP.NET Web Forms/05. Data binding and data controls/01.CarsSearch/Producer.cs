using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _01.CarsSearch
{
    public class Producer
    {
        public string Name { get; set; }
        public IList<string> Models { get; set; }

        public Producer() 
        { 
        }

        public Producer(string name)
        {
            this.Name = name;
            this.Models = new List<string>();
        }
    }
}