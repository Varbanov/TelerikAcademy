using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarMachines.Machines;
using WarMachines.Interfaces;

namespace WarMachines
{
    class Pilot : WarMachines.Interfaces.IPilot
    {
        private string name;
        private List<IMachine> machines;

        public Pilot(string name)
        {
            this.name = name;
            this.machines = new List<IMachine>();
        }

        public string Name
        {
            get { return this.name; }
        }

        public void AddMachine(Interfaces.IMachine machine)
        {
            this.machines.Add(machine);
        }

        public string Report()
        {
            StringBuilder res = new StringBuilder();
            res.Append(this.Name);
            if (this.machines.Count == 0)
            {
                res.Append(" - no machines");
            }
            else if (this.machines.Count == 1)
            {
                res.AppendLine(" - 1 machine");
                res.Append(this.machines[0].ToString());
            }
            else
            {
                res.AppendFormat(" - {0} machines", this.machines.Count);
                res.AppendLine();
                this.machines.OrderBy((x) => x.HealthPoints).ThenBy((x) => x.Name);
                foreach (var machine in this.machines)
                {
                    res.Append(machine.ToString());
                }
            }

                return res.ToString();
            
        }
    }
}
