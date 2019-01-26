using System.Linq;
using System;
using System.Collections.Generic;
using CollectionsFromScratch;

namespace AlgorithmsFromScratch.Sorting
{
    public static class HeapSort<TValue> where TValue : IComparable<TValue>
    {
        public static void Sort(TValue[] values)
        {
            values = SortInternal(values).ToArray();
        }

        public static void Sort(List<TValue> values)
        {
            values = SortInternal(values).ToList();
        }

        static IList<TValue> SortInternal(IList<TValue> values)
        {
            IHeap<TValue> heap = new Heap<TValue>();
            
            foreach (TValue value in values)
            {
                heap.Insert(value);
            }

            TValue[] result = new TValue[heap.Size];

            for (int i = 0; i < result.Length; i++)
            {
                result[i] = heap.Pop();
            }

            return result;
        }
    }
}
