using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSMClassLibrary
{
    public class Call
    {
        //Create a class Call to hold a call performed through a GSM. It should contain date, time, dialed phone number and duration (in seconds).

        public string Date { get; set; }
        public int Hour { get; set; }
        public int Minute { get; set; }
        public int Second { get; set; }
        public string Number { get; set; }
        public int Duration { get; set; }

        public Call(DateTime date, string number, int duration) //23.05.1988 23:59:59
        {
            this.Date = date.Date.ToShortDateString();
            this.Hour = date.Hour;
            this.Minute = date.Minute;
            this.Second = date.Second;
            this.Number = number;
            this.Duration = duration;
        }

        public override string ToString()
        {
            string res = this.Date + " " + this.Hour + ":" + this.Minute + ":" + this.Second;
            res +=" " + this.Number + " Dur:" + this.Duration;
            return res;
        }
    }
}
