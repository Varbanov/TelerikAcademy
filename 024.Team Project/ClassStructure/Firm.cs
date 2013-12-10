using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters;
using System.Runtime.Serialization.Formatters.Binary;


// Kod za serializacia

//Stream stream = File.Open("firmData.file", FileMode.Create);
//BinaryFormatter bformatter = new BinaryFormatter();
//bformatter.Serialize(stream, firm);
//stream.Close();

// Kod za deserializaciq - tezi dvata bloka trqbva da se vyrjat kym deistviq

//Stream stream = File.Open("firmData.file", FileMode.Open);
//BinaryFormatter bformatter = new BinaryFormatter();
//this.firm = (Firm)bformatter.Deserialize(stream);  - > tova vryshta deserializirania obekt Firm
//stream.Close();

namespace TimberYardSoft.ClassStructure
{
    [Serializable]
    public class Firm
    {
        //fields
        private List<TimberYard> yards;
        private string name;
        private AvailabilityChangeJournal journal;
        private Order order;
        public event FirmYardsChangedEventHandler FirmYardAdded;

        //properties
        public Order Order
        {
            get { return this.order; }
            set { this.order = value; }
        }

        public AvailabilityChangeJournal Journal
        {
            get { return this.journal; }
        }

        public string Name
        {
            get { return name; }
            private set { name = value; }
        }

        public List<TimberYard> Yards
        {
            get { return this.yards; }
            set { this.yards = value; }
        }

        //constructor
        public Firm(string name)
        {
            this.Name = name;
            this.yards = new List<TimberYard>();
            this.journal = AvailabilityChangeJournal.Journal;
            this.order = new Order();
        }

        //methods
        private void OnFirmYardAdded(TimberYard yard)
        {
            if (FirmYardAdded != null)
            {
                FirmYardAddedEventArgs args = new FirmYardAddedEventArgs(yard);
                FirmYardAdded(this, args);
            }
        }

        //add a yard
        public void AddYard(TimberYard timberYard)
        {
            this.yards.Add(timberYard);
            OnFirmYardAdded(timberYard);
        }

        //remove a yard
        public void RemoveYard(TimberYard timberYard)
        {
            this.yards.Remove(timberYard);
        }

        public TimberYard GetYard(int index)
        {
            return this.yards[index];
        }

        public List<TimberYard> GetAllYards()
        {
            return this.yards;
        }


        // Deserialization constructor
        public Firm(SerializationInfo info, StreamingContext ctxt)
        {

            for (int i = 0; i < yards.Count; i++)
            {
                yards[i].Name = (string)info.GetValue("YardName" + i, typeof(string));

                for (int j = 0; j < yards[i].LotCount(); j++)
                {
                    yards[i].GetLot(j).Id = (int)info.GetValue("LotID" + i + j, typeof(int));
                    yards[i].GetLot(j).Wood = (Wood)info.GetValue("WoodType" + i + j, typeof(Wood));
                    yards[i].GetLot(j).Size = (LotSize)info.GetValue("Size" + i + j, typeof(LotSize));
                    yards[i].GetLot(j).Pieces = (int)info.GetValue("Pieces" + i + j, typeof(int));
                    yards[i].GetLot(j).Price = (decimal)info.GetValue("Price" + i + j, typeof(decimal));
                }
            }



        }

        //Serialization function.
        public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {
            for (int i = 0; i < yards.Count; i++)
            {
                info.AddValue("YardName" + i, yards[i].Name);

                for (int j = 0; j < yards[i].LotCount(); j++)
                {
                    info.AddValue("LotID" + i + j, yards[i].GetLot(j).Id);
                    info.AddValue("WoodType" + i + j, yards[i].GetLot(j).Wood);
                    info.AddValue("Size" + i + j, yards[i].GetLot(j).Size);
                    info.AddValue("Pieces" + i + j, yards[i].GetLot(j).Pieces);
                    info.AddValue("Price" + i + j, yards[i].GetLot(j).Price);
                }
            }

        }



    }
}
