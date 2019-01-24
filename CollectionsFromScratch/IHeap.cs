using System;

namespace Study.CollectionsFromScratch
{
    public interface IHeap<TValue> where TValue : IComparable<TValue>
    {
         int Size { get; }

         bool IsEmpty();

         void Insert(TValue value);

         TValue Peek();

         TValue Pop();
    }

    public interface IHeap<TPriority, TValue> where TPriority : IComparable<TPriority>
    {
         int Size { get; }

         bool IsEmpty();

         void Insert(TPriority priority, TValue value);

         TValue Peek();

         TValue Pop();
    }
}