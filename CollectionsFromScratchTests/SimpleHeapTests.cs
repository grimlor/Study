using CollectionsFromScratch;
using CollectionsFromScratch.Heaps;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CollectionsFromScratchTests
{
    [TestClass]
    public class SimpleHeapTests
    {
        [TestMethod]
        public void CanInitializeHeapWithArray()
        {
            var testData = new[] { 5, 4, 3, 2, 1 };

            IHeap<int> minHeap = new SimpleHeap<int>(testData);
        }

        [TestMethod]
        public void WillNotExceedMaxCount()
        {
            var testData = new[] { 5, 4, 3, 2, 1 };

            int k = 3;
            IHeap<int> kSmallestHeap = new SimpleHeap<int>(k, HeapType.MaxHeap);

            foreach (var item in testData)
            {
                kSmallestHeap.Insert(item);
            }

            for (int i = 2; i < kSmallestHeap.Count; i++)
            {
                Assert.AreEqual(testData[i], kSmallestHeap.Pop());
            }
        }
    }
}
