using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSMClassLibrary
{
    public class GSM
    {
        //Define a class that holds information about a mobile phone device: model, manufacturer, price, owner, 
        //battery characteristics (model, hours idle and hours talk) and display characteristics (size and number of colors). 
        //Define 3 separate classes (class GSM holding instances of the classes Battery and Display).

        private static readonly GSM iPhone4S = new GSM("IPhone4S", "Apple");
        private string model;
        private string manufacturer;
        private decimal? price;
        private string owner;
        private Battery battery;
        private Display display;
        private List<Call> callHistory = new List<Call>();


        //constructors
        public GSM(string model, string manufacturer)
        {
            this.Model = model;
            this.Manufacturer = manufacturer;
        }

        public GSM(string model, string manufacturer, decimal? price)
            : this(model, manufacturer)
        {
            this.Price = price;
        }

        public GSM(string model, string manufacturer, Battery battery)
            : this(model, manufacturer)
        {
            this.Battery = battery;
        }

        public GSM(string model, string manufacturer, string owner)
            : this(model, manufacturer)
        {
            this.Owner = owner;
        }

        public GSM(string model, string manufacturer, Display display)
            : this(model, manufacturer)
        {
            this.Display = display;
        }

        public GSM(string model, string manufacturer, decimal? price = null, string owner = null, Battery battery = null, Display display = null) 
            : this(model, manufacturer)
        {
            this.Price = price;
            this.Owner = owner;
            this.Battery = battery;
            this.Display = display;
        }

        //Use properties to encapsulate the data fields inside the GSM, Battery and Display classes. 
        //Ensure all fields hold correct data at any given time.
        public string Model
        {
            get { return this.model; }
            set 
            {
                if (String.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException("The model should not be empty!");
                this.model= value; 
            }
        }
        public string Manufacturer
        {
            get { return this.manufacturer; }
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException("The manufacturer should not be empty!");
                this.manufacturer= value; 
            }
        }
        public decimal? Price
        {
            get { return this.price; }
            set {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("The price cannot be negative!");
                else
                    this.price = value;
                }
		 
	    }
        public string Owner
        {
            get { return this.owner; }
            set { this.owner = value; }
        }
        public Battery Battery
        {
            get { return this.battery; }
            set { this.battery= value; }
        }
        public Display Display
        {
            get { return this.display; }
            set { this.display = value; }
        }
        public static GSM IPhone4S
        {
            get { return iPhone4S; }
        }
        public List<Call> CallHistory
        {
            get { return callHistory; }
        }
        
        //Add methods in the GSM class for adding and deleting calls from the calls history. Add a method to clear the call history.
        public void AddCall(Call call)
        {
            this.CallHistory.Add(call);
        }

        public void DeleteCall(Call call)
        {
            this.CallHistory.Remove(call);
        }

        public void ClearCallHistory()
        {
            this.callHistory.Clear();
        }

        //Add a method that calculates the total price of the calls in the call history. Assume the price per minute is fixed and is provided as a parameter.
        public decimal CalcPrice(decimal pricePerMinute)
        {
            int duration = 0;
            foreach (var call in callHistory)
            {
                duration += call.Duration;
            }

            return duration * (pricePerMinute/ 60);
        }


        //Add a method in the GSM class for displaying all information about it. Try to override ToString().
        public override string ToString()
        {
            StringBuilder res = new StringBuilder();
            res.Append(String.Format("Model: {0}", this.Model));
            res.Append(String.Format("\nManufacturer: {0}", this.Manufacturer));

            res.Append(this.Price == null ? "\nPrice: N/A": String.Format("\nPrice: {0}", this.price));
            res.Append(this.Owner == null ? "\nOwner: N/A" : String.Format("\nOwner: {0}", this.owner));

            if (this.Battery != null)
            {
                res.Append(this.battery.Model == null ? "\nBattery model: N/A" : String.Format("\nBattery model: {0}", this.battery.Model));
                res.Append(this.Battery.Type == null ? "\nBattery type: N/A" : String.Format("\nBattery type: {0}", this.battery.Type));
                res.Append(this.Battery.HoursIdle == null ? "\nHours idle: N/A" : String.Format("\nHours idle: {0}", this.battery.HoursIdle));
                res.Append(this.Battery.HoursTalk == null ? "\nHours talk: N/A" : String.Format("\nHours talk: {0}", this.battery.HoursTalk));
            }

            if (this.Display != null)
            {
                res.Append(this.Display.Size == null? "\nDisplay size: N/A" : String.Format("\nDisplay size: {0}", this.display.Size));
                res.Append(this.Display.NumOfColors == null ? "\nDisplay colors: N/A" : String.Format("\nDisplay colors: {0}", this.display.NumOfColors));
            }

            return res.ToString();
        }

    }
}
