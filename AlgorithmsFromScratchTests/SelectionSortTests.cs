using System.Collections.Generic;
using AlgorithmsFromScratch.Sorting;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgorithmsFromScratchTests
{
    [TestClass]
    public class SelectionSortTests
    {
        [TestMethod]
        public void SelectionSortSortsAscending()
        {
            IList<int> values = SortTestUtils.CreateRandomizedListOfValues();

            SelectionSort<int>.Sort(values);

            values.AssertMinToMax();
        }

        [TestMethod]
        public void SelectionSortSortsDescending()
        {
            IList<int> values = SortTestUtils.CreateRandomizedListOfValues();

            SelectionSort<int>.Sort(values, SortOrder.Descending);

            values.AssertMaxToMin();
        }
    }
}