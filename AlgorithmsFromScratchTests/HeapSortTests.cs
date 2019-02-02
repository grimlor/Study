using System.Linq;
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
        public void HeapSortSortsAscending()
        {
            IList<int> values = SortTestUtils.CreateRandomizedListOfValues();

            HeapSort<int>.Sort(values);

            values.AssertMinToMax();
        }

        [TestMethod]
        public void HeapSortSortsDescending()
        {
            IList<int> values = SortTestUtils.CreateRandomizedListOfValues();

            HeapSort<int>.Sort(values, SortOrder.Descending);

            values.AssertMaxToMin();
        }

        [TestMethod]
        public void SortWithHeapListSortsMinToMax()
        {
            IList<int> values = SortTestUtils.CreateRandomizedListOfValues();

            HeapSort<int>.SortWithHeap(values);

            values.AssertMinToMax();
        }

        [TestMethod]
        public void SortWithHeapArraySortsMinToMax()
        {
            IList<int> values = SortTestUtils.CreateRandomizedListOfValues();

            HeapSort<int>.SortWithHeap(values);

            values.AssertMinToMax();
        }
    }
}
