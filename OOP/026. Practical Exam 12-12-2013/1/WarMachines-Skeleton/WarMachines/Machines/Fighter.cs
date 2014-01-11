using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarMachines.Interfaces;

namespace WarMachines.Machines
{
    public class Fighter : Machine,IFighter
    {
        private bool stealthMode;

        public bool StealthMode
        {
            get { return this.stealthMode; }
        }

        public Fighter(string name, double attackPoints, double defensePoints, bool stealthMode, IPilot pilot = null)
            : base(name, 200, attackPoints, defensePoints, pilot)
        {
                this.stealthMode = stealthMode;
        }

        public void ToggleStealthMode()
        {
            //todo: toggle may cause problems
            if (this.stealthMode == false)
            {
                this.stealthMode = true;
            }
            else
            {
                this.stealthMode = false;
            }
        }

        public override string ToString()
        {
            StringBuilder res = new StringBuilder();
            res.AppendFormat("- {0}", this.Name);
            res.Append(Environment.NewLine);
            res.AppendFormat(" *Type: {0}", this.GetType().Name);
            res.Append(Environment.NewLine);
            res.AppendFormat(" *Health: {0}", this.HealthPoints);
            res.Append(Environment.NewLine);
            res.AppendFormat(" *Attack: {0}", this.attackPoints);
            res.Append(Environment.NewLine);
            res.AppendFormat(" *Defense: {0}", this.defencePoints);
            res.Append(Environment.NewLine);
            res.AppendFormat(" *Targets: ");
            if (this.Targets.Count > 0)
            {
                foreach (var target in this.Targets)
                {
                    res.AppendFormat("{0}, ", target);
                }
                res.Remove(res.Length - 2, 2);
            }
            else
            {
                res.Append("None");
            }
            res.Append(Environment.NewLine);
            if (this.stealthMode == true)
            {
                res.Append(" *Stealth: ON");
            }

            else
            {
                res.Append(" *Stealth: OFF");
            }

            return res.ToString();
        }
    }
}
