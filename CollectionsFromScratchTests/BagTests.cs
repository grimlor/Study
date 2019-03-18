using System;
using System.Linq;
using CollectionsFromScratch;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CollectionsFromScratchTests
{
    [TestClass]
    public class BagTests
    {
        [TestMethod]
        public void AddedItemsAreFoundInBag()
        {
            var items = new int[] { 1, 2, 3, 4, 5, 0, 9, 8, 7, 6 };

            var bag = new Bag<int>();

            Assert.IsTrue(bag.IsEmpty);

            foreach (var item in items)
            {
                bag.Add(item);
            }

            Assert.AreEqual(items.Length, bag.Count);

            foreach (var item in items)
            {
                Assert.IsTrue(bag.Contains(item));
            }
        }
    }
}