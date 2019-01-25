using System;

namespace CollectionsFromScratch
{
    public class Heap<TValue> : IHeap<TValue> where TValue : IComparable<TValue>
    {
        IHeap<TValue> heap;

        public Heap() : this(HeapType.MinHeap)
        {
        }

        public Heap(HeapType type)
        {
            switch (type)
            {
                case HeapType.MaxHeap:
                    this.heap = new MaxHeap<TValue>();
                    break;
                default:
                    this.heap = new MinHeap<TValue>();
                    break;
            }
        }

        public int Size { get {return this.heap.Size; } }

        public void Insert(TValue value)
        {
            this.heap.Insert(value);
        }

        public bool IsEmpty()
        {
            return this.heap.IsEmpty();
        }

        public TValue Peek()
        {
            return this.heap.Peek();
        }

        public TValue Pop()
        {
            return this.heap.Pop();
        }
    }

    public class Heap<TPriority, TValue> : IHeap<TPriority, TValue> where TPriority : IComparable<TPriority>
    {
        IHeap<TPriority, TValue> heap;

        public Heap()
        {
        }

        public Heap(HeapType type)
        {
            switch (type)
            {
                case HeapType.MaxHeap:
                    this.heap = new MaxHeap<TPriority, TValue>();
                    break;
                default:
                    this.heap = new MinHeap<TPriority, TValue>();
                    break;
            }
        }

        public int Size { get {return this.heap.Size; } }

        public void Insert(TPriority priority, TValue value)
        {
            this.heap.Insert(priority, value);
        }

        public bool IsEmpty()
        {
            return this.heap.IsEmpty();
        }

        public TValue Peek()
        {
            return this.heap.Peek();
        }

        public TValue Pop()
        {
            return this.heap.Pop();
        }
    }
    
}