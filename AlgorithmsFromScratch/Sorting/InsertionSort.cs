using System;
using System.Collections.Generic;

namespace AlgorithmsFromScratch.Sorting
{
    public static class InsertionSort
    {
        public static void Sort<TValue>(IList<TValue> values, SortOrder sortOrder = SortOrder.Ascending) where TValue : IComparable<TValue>
        {
            for (int i = 1; i < values.Count; i++)
            {
                for (int j = i; j > 0 && SortCommon.ShouldSwap(values, j, j - 1, sortOrder); j--)
                {
                    SortCommon.Swap(values, j, j - 1);
                }
            }
        }
    }
}