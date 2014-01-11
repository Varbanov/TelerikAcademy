namespace WarMachines.Machines
{
    using WarMachines.Interfaces;
    using System.Collections.Generic;
    using System.Text;

    public abstract class Machine : WarMachines.Interfaces.IMachine
    {
        private string name;
        private IPilot pilot;
        private double healthPoints;
        protected double attackPoints;
        protected double defencePoints;
        private List<string> targets;

        public Machine(string name, double healthpoints, double attackPoints, double defencePoints, IPilot pilot = null)
        {
            this.Name = name;
            this.HealthPoints = healthpoints;
            this.attackPoints = attackPoints;
            this.defencePoints = defencePoints;
            this.targets = new List<string>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }
        }

        public Interfaces.IPilot Pilot
        {
            get
            {
                return this.pilot;
            }
            set
            {
                this.pilot = value;
            }
        }

        public double HealthPoints
        {
            get
            {
                return this.healthPoints;
            }
            set
            {
                this.healthPoints = value;
            }
        }

        public double AttackPoints
        {
            get { return this.attackPoints; }
        }

        public double DefensePoints
        {
            get { return this.defencePoints; }
        }

        public System.Collections.Generic.IList<string> Targets
        {
            get { return this.targets; }
        }

        public void Attack(string target)
        {
            //todo: may cause problems
            this.targets.Add(target);
        }
    }
}
