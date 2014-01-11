namespace WarMachines.Engine
{
    using WarMachines.Interfaces;
    using WarMachines.Machines;

    public class MachineFactory : IMachineFactory
    {
        public IPilot HirePilot(string name)
        {
            Pilot p = new Pilot(name);
            return p;
        }

        public ITank ManufactureTank(string name, double attackPoints, double defensePoints)
        {
            Tank t = new Tank(name, attackPoints, defensePoints);
            return t;
        }

        public IFighter ManufactureFighter(string name, double attackPoints, double defensePoints, bool stealthMode)
        {
            Fighter f = new Fighter(name, attackPoints, defensePoints, stealthMode);
            return f;
        }
    }
}
