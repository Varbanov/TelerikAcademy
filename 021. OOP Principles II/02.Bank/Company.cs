using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Bank
{
    class Company : Customer
    {
        //fields
        private Individual authorizedRepresentator;

        //properties
        public Individual AuthorizedRepresentator
        {
            get { return authorizedRepresentator; }
            set 
            {
                if (value == null)
                    throw new ArgumentNullException("The representator field is empty!");
                else
                    authorizedRepresentator = value; }
        }
        
        //constructor
        public Company(string name, string id, Individual individual)
            : base(name, id)
        {
            this.AuthorizedRepresentator = individual;
        }

    }
}
