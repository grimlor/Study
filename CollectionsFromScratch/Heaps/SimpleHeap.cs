using System;
using System.Collections.Generic;
using System.Linq;
using CollectionsFromScratch.Lists;

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

        public SimpleHeap(int maxCount, HeapType heapType) : base(maxCount, heapType)
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

        int maxCount = -1;

        public int Count => this.heap.Count;

        Func<int, int, bool> ShouldSwap;

        public SimpleHeap() : this(HeapType.MinHeap)
        {
        }

        public SimpleHeap(HeapType heapType)
        {
            this.heap = new ArrayList<KeyValuePair<TPriority, TValue>>();

            this.SetShouldSwapFunction(heapType);
        }

        public SimpleHeap(int maxCount) : this(maxCount, HeapType.MinHeap)
        {
        }

        public SimpleHeap(int maxCount, HeapType heapType)
        {
            this.heap = new ArrayList<KeyValuePair<TPriority, TValue>>();

            this.maxCount = maxCount;

            this.SetShouldSwapFunction(heapType);
        }

        public SimpleHeap(IList<KeyValuePair<TPriority, TValue>> values) : this(values, HeapType.MinHeap)
        {
        }

        public SimpleHeap(IList<KeyValuePair<TPriority, TValue>> values, HeapType heapType)
        {
            this.heap = values.ToList();

            this.SetShouldSwapFunction(heapType);

            this.Heapify();
        }

        public void Insert(TPriority priority, TValue value)
        {
            this.heap.Add(new KeyValuePair<TPriority, TValue>(priority, value));

            this.Swim(this.Count - 1);

            if (this.maxCount > 0 && this.Count > this.maxCount)
            {
                this.heap.RemoveAt(0);
                this.Heapify();
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
            this.Sink(0);

            return returnVal;
        }

        void Sink(int parentIdx)
        {
            while (2 * parentIdx + 1 < this.Count)
            {
                int childIdx = 2 * parentIdx + 1;
                if (childIdx + 1 < this.Count && this.ShouldSwap(childIdx, childIdx + 1)) { childIdx++; }
                if (!this.ShouldSwap(parentIdx, childIdx)) { break; }
                this.Swap(parentIdx, childIdx);
                parentIdx = childIdx;
            }
        }

        void Swim(int childIdx)
        {
            while (childIdx > 0)
            {
                int parentIdx = (childIdx - 1) / 2;
                if (!this.ShouldSwap(parentIdx, childIdx))
                {
                    break;
                }
                this.Swap(parentIdx, childIdx);
                childIdx = parentIdx;
            }
        }

        void Heapify()
        {
            int parentIdx = this.Count / 2 - 1;
            while (parentIdx >= 0)
            {
                this.Sink(parentIdx);
                parentIdx--;
            }
        }

        void SetShouldSwapFunction(HeapType heapType)
        {
            if (heapType == HeapType.MinHeap)
            {
                this.ShouldSwap = this.MinEval;
            }
            else
            {
                this.ShouldSwap = this.MaxEval;
            }
        }

        bool MinEval(int i, int j)
        {
            return this.heap[i].Key.CompareTo(this.heap[j].Key) > 0;
        }

        bool MaxEval(int i, int j)
        {
            return this.heap[i].Key.CompareTo(this.heap[j].Key) < 0;
        }

        void Swap(int i, int j)
        {
            var tmp = this.heap[i];
            this.heap[i] = this.heap[j];
            this.heap[j] = tmp;
        }
    }
}
