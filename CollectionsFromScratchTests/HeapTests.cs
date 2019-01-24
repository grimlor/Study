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
            foreach (var item in testData)
            {
                minHeap.Insert(item);
            }
        }

        [TestMethod]
        public void CanPeekIntoHeap()
        {
            var testData = new [] { 5, 4, 3, 2, 1 };
            
            IHeap<int> minHeap = new MinHeap<int>();
            foreach (var item in testData)
            {
                minHeap.Insert(item);
            }

            var actual = minHeap.Peek();

            Assert.AreEqual(1, minHeap.Peek());
        }

        [TestMethod]
        public void CanCheckIfHeapIsEmpty()
        {
            var testData = new [] { 5, 4, 3, 2, 1 };

            IHeap<int> minHeap = new MinHeap<int>();

            Assert.IsTrue(minHeap.IsEmpty());

            foreach (var item in testData)
            {
                minHeap.Insert(item);

                Assert.IsFalse(minHeap.IsEmpty());
            }
        }

        [TestMethod]
        public void SizeIsCorrect()
        {
            var testData = new [] { 5, 4, 3, 2, 1 };

            IHeap<int> minHeap = new MinHeap<int>();

            for (int i = 0; i < testData.Length; i++)
            {
                Assert.AreEqual(i, minHeap.Size);

                minHeap.Insert(testData[i]);
            }

            Assert.AreEqual(testData.Length, minHeap.Size);
        }

        [TestMethod]
        public void HeapSortWorks()
        {
            var testData = new [] { 5, 4, 3, 2, 1 };
            
            IHeap<int> minHeap = new MinHeap<int>();
            foreach (var item in testData)
            {
                minHeap.Insert(item);
            }

            for (int i = 1; i <= testData.Length; i++)
            {
                Assert.AreEqual(i, minHeap.Pop());
            }
        }
    }
}
