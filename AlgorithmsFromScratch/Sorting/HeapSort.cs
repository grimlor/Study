﻿using System.Linq;
using System;
using System.Collections.Generic;
using CollectionsFromScratch;

namespace AlgorithmsFromScratch.Sorting
{
    public static class HeapSort<TValue> where TValue : IComparable<TValue>
    {
        public static void Sort(IList<TValue> values)
        {
            bool isArray = values.GetType().IsArray;

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
    }
}
