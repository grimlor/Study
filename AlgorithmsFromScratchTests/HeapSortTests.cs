using System;
using System.Collections.Generic;
using AlgorithmsFromScratch.Sorting;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgorithmsFromScratchTests
{
    [TestClass]
    public class HeapSortTests
    {
        [TestMethod]
        public void SortWithHeapListSortsMinToMax()
        {
            List<int> values = this.CreateRandomizedListOfValues();

            HeapSort<int>.SortWithHeap(values);

            AssertMinToMax(values);
        }

        [TestMethod]
        public void SortWithHeapArraySortsMinToMax()
        {
            int[] values = this.CreateRandomizedListOfValues().ToArray();

            HeapSort<int>.SortWithHeap(values);

            AssertMinToMax(values);
        }

        void AssertMinToMax(IList<int> values)
        {
            int currentValue = values[0];
            for (int i = 1; i < values.Count; i++)
            {
                int nextValue = values[i];
                Assert.IsTrue(currentValue <= nextValue);
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
