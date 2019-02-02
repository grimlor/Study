using System;
using System.Collections.Generic;
using AlgorithmsFromScratch.Sorting;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgorithmsFromScratchTests
{
    [TestClass]
    public class ShellSortTests
    {
        [TestMethod]
        public void ShellSortSortsAscending()
        {
            IList<int> values = SortTestUtils.CreateRandomizedListOfValues();

            ShellSort.Sort(values);

            values.AssertMinToMax();
        }

        [TestMethod]
        public void ShellSortSortsDescending()
        {
            IList<int> values = SortTestUtils.CreateRandomizedListOfValues();

            ShellSort.Sort(values, SortOrder.Descending);

            values.AssertMaxToMin();
        }
    }
}