using System;

namespace CollectionsFromScratch
{
    public interface IHeap<TValue> where TValue : IComparable<TValue>
    {
         int Count { get; }

         bool IsEmpty();

         void Insert(TValue value);

         TValue Peek();

         TValue Pop();
    }

    public interface IHeap<TPriority, TValue> where TPriority : IComparable<TPriority>
    {
         int Count { get; }

         bool IsEmpty();

         void Insert(TPriority priority, TValue value);

         TValue Peek();

         TValue Pop();
    }
}