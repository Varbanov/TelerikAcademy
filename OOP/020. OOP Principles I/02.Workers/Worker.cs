using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Workers
{
    class Worker : Human
    {
        private decimal weekSalary;
        private int workHoursPerDay;

        public decimal WeekSallary
        {
            get { return weekSalary; }
            set { weekSalary = value; }
        }

        public int WorkHoursPerDay
        {
            get { return workHoursPerDay; }
            set { workHoursPerDay = value; }
        }

        public decimal MoneyPerHour()
        {
            //the week consists of 5 working days
            return this.weekSalary / (workHoursPerDay * 5);
        }

        public Worker(string firstName, string lastName, decimal weekSalary, int workHoursPerDay)
            : base(firstName, lastName)
        {
            this.WeekSallary = weekSalary;
            this.WorkHoursPerDay = workHoursPerDay;
        }
        
        
    }
}
