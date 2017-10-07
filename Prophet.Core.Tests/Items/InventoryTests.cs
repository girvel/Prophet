using NUnit.Framework;
using Prophet.Core.Items;

namespace Prophet.Core.Tests.Items
{
    [TestFixture]
    public class InventoryTests
    {
        [Test]
        public void Take_TakesItemFromOtherInventory()
        {
            // arrange
            var inventory = new Inventory();
            var item = new Item();
            var from = new Inventory{PassiveItems = {item}};
            
            // act
            inventory.Take(from, item);
            
            // assert
            Assert.AreEqual(0, from.PassiveItems.Count);
            Assert.AreEqual(item, inventory.PassiveItems[0]);
        }
        
        [Test]
        public void Take_DoesNothingIfItemIsNull()
        {
            // arrange
            var inventory = new Inventory();
            Item item = null;
            Inventory from = null;
            
            // act
            
            // assert
            Assert.DoesNotThrow(() => inventory.Take(from, item));
            Assert.AreEqual(0, inventory.PassiveItems.Count);
        }
    }
}