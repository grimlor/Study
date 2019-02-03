using System.Collections.Generic;
using AlgorithmsFromScratch.Sorting;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgorithmsFromScratchTests
{
    [TestClass]
    public class SelectionSortTests
    {
        [TestMethod]
        public void SortsAscending()
        {
            IList<int> values = SortTestUtils.CreateRandomizedListOfValues();

            values.SortAndAssertCorrectness(typeof(SelectionSort));
        }

        [TestMethod]
        public void SortsDescending()
        {
            IList<int> values = SortTestUtils.CreateRandomizedListOfValues();

            values.SortAndAssertCorrectness(typeof(SelectionSort), SortOrder.Descending);
        }
    }
}