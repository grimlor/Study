using System;
using System.Collections.Generic;
using AlgorithmsFromScratch.Sorting;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgorithmsFromScratchTests
{
    public static class SortTestUtils
    {

        public static void SortAndAssertCorrectness<TValue>(
            this IList<TValue> values, Type sortType, SortOrder sortOrder = SortOrder.Ascending)
            where TValue : IComparable<TValue>
        {
            var sorted = new List<TValue>(values);

            var sortMethodInfo = sortType.GetMethod("Sort").MakeGenericMethod(new [] { typeof(TValue) });
            sortMethodInfo.Invoke(null, new object[] { sorted, sortOrder });

            for (int i = 0; i < values.Count - 1; i++)
            {
                Assert.IsTrue(sorted.Contains(values[i]));

                AssertCorrectOrder(sorted, i, i + 1, sortOrder);
            }

            Assert.IsTrue(sorted.Contains(values[values.Count - 1]));
        }

        static void AssertCorrectOrder<TValue>(IList<TValue> values, int i, int j, SortOrder sortOrder)
            where TValue : IComparable<TValue>
        {
            Assert.IsTrue(SortCommon.ShouldSwap(values, i, j, sortOrder));
        }

        public static IEnumerable<int> CreateRandomizedEnumerableOfValues(int maxSize = 10)
        {
            var rnd = new Random();

            for (int i = 0; i < maxSize; i++)
            {
                yield return rnd.Next();
            }
        }

        public static IList<int> CreateRandomizedListOfValues(int maxSize = 10)
        {
            IList<int> values = new List<int>();

            foreach (var value in CreateRandomizedEnumerableOfValues())
            {
                values.Add(value);
            }

            return values;
        }
    }
}