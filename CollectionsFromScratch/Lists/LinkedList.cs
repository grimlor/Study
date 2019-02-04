using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace CollectionsFromScratch.Lists
{
    public class LinkedList<T> : ICollection<T>
    {
        LinkedList<T> head;

        LinkedList<T> tail;

        bool hasValue;

        public T Value { get; set; }

        public LinkedList<T> Next { get; set; }

        public LinkedList<T> Previous { get; set; }

        public int Count 
        {
            get
            {
                int count = 0;
                foreach (var item in this)
                {
                    count++;
                }
                return count;
            }
        }

        public bool IsReadOnly => false;

        public LinkedList()
        {
            this.hasValue = false;
        }

        public LinkedList(IList<T> values)
        {
            foreach (var value in values)
            {
                this.Add(value);
            }
        }

        public void Add(T item)
        {
            if (!this.hasValue)
            {
                this.Value = item;
                this.hasValue = true;
                this.head = this;
                this.tail = this;
                return;
            }

            var newTail = new LinkedList<T>();
            newTail.Value = item;
            newTail.hasValue = true;
            newTail.Previous = this.tail;
            newTail.head = this.head;
            
            this.tail.Next = newTail;
            this.tail = newTail;
        }

        public void Clear()
        {
            if (this.Next != null)
            {
                this.Next.head = this.Next;
                this.Next.tail = this.tail;
            }

            this.Value = default(T);
            this.hasValue = false;
            this.head = null;
            this.tail = null;
        }

        public bool Contains(T item)
        {
            var current = this;
            while (current != null && current.hasValue)
            {
                if (current.Value.Equals(item)) { return true; }
                current = current.Next;
            }

            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            foreach (var item in this)
            {
                array[arrayIndex++] = item;
            }
        }

        public bool Remove(T item)
        {
            if (!this.hasValue)
            {
                return false;
            }

            var current = this;
            while (current != null && current.hasValue)
            {
                if (current.Value.Equals(item))
                {
                    if (current.Previous != null)
                    {
                        current.Previous.Next = current.Next;
                    }
                    if (current.Next != null)
                    {
                        current.Next.Previous = current.Previous;
                    }
                    current.Clear();
                    return true;
                }
                current = current.Next;
            }

            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            if (this.hasValue == false)
            {
                yield break;
            }
            else
            {
                var current = this;
                while (current != null && current.hasValue)
                {
                    yield return current.Value;
                    current = current.Next;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}