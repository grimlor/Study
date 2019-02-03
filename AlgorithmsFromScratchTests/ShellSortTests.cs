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
        public void SortsAscending()
        {
            IList<int> values = SortTestUtils.CreateRandomizedListOfValues();

            values.SortAndAssertCorrectness(typeof(ShellSort));
        }

        [TestMethod]
        public void SortsDescending()
        {
            IList<int> values = SortTestUtils.CreateRandomizedListOfValues();

            values.SortAndAssertCorrectness(typeof(ShellSort), SortOrder.Descending);
        }
    }
}