using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgorithmsFromScratchTests
{
    public static class SortTestUtils
    {

        public static void AssertMinToMax(this IList<int> values)
        {
            int currentValue = values[0];
            for (int i = 1; i < values.Count; i++)
            {
                int nextValue = values[i];
                Assert.IsTrue(currentValue <= nextValue);
                currentValue = nextValue;
            }
        }

        public static void AssertMaxToMin(this IList<int> values)
        {
            int currentValue = values[0];
            for (int i = 1; i < values.Count; i++)
            {
                int nextValue = values[i];
                Assert.IsTrue(currentValue >= nextValue);
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