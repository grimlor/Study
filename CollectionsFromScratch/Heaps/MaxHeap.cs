using System;
using System.Collections.Generic;

namespace Study.CollectionsFromScratch
{
    public class MaxHeap<TValue> : IHeap<TValue> where TValue : IComparable<TValue>
    {
        MaxHeap<TValue, TValue> maxHeap;

        public MaxHeap()
        {
            this.maxHeap = new MaxHeap<TValue, TValue>();
        }

        public int Size { get { return this.maxHeap.Size; } }

        public void Insert(TValue value)
        {
            this.maxHeap.Insert(value, value);
        }

        public bool IsEmpty()
        {
            return this.maxHeap.IsEmpty();
        }

        public TValue Peek()
        {
            return this.maxHeap.Peek();
        }

        public TValue Pop()
        {
            return this.maxHeap.Pop();
        }
    }

    public class MaxHeap<TPriority, TValue> : IHeap<TPriority, TValue> where TPriority : IComparable<TPriority>
    {
        List<KeyValuePair<TPriority, TValue>> maxHeap;

        public MaxHeap()
        {
            this.maxHeap = new List<KeyValuePair<TPriority, TValue>>();
        }

        public int Size { get; private set; }

        public void Insert(TPriority priority, TValue value)
        {
            // Heap inserts are always to the end of the list
            this.maxHeap.Add(new KeyValuePair<TPriority, TValue>(priority, value));
            this.Size++;

            // Then we swim that last item up to its appropriate location in the heap
            this.Swim();
        }

        public bool IsEmpty()
        {
            return this.Size == 0;
        }

        public TValue Peek()
        {
            // In max-heap, first item is always largest
            return this.maxHeap[0].Value;
        }

        public TValue Pop()
        {
            TValue maxValue = Peek();

            // Move last item into first position and delete the last item from list
            this.maxHeap[0] = this.maxHeap[--this.Size];
            this.maxHeap.RemoveAt(this.Size);

            // Sink the new first item to its appropriate location in heap
            this.Sink();

            return maxValue;
        }

        void Sink()
        {
            int currentIndex = 0;

            while (this.HasLeftChild(currentIndex))
            {
                int indexOfChildToCompare = this.GetLeftChildIndex(currentIndex);
                KeyValuePair<TPriority, TValue> childToCompare = this.maxHeap[indexOfChildToCompare];

                if (this.HasRightChild(currentIndex))
                {
                    int rightChildIndex = this.GetRightChildIndex(currentIndex);
                    KeyValuePair<TPriority, TValue> rightChild = this.maxHeap[rightChildIndex];

                    if (rightChild.Key.CompareTo(childToCompare.Key) > 0)
                    {
                        indexOfChildToCompare = rightChildIndex;
                        childToCompare = rightChild;
                    }
                }

                if (this.maxHeap[currentIndex].Key.CompareTo(childToCompare.Key) > 0)
                {
                    return;
                }

                this.maxHeap[indexOfChildToCompare] = this.maxHeap[currentIndex];
                this.maxHeap[currentIndex] = childToCompare;
                currentIndex = indexOfChildToCompare;
            }
        }

        void Swim()
        {
            int currentIndex = this.Size - 1;

            while (this.HasParent(currentIndex))
            {
                int parentIndex = this.GetParentIndex(currentIndex);

                KeyValuePair<TPriority, TValue> current = this.maxHeap[currentIndex];
                KeyValuePair<TPriority, TValue> parent = this.maxHeap[parentIndex];
                
                if (parent.Key.CompareTo(current.Key) >= 0) { return; }

                this.maxHeap[currentIndex] = parent;
                this.maxHeap[parentIndex] = current;
                currentIndex = parentIndex;
            }
        }

        bool HasLeftChild(int currentIndex)
        {
            return this.GetLeftChildIndex(currentIndex) < this.Size;
        }

        int GetLeftChildIndex(int currentIndex)
        {
            return currentIndex * 2 + 1;
        }

        bool HasRightChild(int currentIndex)
        {
            return this.GetRightChildIndex(currentIndex) < this.Size;
        }

        int GetRightChildIndex(int currentIndex)
        {
            return currentIndex * 2 + 2;
        }

        bool HasParent(int currentIndex)
        {
            return currentIndex != 0;
        }

        int GetParentIndex(int currentIndex)
        {
            return (currentIndex - 1) / 2;
        }
    }
}