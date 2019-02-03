using System;
using System.Collections.Generic;

namespace AlgorithmsFromScratch.Sorting
{
    public static class SelectionSort
    {
        public static void Sort<TValue>(IList<TValue> values, SortOrder sortOrder = SortOrder.Ascending) where TValue : IComparable<TValue>
        {
            for (int i = 0; i < values.Count - 1; i++)
            {
                int toSwap = i;
                for (int j = i + 1; j < values.Count; j++)
                {
                    toSwap = ShouldSwap(values, toSwap, j, sortOrder) ? j : toSwap;
                }
                SortCommon.Swap(values, i, toSwap);
            }
        }

        static bool ShouldSwap<TValue>(IList<TValue> values, int i, int j, SortOrder sortOrder) where TValue : IComparable<TValue>
        {
            return sortOrder == SortOrder.Ascending ? SortCommon.Greater(values, i, j) : SortCommon.Lesser(values, i, j);
        }
    }
}