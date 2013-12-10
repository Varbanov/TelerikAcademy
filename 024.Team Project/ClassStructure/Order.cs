using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.ComponentModel;

namespace TimberYardSoft.ClassStructure
{
    public class Order : IReportable, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private List<Lot> orderedLots = new List<Lot>();
        private decimal totalPrice;

        public decimal Price
        {
            get { return this.totalPrice; }
        }

        public List<Lot> GetOrderedLots
        {
            get { return orderedLots; }
            set 
            {
                orderedLots = value;
                OnPropertyChanged("GetOrderedLots");
            }

        }

        //methods

        private void OnPropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChangedEventArgs args = new PropertyChangedEventArgs(property);
                PropertyChanged(this, args);
            }
        }

        public void AddLot(Lot lot)
        {
            this.orderedLots.Add(lot);
            this.totalPrice += lot.Price;
            OnPropertyChanged("Price");
        }

        public void RemoveLot(Lot lot)
        {
            this.orderedLots.Remove(lot);
            this.totalPrice -= lot.Price;
            OnPropertyChanged("Price");
        }

        public void CreateReport()
        {
            int reportId = IdGenerator.GetId();
            StreamWriter writer = new StreamWriter(String.Format(@"..\..\order_{0}.txt", reportId));
            string header = String.Format("Order #{0}{1}{2}{3}", reportId, Environment.NewLine, DateTime.Now.ToShortDateString(), Environment.NewLine);
            string columns = "ID|Wood|Width|Height|Length|Pieces|Price";
            string footer = String.Format("{0}END OF ORDER{0}Issued: {1}                   Signature:", Environment.NewLine, DateTime.Now.ToShortDateString());
            using (writer)
            {
                writer.WriteLine(header);
                writer.WriteLine(columns);
                writer.WriteLine();
                foreach (var lot in this.GetOrderedLots)
                {
                    writer.WriteLine(lot.ToString());
                }
                writer.WriteLine(footer);
            }
        }
    }
}
