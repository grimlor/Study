using System.Linq;
using CollectionsFromScratch.Lists;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CollectionsFromScratchTests
{
    [TestClass]
    public class LinkedListTests
    {
        [TestMethod]
        public void AddingToLinkedListIncreasesCountCorrectly()
        {
            var testData = new[] { 5, 4, 3, 2, 1 };
            var list = new LinkedList<int>();

            for (int i = 0; i < testData.Length; i++)
            {
                Assert.AreEqual(i, list.Count);
                list.Add(testData[i]);
            }

            Assert.AreEqual(testData.Length, list.Count);
        }

        [TestMethod]
        public void CanIterateOverLinkedList()
        {
            var testData = new[] { 5, 4, 3, 2, 1 };
            var list = new LinkedList<int>();

            foreach (var item in testData)
            {
                list.Add(item);
            }

            int j = 0;
            foreach (var item in list)
            {
                Assert.AreEqual(testData[j++], item);
            }
        }

        [TestMethod]
        public void CanClearLinkedList()
        {
            var testData = new[] { 5, 4, 3, 2, 1 };
            var list = new LinkedList<int>();

            foreach (var item in testData)
            {
                list.Add(item);
            }

            Assert.AreEqual(testData.Length, list.Count);

            list.Clear();

            Assert.AreEqual(0, list.Count);
        }

        [TestMethod]
        public void ClearingListRootDoesNotImpactRemainingNodes()
        {
            var testData = new[] { 5, 4, 3, 2, 1 };
            var list = new LinkedList<int>();

            foreach (var item in testData)
            {
                list.Add(item);
            }

            Assert.AreEqual(testData.Length, list.Count);

            var nextNode = list.Next;
            list.Clear();

            Assert.AreEqual(0, list.Count);

            Assert.AreEqual(4, nextNode.Count);
        }

        [TestMethod]
        public void ContainsWorksCorrectly()
        {
            var testData = new[] { 5, 4, 3, 2, 1 };
            var list = new LinkedList<int>();

            Assert.IsFalse(list.Contains(0));

            foreach (var item in testData)
            {
                Assert.IsFalse(list.Contains(item));
                list.Add(item);
                Assert.IsTrue(list.Contains(item));
            }

            Assert.IsFalse(list.Contains(0));
        }

        [TestMethod]
        public void CanCopyLinkedListToArray()
        {
            var testData = new[] { 5, 4, 3, 2, 1 };
            var list = new LinkedList<int>();

            foreach (var item in testData)
            {
                list.Add(item);
            }

            var equalCopy = new int[testData.Length];
            list.CopyTo(equalCopy, 0);

            for (int i = 0; i < testData.Length; i++)
            {
                Assert.AreEqual(testData[i], equalCopy[i]);
            }

            var offsetCopy = new int[testData.Length + 1];
            list.CopyTo(offsetCopy, 1);

            for (int i = 0; i < testData.Length; i++)
            {
                Assert.AreEqual(testData[i], offsetCopy[i + 1]);
            }
        }

        [TestMethod]
        public void CanRemoveItemsFromLinkedList()
        {
            var testData = new[] { 5, 4, 3, 2, 1 };
            var list = new LinkedList<int>();

            Assert.IsFalse(list.Remove(2));

            foreach (var item in testData)
            {
                list.Add(item);
            }

            list.Add(2);
            
            Assert.IsTrue(list.Contains(4));
            Assert.IsTrue(list.Contains(2));
            Assert.AreEqual(6, list.Count);

            list.Remove(4);
            Assert.IsFalse(list.Contains(4));
            Assert.AreEqual(5, list.Count);

            list.Remove(2);
            Assert.IsTrue(list.Contains(2));
            Assert.AreEqual(4, list.Count);

            list.Remove(2);
            Assert.IsFalse(list.Contains(2));
            Assert.AreEqual(3, list.Count);
        }
    }
}