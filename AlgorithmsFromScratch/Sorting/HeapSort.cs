using System;
using System.Collections.Generic;
using CollectionsFromScratch;

namespace AlgorithmsFromScratch.Sorting
{
    public static class HeapSort
    {
        public static void SortWithHeap<TValue>(IList<TValue> values) where TValue : IComparable<TValue>
        {
            IHeap<TValue> heap = new Heap<TValue>();

            foreach (TValue value in values)
            {
                heap.Insert(value);
            }

            int i = 0;
            while (!heap.IsEmpty())
            {
                values[i++] = heap.Pop();
            }
        }

        public static void Sort<TValue>(IList<TValue> values, SortOrder sortOrder = SortOrder.Ascending) where TValue : IComparable<TValue>
        {
            Heapify(values, sortOrder);
            SortDown(values, sortOrder);
        }

        static void SortDown<TValue>(IList<TValue> values, SortOrder sortOrder) where TValue : IComparable<TValue>
        {
            int haltIdx = values.Count - 1;
            while (haltIdx > 0)
            {
                Swap(values, 0, haltIdx--);
                Sink(values, 0, haltIdx, sortOrder);
            }
        }

        static void Heapify<TValue>(IList<TValue> values, SortOrder sortOrder) where TValue : IComparable<TValue>
        {
            int parentIdx = values.Count / 2 - 1;
            while (parentIdx >= 0)
            {
                Sink(values, parentIdx, sortOrder);
                parentIdx--;
            }
        }

        static void Sink<TValue>(IList<TValue> values, int parentIdx, SortOrder sortOrder) where TValue : IComparable<TValue>
        {
            Sink(values, parentIdx, values.Count - 1, sortOrder);
        }

        static void Sink<TValue>(IList<TValue> values, int parentIdx, int haltIdx, SortOrder sortOrder) where TValue : IComparable<TValue>
        {
            while (2 * parentIdx + 1 <= haltIdx)
            {
                int childIdx = 2 * parentIdx + 1;
                if (childIdx + 1 <= haltIdx && ShouldSwap(values, childIdx, childIdx + 1, sortOrder)) { childIdx++; }
                if (!ShouldSwap(values, parentIdx, childIdx, sortOrder)) { break; }
                Swap(values, parentIdx, childIdx);
                parentIdx = childIdx;
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
