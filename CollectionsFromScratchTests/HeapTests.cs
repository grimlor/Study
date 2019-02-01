using System;
using System.Collections.Generic;
using CollectionsFromScratch;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CollectionsFromScratchTests
{
    [TestClass]
    public class HeapTests
    {
        [TestMethod]
        public void CanInitializeHeapWithArray()
        {
            var testData = new[] { 5, 4, 3, 2, 1 };

            IHeap<int> minHeap = new Heap<int>(testData);
        }

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
        public void WillNotExceedMaxCount()
        {
            var testData = new[] { 5, 4, 3, 2, 1 };

            int k = 3;
            IHeap<int> kSmallestHeap = new Heap<int>(k, HeapType.MaxHeap);

            foreach (var item in testData)
            {
                kSmallestHeap.Insert(item);
            }

            for (int i = 2; i < kSmallestHeap.Count; i++)
            {
                Assert.AreEqual(testData[i], kSmallestHeap.Pop());
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
        public void CountIsCorrect()
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
        public void HeapSortsCorrectly()
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

        [TestMethod]
        public void SortUsingHeapWorks()
        {
            List<int> values = this.CreateRandomizedListOfValues();

            IHeap<int> minHeap = new Heap<int>(values);
            AssertMinToMax(minHeap);

            IHeap<int> maxHeap = new Heap<int>(values, HeapType.MaxHeap);
            AssertMaxToMin(maxHeap);
        }

        void AssertMinToMax(IHeap<int> minHeap)
        {
            int currentValue = minHeap.Pop();
            for (int i = 1; i < minHeap.Count; i++)
            {
                int nextValue = minHeap.Pop();
                Assert.IsTrue(currentValue <= nextValue);
                currentValue = nextValue;
            }
        }

        void AssertMaxToMin(IHeap<int> maxHeap)
        {
            int currentValue = maxHeap.Pop();
            for (int i = 1; i < maxHeap.Count; i++)
            {
                int nextValue = maxHeap.Pop();
                Assert.IsTrue(currentValue >= nextValue);
                currentValue = nextValue;
            }
        }

        List<int> CreateRandomizedListOfValues(int maxSize = 10)
        {
            var values = new List<int>();

            var rnd = new Random();

            for (int i = 0; i < maxSize; i++)
            {
                values.Add(rnd.Next());
            }

            return values;
        }
    }
}
