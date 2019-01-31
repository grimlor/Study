//----------------------------------------------------------------
// <copyright company="Microsoft Corporation">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
//----------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;

namespace CollectionsFromScratch.Heaps
{
    public class SimpleHeap<TValue> : SimpleHeap<TValue, TValue>, IHeap<TValue> where TValue : IComparable<TValue>
    {
        public SimpleHeap() : base()
        {
        }

        public SimpleHeap(int maxCount) : base(maxCount)
        {
        }

        public SimpleHeap(IList<TValue> values)
            : base(values.Select(v => new KeyValuePair<TValue, TValue>(v, v)).ToList())
        {
        }

        public SimpleHeap(IList<TValue> values, HeapType heapType)
            : base(values.Select(v => new KeyValuePair<TValue, TValue>(v, v)).ToList(), heapType)
        {
        }

        public void Insert(TValue value)
        {
            base.Insert(value, value);
        }
    }

    public class SimpleHeap<TPriority, TValue> : IHeap<TPriority, TValue> where TPriority : IComparable<TPriority>
    {
        IList<KeyValuePair<TPriority, TValue>> heap;

        int maxCount;

        public int Count => this.heap.Count;

        Func<KeyValuePair<TPriority, TValue>, bool> ShouldSwap;

        public SimpleHeap() : this(HeapType.MinHeap)
        {
        }

        public SimpleHeap(HeapType heapType)
        {
            this.heap = new List<KeyValuePair<TPriority, TValue>>();

            this.ShouldSwap =
                heapType == HeapType.MinHeap
                ? (Func<KeyValuePair<TPriority, TValue>, bool>)this.MinEval
                : this.MaxEval;
        }

        public SimpleHeap(int maxCount) : this(maxCount, HeapType.MinHeap)
        {
        }

        public SimpleHeap(int maxCount, HeapType heapType)
        {
            this.heap = new List<KeyValuePair<TPriority, TValue>>();

            this.maxCount = maxCount;

            this.ShouldSwap =
                heapType == HeapType.MinHeap
                ? (Func<KeyValuePair<TPriority, TValue>, bool>)this.MinEval
                : this.MaxEval;
        }

        public SimpleHeap(IList<KeyValuePair<TPriority, TValue>> values) : this(values, HeapType.MinHeap)
        {
        }

        public SimpleHeap(IList<KeyValuePair<TPriority, TValue>> values, HeapType heapType)
        {
            this.heap = values.ToList();

            this.ShouldSwap =
                heapType == HeapType.MinHeap
                ? (Func<KeyValuePair<TPriority, TValue>, bool>)this.MinEval
                : this.MaxEval;

            this.Heapify();
        }

        public void Insert(TPriority priority, TValue value)
        {
            this.heap.Add(new KeyValuePair<TPriority, TValue>(priority, value));

            this.Swim();

            if (this.Count > this.maxCount)
            {
                this.heap.RemoveAt(this.Count);
            }
        }

        public bool IsEmpty()
        {
            return this.Count == 0;
        }

        public TValue Peek()
        {
            return this.heap[0].Value;
        }

        public TValue Pop()
        {
            TValue returnVal = Peek();

            this.heap[0] = this.heap[this.Count - 1];
            this.heap.RemoveAt(this.Count - 1);
            this.Sink();

            return returnVal;
        }

        void Sink()
        {
            throw new NotImplementedException();
        }

        void Swim()
        {
            throw new NotImplementedException();
        }

        void Heapify()
        {
            throw new NotImplementedException();
        }

        bool MinEval(KeyValuePair<TPriority, TValue> parent)
        {
            throw new NotImplementedException();
        }

        bool MaxEval(KeyValuePair<TPriority, TValue> parent)
        {
            throw new NotImplementedException();
        }
    }
}
