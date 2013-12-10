using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimberYardSoft.ClassStructure
{
    [Serializable]
    public class TimberYard
    {
        //field
        private List<Lot> lots = new List<Lot>();
        public string Name { get; set; }
        public event YardChangedEventHandler YardChanged;

        public List<Lot> GetLots
        {
            get { return lots; }
        }

        public TimberYard(string name)
        {
            this.Name = name;
        }

        protected void OnYardChanged(Lot lot, ChangeType type)
        {
            if (YardChanged != null)
            {
                YardChangedEventArgs args = new YardChangedEventArgs(lot, type);
                YardChanged(this, args);
            }
        }

        //add a new lot to the yard
        public void AddLot(Lot lot)
        {
            this.lots.Add(lot);
            OnYardChanged(lot, ChangeType.IN);
        }

        //remove a lot from the yard queue
        public void RemoveLot(Lot lot)
        {
            this.lots.Remove(lot);
            OnYardChanged(lot, ChangeType.OUT);
        }

        public int LotCount()
        {
            return this.lots.Count;
        }

        public Lot GetLot(int listIndex)
        {
            return this.lots[listIndex];
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
