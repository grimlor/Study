using System;
using System.Collections.Generic;

namespace AlgorithmsFromScratch.Sorting
{
    public static class ShellSort
    {
        public static void Sort<TValue>(IList<TValue> values, SortOrder sortOrder = SortOrder.Ascending) where TValue : IComparable<TValue>
        {
            int h = 1;
            while (h < values.Count) { h = 3 * h + 1; }

            while (h >= 1)
            {
                for (int i = h; i < values.Count; i++)
                {
                    for (int j = i; j >= h && SortCommon.ShouldSwap(values, j, j - h, sortOrder); j -= h)
                    {
                        SortCommon.Swap(values, j, j - h);
                    }
                }
                h /= 3;
            }
        }
    }
}