using CollectionsFromScratch.Lists;

namespace CollectionsFromScratch
{
    /// <summary>
    /// A generic collection where removing items is not supported where its purpose is to provide clients with the 
    /// ability to collect items and then to iterate through the collected items(the client can also test if a bag is 
    /// empty and find its number of items). The order  of iteration is unspecified and should be immaterial to the 
    /// client.
    /// </summary>
    public class Bag<T> : System.Collections.Generic.IEnumerable<T>
    {
        readonly LinkedList<T> list;

        public int Count => this.list.Count;

        public bool IsEmpty => this.Count == 0;

        public Bag()
        {
            this.list = new LinkedList<T>();
        }

        public void Add(T item)
        {
            this.list.Add(item);
        }
        
        public System.Collections.Generic.IEnumerator<T> GetEnumerator()
        {
            return this.list.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}