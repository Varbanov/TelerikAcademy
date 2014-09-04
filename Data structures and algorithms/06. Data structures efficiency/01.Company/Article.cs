namespace _01.Company
{
    using System;

    public class Article :IComparable<Article>
    {
        public string Barcode { get; set; }
        public string Vendor { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }

         public Article(string barcode, string vendor, string title, decimal price) 
         { 
             this.Barcode = barcode; 
             this.Vendor = vendor; 
             this.Title = title; 
             this.Price = price; 
         }

         public override string ToString()
         {
             return this.Barcode + " " + this.Title + " " + this.Price;
         }


         public int CompareTo(Article other)
         {
             return this.Barcode.CompareTo(other.Barcode);
         }
    }
}
