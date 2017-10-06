using System.Collections.Generic;

namespace Prophet.Core.Items
{
    public class Inventory
    {
        public List<Item> PassiveItems { get; set; } 
            = new List<Item>();



        public virtual void Take(Inventory from, Item item)
        {
            from.PassiveItems.Remove(item);
            PassiveItems.Add(item);
        }
    }
}