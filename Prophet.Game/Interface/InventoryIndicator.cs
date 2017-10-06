using System.Linq;
using Prophet.ConsoleVisualizer.Interface;
using Prophet.Core;

namespace Prophet.Game.Interface
{
    public class InventoryIndicator : Indicator
    {
        protected override string[] GetContent()
        {
            return 
                new[] {$"--- Инвентарь ({Subject.Name}):"}
                    .Concat(
                        Subject.Inventory.PassiveItems.Select(i => i.Name))
                    .ToArray();
        }

        public Character Subject { get; set; }
    }
}