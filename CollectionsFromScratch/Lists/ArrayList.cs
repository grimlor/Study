using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CollectionsFromScratch
{
    public class ArrayList<T> : IList<T>
    {
        T[] list;

        int count;

        int minLength;

        public ArrayList() : this(16)
        {
        }

        public ArrayList(int minLength)
        {
            this.minLength = minLength;
            this.Clear();
        }

        public T this[int index] 
        { 
            get
            {
                if (index >= this.count)
                {
                    throw new IndexOutOfRangeException("Index was outside the bounds of the ArrayList.");
                }

                return this.list[index];
            }
            set
            {
                if (index >= this.count)
                {
                    throw new IndexOutOfRangeException("Index was outside the bounds of the ArrayList.");
                }

                this.list[index] = value;
            }
        }

        public int Count => this.count;

        public bool IsReadOnly => false;

        public void Add(T item)
        {
            this[this.count++] = item;

            this.Resize();
        }

        public void Clear()
        {
            this.list = new T[this.minLength];
            this.count = 0;
        }

        public bool Contains(T item)
        {
            foreach (T current in this)
            {
                if (item.Equals(current))
                {
                    return true;
                }
            }

            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            for (int i = 0; i < this.count; i++)
            {
                array[i + arrayIndex] = this[i];
            }
        }

        public int IndexOf(T item)
        {
            return Array.IndexOf(this.list, item);
        }

        public void Insert(int index, T item)
        {
            this.count++;
            this.Resize();

            for (int i = this.count - 1; i > index; i--)
            {
                this[i] = this[i - 1];
            }

            this[index] = item;
        }

        public bool Remove(T item)
        {
            int index = this.IndexOf(item);
            if (index == -1)
            {
                return false;
            }

            for (int i = index; i < this.count; i++)
            {
                this[i] = i + 1 < this.count ? this[i + 1] : default(T);
            }

            this.count--;
            this.Resize();
            return true;
        }

        public void RemoveAt(int index)
        {
            for (int i = index; i < this.count; i++)
            {
                this[i] = i + 1 < this.count ? this[i + 1] : default(T);
            }

            this.count--;
            this.Resize();
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.count; i++)
            {
                yield return this[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        void Resize()
        {
            if (this.count == this.list.Length)
            {
                var tmp = new T[this.count * 2];
                this.CopyTo(tmp, 0);
                this.list = tmp;
                return;
            }

            if (this.count <= this.list.Length / 4 && this.list.Length > this.minLength)
            {
                var newSize = this.list.Length / 2 >= this.minLength ? this.list.Length / 2 : this.minLength;
                var tmp = new T[newSize];
                this.CopyTo(tmp, 0);
                this.list = tmp;
            }
        }
    }
}