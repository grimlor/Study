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
                Swap(values, i, toSwap);
            }
        }

        static bool ShouldSwap<TValue>(IList<TValue> values, int i, int j, SortOrder sortOrder) where TValue : IComparable<TValue>
        {
            return sortOrder == SortOrder.Ascending ? Greater(values, i, j) : Lesser(values, i, j);
        }

        static bool Lesser<TValue>(IList<TValue> values, int i, int j) where TValue : IComparable<TValue>
        {
            return values[i].CompareTo(values[j]) < 0;
        }

        static bool Greater<TValue>(IList<TValue> values, int i, int j) where TValue : IComparable<TValue>
        {
            return values[i].CompareTo(values[j]) > 0;
        }

        static void Swap<TValue>(IList<TValue> values, int i, int j) where TValue : IComparable<TValue>
        {
            var tmp = values[i];
            values[i] = values[j];
            values[j] = tmp;
        }
    }
}