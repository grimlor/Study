using CollectionsFromScratch.Lists;

namespace CollectionsFromScratch
{
    /// <summary>
    /// A generic collection that is based on the first-in-first-out (FIFO) policy.
    /// When a client iterates through the items in a queue with the foreach construct, the items are processed in the 
    /// order they were added to the queue.
    /// </summary>
    public class Queue<T> : System.Collections.Generic.IEnumerable<T>
    {
        LinkedList<T> head;
        LinkedList<T> tail;

        public int Count => this.head.Count;

        public bool IsEmpty => this.head == null;

        public void Enqueue(T item)
        {
            var newTail = new LinkedList<T>(item);
            newTail.Previous = this.tail;

            if (this.tail != null)
            {
                this.tail.Next = newTail;
            }

            if (this.head == null)
            {
                this.head = newTail;
            }

            this.tail = newTail;
        }

        public T Dequeue()
        {
            T valueToReturn = this.head.Value;

            this.head = this.head.Next;
            if (this.head != null)
            {
                this.head.Previous = null;
            }

            return valueToReturn;
        }

        public System.Collections.Generic.IEnumerator<T> GetEnumerator()
        {
            return this.head.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
