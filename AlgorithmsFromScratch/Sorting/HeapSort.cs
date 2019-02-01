using System;
using System.Collections.Generic;
using CollectionsFromScratch;

namespace AlgorithmsFromScratch.Sorting
{
    public static class HeapSort<TValue> where TValue : IComparable<TValue>
    {
        public static void SortWithHeap(IList<TValue> values)
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

        public static void Sort(IList<TValue> values, SortOrder sortOrder = SortOrder.Ascending)
        {
            Heapify(values, sortOrder);
            SortDown(values, sortOrder);
        }

        static void SortDown(IList<TValue> values, SortOrder sortOrder)
        {
            int haltIdx = values.Count - 1;
            while (haltIdx > 0)
            {
                Swap(values, 0, haltIdx--);
                Sink(values, 0, haltIdx, sortOrder);
            }
        }

        static void Heapify(IList<TValue> values, SortOrder sortOrder)
        {
            int parentIdx = values.Count / 2 - 1;
            while (parentIdx >= 0)
            {
                Sink(values, parentIdx, sortOrder);
                parentIdx--;
            }
        }

        static void Sink(IList<TValue> values, int parentIdx, SortOrder sortOrder)
        {
            Sink(values, parentIdx, values.Count - 1, sortOrder);
        }

        static void Sink(IList<TValue> values, int parentIdx, int haltIdx, SortOrder sortOrder)
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

        static bool ShouldSwap(IList<TValue> values, int i, int j, SortOrder sortOrder)
        {
            return sortOrder == SortOrder.Ascending ? MaxEval(values, i, j) : MinEval(values, i, j);
        }

        static bool MinEval(IList<TValue> values, int i, int j)
        {
            return values[i].CompareTo(values[j]) > 0;
        }

        static bool MaxEval(IList<TValue> values, int i, int j)
        {
            return values[i].CompareTo(values[j]) < 0;
        }

        static void Swap(IList<TValue> values, int i, int j)
        {
            var tmp = values[i];
            values[i] = values[j];
            values[j] = tmp;
        }
    }
}
