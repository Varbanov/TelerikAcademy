namespace _02.LargeCollectionOfProducts
{
    using System;

    public class Product
    {
        public string Name { get; set; }

        private decimal price;

        public Product(string name, decimal price)
        {
            this.Name = name;
            this.Price = price;
        }

        public decimal Price
        {
            get { return this.price; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("The price must be positive!");
                }

                this.price = value;
            }
        }

        public override string ToString()
        {
            return this.Name + " " + this.Price;
        }
    }
}
