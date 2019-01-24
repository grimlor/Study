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
            var currentMin = Peek();

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

            while (this.HasLeftChild(currentIndex))
            {
                int indexOfChildToCompare = this.GetLeftChildIndex(currentIndex);
                KeyValuePair<TPriority, TValue> childToCompare = this.minHeap[indexOfChildToCompare];

                if (this.HasRightChild(currentIndex))
                {
                    int rightChildIndex = this.GetRightChildIndex(currentIndex);
                    KeyValuePair<TPriority, TValue> rightChild = this.minHeap[rightChildIndex];

                    if (rightChild.Key.CompareTo(childToCompare.Key) < 0)
                    {
                        indexOfChildToCompare = rightChildIndex;
                        childToCompare = rightChild;
                    }
                }

                if (this.minHeap[currentIndex].Key.CompareTo(childToCompare.Key) < 0)
                {
                    return;
                }

                this.minHeap[indexOfChildToCompare] = this.minHeap[currentIndex];
                this.minHeap[currentIndex] = childToCompare;
                currentIndex = indexOfChildToCompare;
            }
        }

        void Swim()
        {
            int currentIndex = this.Size - 1;

            while (this.HasParent(currentIndex))
            {
                int parentIndex = this.GetParentIndex(currentIndex);

                KeyValuePair<TPriority, TValue> current = this.minHeap[currentIndex];
                KeyValuePair<TPriority, TValue> parent = this.minHeap[parentIndex];
                
                if (parent.Key.CompareTo(current.Key) <= 0) { return; }

                this.minHeap[currentIndex] = parent;
                this.minHeap[parentIndex] = current;
                currentIndex = parentIndex;
            }
        }

        bool HasLeftChild(int currentIndex)
        {
            return this.GetLeftChildIndex(currentIndex) < this.Size;
        }

        int GetLeftChildIndex(int currentIndex)
        {
            return 2 * currentIndex + 1;
        }

        bool HasRightChild(int currentIndex)
        {
            return this.GetRightChildIndex(currentIndex) < this.Size;
        }

        int GetRightChildIndex(int currentIndex)
        {
            return 2 * currentIndex + 2;
        }

        bool HasParent(int currentIndex)
        {
            return currentIndex != 0;
        }

        int GetParentIndex(int currentIndex)
        {
            return (currentIndex - 1) / 2;
        }
    }}