using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSMClassLibrary
{

    public class Battery
    {
        //battery characteristics (model, hours idle and hours talk)
        //Add an enumeration BatteryType (Li-Ion, NiMH, NiCd, …) and use it as a new field for the batteries.

        private string model;
        private int? hourdIdle;
        private int? hoursTalk;
        private BatteryType? type;

        public Battery()
        {
        }

        public Battery(string model)
        {
            this.Model = model;
        }

        public Battery(string model, int hoursIdle) : this(model)
        {
            this.HoursIdle = hoursIdle;
        }

        public Battery(string model, int? hoursIdle, int? hoursTalk, BatteryType type) 
            : this(model)
        {
            this.HoursIdle = hoursIdle;
            this.HoursTalk = hoursTalk;
            this.Type = type;
        }

        public string Model
        {
            get { return this.model; }
            set { this.model = value; }
        }
        public int? HoursIdle
        {
            get { return this.hourdIdle; }
            set {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("The hours should be positive!");
                else
                    this.hourdIdle = value;
                }
        }
        public int? HoursTalk
        {
            get { return this.hoursTalk; }
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("The hours should be positive!");
                else
                    this.hoursTalk = value;
            }
        }
        public BatteryType? Type
        {
            get { return this.type; }
            set { this.type = value; }
        }



    }
}
