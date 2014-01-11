using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarMachines.Interfaces;
namespace WarMachines.Machines
{
    public class Tank: Machine, ITank
    {
        private bool defenceMode;

        public Tank(string name, double attackPoints, double defencePoints, IPilot pilot = null)
            : base(name, 100, attackPoints, defencePoints, pilot = null)
        {
            ToggleDefenseMode();
        }

        public bool DefenseMode
        {
            get { return this.defenceMode; }
        }

        public void ToggleDefenseMode()
        {
            if (this.defenceMode == true)
            {
                this.defencePoints -= 30;
                this.attackPoints += 40;
                this.defenceMode = false;
            }
            else
            {
                this.defencePoints += 30;
                this.attackPoints -= 40;
                this.defenceMode = true;
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
            if (this.defenceMode == true)
            {
                res.AppendLine(" *Defense: ON");
            }

            else
            {
                res.AppendLine(" *Defense: OFF");
            }

            return res.ToString();
        }
    }
}
