using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TimberYardSoft.ClassStructure
{
    [Serializable]
    public abstract class Lot : ICloneable//: ISerializeable
    {
        //fields
        public int Id { get; set; }
        public LotSize Size { get; set; }
        public Wood Wood { get; set; }
        private int pieces;
        private decimal price;

        //properties
        public int Pieces
        {
            get { return pieces; }
            set 
            {
                if (value < 1 || value > 1000)
                {
                    throw new ArgumentException("Pieces must be between 1 and 10 000!");
                }
                pieces = value;
            }
        }

        public decimal Price
        {
            get { return price; }
            set 
            {
                if (value < 0)
                {
                    throw new ArgumentException("Price must be positive!");
                }
                else
                {
                    this.price = value;
                }
            }
        }

        //constructor
        public Lot(Wood wood, LotSize size, int pieces, decimal price)
        {
            this.Id = IdGenerator.GetId();
            this.Wood = wood;
            this.Size = size;
            this.Pieces = pieces;
            this.Price = price;
        }


        //public virtual string Serialize()
        //{
        //    StringBuilder res = new StringBuilder();
        //    res.AppendFormat("{0} ", this.Id.ToString());
        //    res.AppendFormat("{0} ", this.Size.ToString());
        //    res.AppendFormat("{0} ", this.Wood.ToString());
        //    res.AppendFormat("{0} ", this.Pieces.ToString());
        //    res.AppendFormat("{0} ", this.Price.ToString());
        //    return res.ToString();
        //}

        //public virtual object Deserialize(string str)
        //{
        //    string[] splitted = str.Split(' ');
        //    int tempId = int.Parse(splitted[0]);
        //    int tempW = int.Parse(splitted[1]);
        //    int tempH = int.Parse(splitted[2]);
        //    int tempdL = int.Parse(splitted[3]);
        //    int tempPieces = int.Parse(splitted[5]);
        //    decimal tempPrice = decimal.Parse(splitted[6]);
        //    Wood tempWood;

        //    switch (splitted[4])
        //    {
        //        case "Buk": tempWood = Wood.Buk;
        //            break;
        //        case "Dub": tempWood = Wood.Dub;
        //            break;
        //        case "Yavor": tempWood = Wood.Yavor;
        //            break;
        //        case "Yasen": tempWood = Wood.Yasen;
        //            break;
        //            //todo: custom database exception class to be implemented
        //        default: throw new ArgumentException("Database error: cannot read wood type");
        //    }

        //    switch (tempWood)
        //    {
        //        case Wood.Buk: return new BukLot(new LotSize(tempW, tempH, tempdL), tempPieces, tempPrice);
        //            break;
        //        default: throw new ArgumentException();
        //    }
        //
        //}
        
        object ICloneable.Clone()
        {
            return this.Clone();
        }

        public Lot Clone()
        {
            Wood wood = this.Wood;
            LotSize size = this.Size;
            int pieces = this.pieces;
            decimal price = this.Price;

            if (wood == Wood.Buk)
            {
                return new BukLot(size, pieces, price);
            }
            else if (wood == Wood.Dub)
            {
                return new DubLot(size, pieces, price);
            }
            else if (wood == Wood.Yavor)
            {
                return new YavorLot(size, pieces, price);
            }
            else if (wood == Wood.Yasen)
            {
                return new YasenLot(size, pieces, price);
            }
            else
            {
                throw new ArgumentException("Lot cloning error: Invalid wood type!");
            }
        }

        public override string ToString()
        {
            string result = String.Format("{0}  {1,10}  {2}  Pieces: {3,4}  Price: {4}", this.Id.ToString().PadLeft(6, '0'), this.Wood, this.Size, this.Pieces, this.Price);
            return result;
        }
    }
}
