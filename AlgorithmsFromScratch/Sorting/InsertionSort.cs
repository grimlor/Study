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
                for (int j = i; j > 0 && ShouldSwap(values, j, j - 1, sortOrder); j--)
                {
                    Swap(values, j, j - 1);
                }
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

        static void Swap<TValue>(IList<TValue> values, int i, int j) where TValue : IComparable<TValue>
        {
            var tmp = values[i];
            values[i] = values[j];
            values[j] = tmp;
        }
    }
}