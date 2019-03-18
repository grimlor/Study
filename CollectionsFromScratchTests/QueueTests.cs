using System;
using System.Linq;
using CollectionsFromScratch;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace CollectionsFromScratchTests
{
    [TestClass]
    public class QueueTests
    {
        [TestMethod]
        public void QueueIsFIFO()
        {
            var items = new int[] { 1, 2, 3, 4, 5, 0, 9, 8, 7, 6 };

            var queue = new Queue<int>();

            Assert.IsTrue(queue.IsEmpty);

            foreach (var item in items)
            {
                queue.Enqueue(item);
            }

            Assert.AreEqual(items.Length, queue.Count);

            foreach (var expected in items)
            {
                var actual = queue.Dequeue();

                Assert.AreEqual(expected, actual);
            }
        }

        [TestMethod]
        public void CanIterateOverQueueWithoutChangingIt()
        {
            var items = new int[] { 1, 2, 3, 4, 5, 0, 9, 8, 7, 6 };

            var queue = new Queue<int>();

            Assert.IsTrue(queue.IsEmpty);

            foreach (var item in items)
            {
                queue.Enqueue(item);
            }

            Assert.AreEqual(items.Length, queue.Count);

            int i = 0;
            foreach (var actual in queue)
            {
                Assert.AreEqual(items[i++], actual);
            }

            Assert.AreEqual(items.Length, queue.Count);
        }
    }
}
