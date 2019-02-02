using System;
using System.Collections.Generic;

namespace AlgorithmsFromScratch.Sorting
{
    public static class InsertionSort<TValue> where TValue : IComparable<TValue>
    {
        public static void Sort(IList<TValue> values, SortOrder sortOrder = SortOrder.Ascending)
        {
            for (int i = 0; i < values.Count - 1; i++)
            {
                for (int j = i + 1; j > 0 && ShouldSwap(values, j, j - 1, sortOrder); j--)
                {
                    Swap(values, j, j - 1);
                }
            }
        }

        static bool ShouldSwap(IList<TValue> values, int i, int j, SortOrder sortOrder)
        {
            return sortOrder == SortOrder.Ascending ? Lesser(values, i, j) : Greater(values, i, j);
        }

        static bool Lesser(IList<TValue> values, int i, int j)
        {
            return values[i].CompareTo(values[j]) < 0;
        }

        static bool Greater(IList<TValue> values, int i, int j)
        {
            return values[i].CompareTo(values[j]) > 0;
        }

        static void Swap(IList<TValue> values, int i, int j)
        {
            var tmp = values[i];
            values[i] = values[j];
            values[j] = tmp;
        }
    }
}