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
                    for (int j = i; j >= h && ShouldSwap(values, j, j - h, sortOrder); j -= h)
                    {
                        Swap(values, j, j - h);
                    }
                }
                h /= 3;
            }
        }

        static bool ShouldSwap<TValue>(IList<TValue> values, int i, int j, SortOrder sortOrder) where TValue : IComparable<TValue>
        {
            return sortOrder == SortOrder.Ascending ? Lesser(values, i, j) : Greater(values, i, j);
        }

        static bool Lesser<TValue>(IList<TValue> values, int i, int j) where TValue : IComparable<TValue>
        {
            return values[i].CompareTo(values[j]) < 0;
        }

        static bool Greater<TValue>(IList<TValue> values, int i, int j) where TValue : IComparable<TValue>
        {
            return values[i].CompareTo(values[j]) > 0;
        }

        static void Swap<TValue>(IList<TValue> values, int i, int j)
        {
            var tmp = values[i];
            values[i] = values[j];
            values[j] = tmp;
        }
    }
}