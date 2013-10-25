using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Bank
{
    abstract class Customer
    {
        //fields
        //readonly because once a customer is initialized, they cannot change neither their name, nor their id
        private readonly string name;
        private readonly string id;

        //properties
	    public string ID
	    {
		    get { return id;}
	    }

        public string Name
        {
            get { return name; }
        }

        //constructor
        public Customer(string name, string id)
        {
            this.name = name;
            this.id = id;
        }
        
    }
}
