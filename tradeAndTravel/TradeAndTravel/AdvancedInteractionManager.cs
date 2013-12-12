using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeAndTravel
{
    public class AdvancedInteractionManager : InteractionManager
    {
        protected override Item CreateItem(string itemTypeString, string itemNameString, Location itemLocation, Item item)
        {
            switch (itemTypeString)
            {
                case "weapon":
                    {
                        item = new Weapon(itemNameString, itemLocation);
                        return item;
                    }
                case "wood":
                    {
                        item = new Wood(itemNameString, itemLocation);
                        return item;
                    }
                case "iron":
                    {
                        item = new Iron(itemNameString, itemLocation);
                        return item;
                    }

                default:
                    {
                        return base.CreateItem(itemTypeString, itemNameString, itemLocation, item);
                    }
            }
        }

        protected override Location CreateLocation(string locationTypeString, string locationName)
        {
            Location location = null;
            switch (locationTypeString)
            {
                case "mine":
                    {
                        location = new Mine(locationName);
                        return location;
                    }
                case "forest":
                    {
                        location = new Forest(locationName);
                        return location;
                    }
                default:
                    {
                        return base.CreateLocation(locationTypeString, locationName);
                    }
            }
        }

        protected override Person CreatePerson(string personTypeString, string personNameString, Location personLocation)
        {
            Person person = null;
            switch (personTypeString)
            {
                case "merchant":
                    {
                        person = new Merchant(personNameString, personLocation);
                        return person;
                    }
                default:
                    {
                        return base.CreatePerson(personTypeString, personNameString, personLocation);
                    }
            }
        }

        protected override void HandlePersonCommand(string[] commandWords, Person actor)
        {
            switch (commandWords[1])
            {
                case "gather":
                    {
                        HandleGatherCommand(commandWords, actor);
                        break;
                    }
                case "craft":
                    {
                        HandleCraftCommand(commandWords, actor);
                        break;
                    }
                    
                default:
                    base.HandlePersonCommand(commandWords, actor);
                    break;
            }
        
        }


        private void HandleCraftCommand(string[] commandWords, Person actor)
        {
            if (commandWords[2] == "armor")
            {
                foreach (var item in actor.ListInventory())
                {
                    if ((item as Iron) != null)
                    {
                        this.AddToPerson(actor, new Armor(commandWords[3]));
                        Console.WriteLine("craftedArmor");
                        break;
                    }
                }
            }
            else if (commandWords[2] == "weapon")
            {
                bool hasIron = false;
                bool hasWood = false;
                foreach (var item in actor.ListInventory())
                {
                    if ((item as Iron) != null)
                    {
                        hasIron = true;
                    }
                    if (item is Wood)
                    {
                        hasWood = true;
                    }
                    if (hasIron && hasWood)
                    {
                        this.AddToPerson(actor, new Weapon(commandWords[3]));
                        Console.WriteLine("craftedWeapon");
                        break;
                    }
                }
            }
        }

        private void HandleGatherCommand(string[] commandWords, Person actor)
        {
            if (actor.Location.LocationType == LocationType.Forest)
            {
                foreach (var item in actor.ListInventory())
                {
                    if ((item as Weapon)!= null )
                    {
                        Wood wood = new Wood(commandWords[2]);
                        this.AddToPerson(actor, wood);
                        Console.WriteLine("gatheredAt" + actor.Location.Name);
                        break;
                    }
                }
            }
            else if (actor.Location.LocationType == LocationType.Mine)
            {
                foreach (var item in actor.ListInventory())
                {
                    if ((item as Armor) != null)
                    {
                        Iron iron = new Iron(commandWords[2]);
                        this.AddToPerson(actor, iron);
                        Console.WriteLine("gatheredAt" + actor.Location.Name);
                        break;
                    }
                }
            }
        }

        protected override void HandlePersonCreation(string personTypeString, string personNameString, string personLocationString)
        {
            base.HandlePersonCreation(personTypeString, personNameString, personLocationString);
        }
    }
}
