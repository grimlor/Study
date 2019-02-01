using System;
using CollectionsFromScratch.Lists;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CollectionsFromScratchTests
{
    [TestClass]
    public class ArrayListTests
    {
        [TestMethod]
        public void AddingToArrayListIncreasesCountCorrectly()
        {
            var testData = new[] { 5, 4, 3, 2, 1 };
            var list = new ArrayList<int>();

            for (int i = 0; i < testData.Length; i++)
            {
                Assert.AreEqual(i, list.Count);
                list.Add(testData[i]);
            }

            Assert.AreEqual(testData.Length, list.Count);
        }

        [TestMethod]
        public void ClearWorksCorrectly()
        {
            var testData = new[] { 5, 4, 3, 2, 1 };
            var list = new ArrayList<int>();

            for (int i = 0; i < testData.Length; i++)
            {
                list.Add(testData[i]);
            }

            list.Clear();

            Assert.AreEqual(0, list.Count);
        }

        [TestMethod]
        public void ContainsWorksCorrectly()
        {
            var testData = new[] { 5, 4, 3, 2, 1 };
            var list = new ArrayList<int>();

            Assert.IsFalse(list.Contains(5));

            for (int i = 0; i < testData.Length; i++)
            {
                list.Add(testData[i]);
                Assert.IsTrue(list.Contains(testData[i]));
            }

            Assert.IsFalse(list.Contains(0));
        }

        [TestMethod]
        public void CanIterateOverArrayList()
        {
            var testData = new[] { 5, 4, 3, 2, 1 };
            var list = new ArrayList<int>();

            for (int i = 0; i < testData.Length; i++)
            {
                list.Add(testData[i]);
            }

            int j = 0;
            foreach (var item in list)
            {
                Assert.AreEqual(testData[j++], item);
            }
        }

        [TestMethod]
        public void CanCopyArrayListToArray()
        {
            var testData = new[] { 5, 4, 3, 2, 1 };
            var list = new ArrayList<int>();

            for (int i = 0; i < testData.Length; i++)
            {
                list.Add(testData[i]);
            }

            var result = new int[6];
            list.CopyTo(result, 1);

            Assert.AreEqual(0, result[0]);

            for (int i = 0; i < testData.Length; i++)
            {
                Assert.AreEqual(testData[i], result[i + 1]);
            }
        }

        [TestMethod]
        public void ThrowsWhenIndexOutOfRange()
        {
            var list = new ArrayList<int>();

            try
            {
                list[0] = 0;
                Assert.Fail("Should have thrown.");
            }
            catch (IndexOutOfRangeException e)
            {
                Assert.AreEqual("Index was outside the bounds of the ArrayList.", e.Message);
            }

            try
            {
                Console.WriteLine(list[0]);
                Assert.Fail("Should have thrown.");
            }
            catch (IndexOutOfRangeException e)
            {
                Assert.AreEqual("Index was outside the bounds of the ArrayList.", e.Message);
            }
        }

        [TestMethod]
        public void IndexOfReturnsCorrectValue()
        {
            var list = new ArrayList<int>();

            for (int i = 0; i < 10; i++)
            {
                list.Add(i);
            }

            list.Add(9);

            for (int j = 0; j < 10; j += 2)
            {
                Assert.AreEqual(list[j], list.IndexOf(j));
            }
        }

        [TestMethod]
        public void InsertingIntoArrayListMaintainsOrder()
        {
            var testData = new[] { 5, 4, 3, 2, 1 };
            var list = new ArrayList<int>();

            for (int i = 1; i < testData.Length; i++)
            {
                Assert.AreEqual(i - 1, list.Count);
                list.Add(testData[i]);
            }

            list.Insert(0, testData[0]);
            Assert.AreEqual(testData.Length, list.Count);
        }

        [TestMethod]
        public void ArrayListExpandsAsAppropriate()
        {
            var testData = new[] { 5, 4, 3, 2, 1 };
            var list = new ArrayList<int>(minLength: 4);

            for (int i = 0; i < testData.Length; i++)
            {
                Assert.AreEqual(i, list.Count);
                list.Add(testData[i]);
            }

            Assert.AreEqual(testData.Length, list.Count);
        }

        [TestMethod]
        public void RemoveWorksAppropriately()
        {
            var list = new ArrayList<int>();

            for (int i = 0; i < 17; i++)
            {
                list.Add(i);
            }

            Assert.AreEqual(17, list.Count);

            for (int i = 0; i < 17; i += 2)
            {
                list.Remove(i);
            }

            Assert.AreEqual(8, list.Count);
            
            for (int i = 0; i < list.Count; i++)
            {
                Assert.AreEqual(i * 2 + 1, list[i]);
            }
        }

        [TestMethod]
        public void RemoveAtWorksAppropriately()
        {
            var list = new ArrayList<int>(minLength: 4);

            for (int i = 0; i < 17; i++)
            {
                list.Add(i);
            }

            Assert.AreEqual(17, list.Count);

            for (int i = 0; i < 16; i++)
            {
                list.RemoveAt(0);
            }

            Assert.AreEqual(1, list.Count);
            Assert.AreEqual(16, list[0]);
        }
    }
}