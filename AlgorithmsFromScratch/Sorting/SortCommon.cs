using System;
using System.Collections.Generic;

namespace AlgorithmsFromScratch.Sorting
{
    internal static class SortCommon
    {
        internal static bool ShouldSwap<TValue>(IList<TValue> values, int i, int j, SortOrder sortOrder) where TValue : IComparable<TValue>
        {
            return sortOrder == SortOrder.Ascending ? Lesser(values, i, j) : Greater(values, i, j);
        }

        internal static bool Lesser<TValue>(IList<TValue> values, int i, int j) where TValue : IComparable<TValue>
        {
            return values[i].CompareTo(values[j]) < 0;
        }

        internal static bool Greater<TValue>(IList<TValue> values, int i, int j) where TValue : IComparable<TValue>
        {
            return values[i].CompareTo(values[j]) > 0;
        }

        internal static void Swap<TValue>(IList<TValue> values, int i, int j)
        {
            var tmp = values[i];
            values[i] = values[j];
            values[j] = tmp;
        }
    }
}