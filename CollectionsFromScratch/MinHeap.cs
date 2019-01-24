using System;
using System.Collections.Generic;

namespace Study.CollectionsFromScratch
{
    public class MinHeap<TValue> : IHeap<TValue> where TValue : IComparable<TValue>
    {
        MinHeap<TValue, TValue> minHeap;

        public MinHeap()
        {
            this.minHeap = new MinHeap<TValue, TValue>();
        }

        public int Size { get { return this.minHeap.Size; } }

        public bool IsEmpty()
        {
            return this.minHeap.IsEmpty();
        }

        public void Insert(TValue value)
        {
            this.minHeap.Insert(value, value);
        }

        public TValue Peek()
        {
            return this.minHeap.Peek();
        }

        public TValue Pop()
        {
            return this.minHeap.Pop();
        }
    }

    public class MinHeap<TPriority, TValue> : IHeap<TPriority, TValue> where TPriority : IComparable<TPriority>
    {
        List<KeyValuePair<TPriority, TValue>> minHeap;

        public MinHeap()
        {
            this.minHeap = new List<KeyValuePair<TPriority, TValue>>();
        }

        public int Size { get; private set; }

        public bool IsEmpty()
        {
            return this.Size == 0;
        }

        public void Insert(TPriority priority, TValue value)
        {
            // Heap inserts are always to the end of the list
            this.minHeap.Add(new KeyValuePair<TPriority, TValue>(priority, value));
            this.Size++;

            // Then we swim that last item up to its appropriate location in the heap
            this.Swim();
        }

        public TValue Peek()
        {
            // In min-heap, first item is always smallest
            return this.minHeap[0].Value;
        }

        public TValue Pop()
        {
            // In min-heap, first item is always smallest
            var currentMin = this.minHeap[0].Value;

            // Move last item into first position and delete the last item from list
            this.minHeap[0] = this.minHeap[--this.Size];
            this.minHeap.RemoveAt(this.Size);
            
            // Sink the new first item to its appropriate location in heap
            this.Sink();

            return currentMin;
        }

        void Sink()
        {
            int currentIndex = 0;

            while (this.HasChildren(currentIndex))
            {
                int leftChildIndex = this.LeftChildIndex(currentIndex);
                KeyValuePair<TPriority, TValue> leftChild = this.minHeap[leftChildIndex];

                int indexToCompareAgainst = leftChildIndex;

                if (this.HasRightChild(currentIndex))
                {
                    int rightChildIndex = this.RightChildIndex(currentIndex);
                    KeyValuePair<TPriority, TValue> rightChild = this.minHeap[rightChildIndex];

                    indexToCompareAgainst = 
                        rightChild.Key.CompareTo(leftChild.Key) < 0 ? rightChildIndex : leftChildIndex;
                }

                KeyValuePair<TPriority, TValue> toCompareAgainst = this.minHeap[indexToCompareAgainst];
                if (toCompareAgainst.Key.CompareTo(this.minHeap[currentIndex].Key) > 0)
                {
                    return;
                }

                this.minHeap[indexToCompareAgainst] = this.minHeap[currentIndex];
                this.minHeap[currentIndex] = toCompareAgainst;
                currentIndex = indexToCompareAgainst;
            }
        }

        void Swim()
        {
            int currentIndex = this.Size - 1;

            bool isSmallerThanParent = 
                this.HasParent(currentIndex) &&
                this.minHeap[this.ParentIndex(currentIndex)].Key.CompareTo(this.minHeap[currentIndex].Key) > 0;

            while (isSmallerThanParent)
            {
                int parentIndex = this.ParentIndex(currentIndex);

                KeyValuePair<TPriority, TValue> tmp = this.minHeap[parentIndex];
                this.minHeap[parentIndex] = this.minHeap[currentIndex];
                this.minHeap[currentIndex] = tmp;
                
                currentIndex = parentIndex;
                isSmallerThanParent = 
                    this.HasParent(currentIndex) &&
                    this.minHeap[this.ParentIndex(currentIndex)].Key.CompareTo(this.minHeap[currentIndex].Key) > 0;
            }
        }

        bool HasChildren(int currentIndex)
        {
            return this.HasLeftChild(currentIndex) || this.HasRightChild(currentIndex);
        }

        bool HasLeftChild(int currentIndex)
        {
            return this.LeftChildIndex(currentIndex) < this.Size;
        }

        int LeftChildIndex(int currentIndex)
        {
            return 2 * currentIndex + 1;
        }

        bool HasRightChild(int currentIndex)
        {
            return this.RightChildIndex(currentIndex) < this.Size;
        }

        int RightChildIndex(int currentIndex)
        {
            return 2 * currentIndex + 2;
        }

        bool HasParent(int currentIndex)
        {
            return currentIndex != 0;
        }

        int ParentIndex(int currentIndex)
        {
            return (currentIndex - 1) / 2;
        }
    }}