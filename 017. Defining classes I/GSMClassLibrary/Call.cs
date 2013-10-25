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

        private DateTime date;
        private int hour;
        private int minute;
        private int second;
        private string number;
        private int duration;

        public Call(DateTime date, string number, int duration) //23.05.1988 23:59:59
        {
            this.date = date.Date;
            this.hour = date.Hour;
            this.minute = date.Minute;
            this.second = date.Second;
            this.number = number;
            this.duration = duration;
        }

        public int Duration
        {
            get { return this.duration; }
            set { this.duration = value; }
        }
        

    }
}
