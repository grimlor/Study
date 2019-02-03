using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgorithmsFromScratchTests
{
    public static class SortTestUtils
    {

        public static void AssertMinToMax<TValue>(this IList<TValue> values) where TValue : IComparable<TValue>
        {
            var currentValue = values[0];
            for (int i = 1; i < values.Count; i++)
            {
                var nextValue = values[i];
                Assert.IsTrue(currentValue.CompareTo(nextValue) <= 0);
                currentValue = nextValue;
            }
        }

        public static void AssertMaxToMin<TValue>(this IList<TValue> values) where TValue : IComparable<TValue>
        {
            var currentValue = values[0];
            for (int i = 1; i < values.Count; i++)
            {
                var nextValue = values[i];
                Assert.IsTrue(currentValue.CompareTo(nextValue) >= 0);
                currentValue = nextValue;
            }
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