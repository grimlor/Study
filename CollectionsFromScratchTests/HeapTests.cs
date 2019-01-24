using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Study.CollectionsFromScratch;

namespace Study.CollectionsFromScratch.Tests
{
    [TestClass]
    public class HeapTests
    {
        [TestMethod]
        public void CanAddToHeap()
        {
            var testData = new [] { 5, 4, 3, 2, 1 };
            
            IHeap<int> minHeap = new MinHeap<int>();
            IHeap<int> maxHeap = new MaxHeap<int>();

            foreach (var item in testData)
            {
                minHeap.Insert(item);
                maxHeap.Insert(item);
            }
        }

        [TestMethod]
        public void CanPeekIntoHeap()
        {
            var testData = new [] { 5, 4, 3, 2, 1 };
            
            IHeap<int> minHeap = new MinHeap<int>();
            IHeap<int> maxHeap = new MaxHeap<int>();

            foreach (var item in testData)
            {
                minHeap.Insert(item);
                maxHeap.Insert(6 - item);
            }

            Assert.AreEqual(1, minHeap.Peek());
            Assert.AreEqual(5, maxHeap.Peek());
        }

        [TestMethod]
        public void CanCheckIfHeapIsEmpty()
        {
            var testData = new [] { 5, 4, 3, 2, 1 };

            IHeap<int> minHeap = new MinHeap<int>();
            Assert.IsTrue(minHeap.IsEmpty());

            IHeap<int> maxHeap = new MaxHeap<int>();
            Assert.IsTrue(maxHeap.IsEmpty());

            foreach (var item in testData)
            {
                minHeap.Insert(item);
                Assert.IsFalse(minHeap.IsEmpty());

                maxHeap.Insert(item);
                Assert.IsFalse(maxHeap.IsEmpty());
            }
        }

        [TestMethod]
        public void SizeIsCorrect()
        {
            var testData = new [] { 5, 4, 3, 2, 1 };

            IHeap<int> minHeap = new MinHeap<int>();
            IHeap<int> maxHeap = new MaxHeap<int>();

            for (int i = 0; i < testData.Length; i++)
            {
                Assert.AreEqual(i, minHeap.Size);
                minHeap.Insert(testData[i]);

                Assert.AreEqual(i, maxHeap.Size);
                maxHeap.Insert(testData[i]);
            }

            Assert.AreEqual(testData.Length, minHeap.Size);
            Assert.AreEqual(testData.Length, maxHeap.Size);
        }

        [TestMethod]
        public void HeapSortWorks()
        {
            var testData = new [] { 5, 4, 3, 2, 1 };
            
            IHeap<int> minHeap = new MinHeap<int>();
            IHeap<int> maxHeap = new MaxHeap<int>();

            foreach (var item in testData)
            {
                minHeap.Insert(item);
                maxHeap.Insert(item);
            }

            for (int i = 1; i <= testData.Length; i++)
            {
                Assert.AreEqual(i, minHeap.Pop());
                Assert.AreEqual(6 - i, maxHeap.Pop());
            }
        }
    }
}
