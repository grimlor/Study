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
        public void SortsAscending()
        {
            IList<int> values = SortTestUtils.CreateRandomizedListOfValues();

            HeapSort.Sort(values);

            values.AssertMinToMax();
        }

        [TestMethod]
        public void SortsDescending()
        {
            IList<int> values = SortTestUtils.CreateRandomizedListOfValues();

            HeapSort.Sort(values, SortOrder.Descending);

            values.AssertMaxToMin();
        }

        [TestMethod]
        public void SortWithHeapListSortsMinToMax()
        {
            IList<int> values = SortTestUtils.CreateRandomizedListOfValues();

            HeapSort.SortWithHeap(values);

            values.AssertMinToMax();
        }

        [TestMethod]
        public void SortWithHeapArraySortsMinToMax()
        {
            IList<int> values = SortTestUtils.CreateRandomizedListOfValues();

            HeapSort.SortWithHeap(values);

            values.AssertMinToMax();
        }
    }
}
