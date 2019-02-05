using System;
using System.Collections.Generic;

namespace AlgorithmsFromScratch.Sorting
{
    public class QuickSort
    {
        public static void Sort<TValue>(IList<TValue> values, SortOrder sortOrder = SortOrder.Ascending)
            where TValue : IComparable<TValue>
        {
            Shuffle(values);
            Sort(values, 0, values.Count - 1, sortOrder);
        }

        static void Sort<TValue>(IList<TValue> values, int lo, int hi, SortOrder sortOrder)
            where TValue : IComparable<TValue>
        {
            if (hi <= lo) { return; }
            int j = Partition(values, lo, hi, sortOrder);
            Sort(values, lo, j - 1, sortOrder);
            Sort(values, j + 1, hi, sortOrder);
        }

        static int Partition<TValue>(IList<TValue> values, int lo, int hi, SortOrder sortOrder)
            where TValue : IComparable<TValue>
        {
            int i = lo, j = hi + 1;
            while (true)
            {
                while (SortCommon.ShouldSwap(values, ++i, lo, sortOrder))
                {
                    if (i == hi) { break; }
                }
                while (SortCommon.ShouldSwap(values, lo, --j, sortOrder))
                {
                    if (j == lo) { break; }
                }
                if (i >= j) { break; }
                SortCommon.Swap(values, i, j);
            }
            SortCommon.Swap(values, lo, j);
            return j;
        }

        static void Shuffle<TValue>(IList<TValue> values)
        {
            var rnd = new Random();

            for (int i = 0; i < values.Count; i++)
            {
                var j = rnd.Next(0, values.Count);
                SortCommon.Swap(values, i, j);
            }
        }
    }
}