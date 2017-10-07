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
                        Subject.Inventory.PassiveItems.Select(
                            (item, i) => $"{(i == SelectedItemIndex ? ">" : " ")} {item.Name}"))
                    .ToArray();
        }

        public Character Subject { get; set; }
        
        public int SelectedItemIndex { get; set; }

        public void MoveSelection(int direction)
        {
            if (direction == 0)
            {
                return;
            }

            if (direction > 0)
            {
                SelectedItemIndex = (SelectedItemIndex + 1) % (Subject.Inventory.PassiveItems.Count);
            }
            else
            {
                SelectedItemIndex = (SelectedItemIndex + Subject.Inventory.PassiveItems.Count - 1) %
                                    (Subject.Inventory.PassiveItems.Count);
            }
        }
    }
}