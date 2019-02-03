using System;
using System.Collections.Generic;

namespace AlgorithmsFromScratch.Sorting
{
    public static class MergeSort
    {
        public static void Sort<TValue>(IList<TValue> values, SortOrder sortOrder = SortOrder.Ascending) where TValue : IComparable<TValue>
        {
            TValue[] aux = new TValue[values.Count];
            Sort(values, 0, values.Count - 1, sortOrder, aux);
        }

        static void Sort<TValue>(IList<TValue> values, int lo, int hi, SortOrder sortOrder, TValue[] aux)
            where TValue : IComparable<TValue>
        {
            if (hi <= lo) { return; }
            int mid = lo + (hi - lo) / 2;
            Sort(values, lo, mid, sortOrder, aux);
            Sort(values, mid + 1, hi, sortOrder, aux);
            Merge(values, lo, mid, hi, sortOrder, aux);
        }

        static void Merge<TValue>(IList<TValue> values, int lo, int mid, int hi, SortOrder sortOrder, TValue[] aux)
            where TValue : IComparable<TValue>
        {
            int i = lo, j = mid + 1;

            for (int k = lo; k <= hi; k++)
            {
                aux[k] = values[k];
            }

            for (int k = lo; k <= hi; k++)
            {
                if      (i > mid)                        { values[k] = aux[j++]; }
                else if (j > hi)                         { values[k] = aux[i++]; }
                else if (TakeLeft(aux, i, j, sortOrder)) { values[k] = aux[i++]; }
                else                                     { values[k] = aux[j++]; }

            }
        }

        static bool TakeLeft<TValue>(IList<TValue> values, int i, int j, SortOrder sortOrder) where TValue : IComparable<TValue>
        {
            return SortCommon.ShouldSwap(values, i, j, sortOrder);
        }
    }
}