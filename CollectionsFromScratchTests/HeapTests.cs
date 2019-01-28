using CollectionsFromScratch;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CollectionsFromScratchTests
{
    [TestClass]
    public class HeapTests
    {
        [TestMethod]
        public void CanAddToHeap()
        {
            var testData = new [] { 5, 4, 3, 2, 1 };
            
            IHeap<int> minHeap = new Heap<int>();
            IHeap<int> maxHeap = new Heap<int>(HeapType.MaxHeap);

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
            
            IHeap<int> minHeap = new Heap<int>();
            IHeap<int> maxHeap = new Heap<int>(HeapType.MaxHeap);

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

            IHeap<int> minHeap = new Heap<int>();
            Assert.IsTrue(minHeap.IsEmpty());

            IHeap<int> maxHeap = new Heap<int>(HeapType.MaxHeap);
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

            IHeap<int> minHeap = new Heap<int>();
            IHeap<int> maxHeap = new Heap<int>(HeapType.MaxHeap);

            for (int i = 0; i < testData.Length; i++)
            {
                Assert.AreEqual(i, minHeap.Count);
                minHeap.Insert(testData[i]);

                Assert.AreEqual(i, maxHeap.Count);
                maxHeap.Insert(testData[i]);
            }

            Assert.AreEqual(testData.Length, minHeap.Count);
            Assert.AreEqual(testData.Length, maxHeap.Count);
        }

        [TestMethod]
        public void HeapSortWorks()
        {
            var testData = new [] { 5, 4, 3, 2, 1 };
            
            IHeap<int> minHeap = new Heap<int>();
            IHeap<int> maxHeap = new Heap<int>(HeapType.MaxHeap);

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
