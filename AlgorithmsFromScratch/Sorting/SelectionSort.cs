using System;
using System.Collections.Generic;

namespace AlgorithmsFromScratch.Sorting
{
    public static class SelectionSort<TValue> where TValue : IComparable<TValue>
    {
        public static void Sort(IList<TValue> values, SortOrder sortOrder = SortOrder.Ascending)
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

        static bool ShouldSwap(IList<TValue> values, int i, int j, SortOrder sortOrder)
        {
            return sortOrder == SortOrder.Ascending ? MaxEval(values, i, j) : MinEval(values, i, j);
        }

        static bool MinEval(IList<TValue> values, int i, int j)
        {
            return values[i].CompareTo(values[j]) < 0;
        }

        static bool MaxEval(IList<TValue> values, int i, int j)
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