//----------------------------------------------------------------
// <copyright company="Microsoft Corporation">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
//----------------------------------------------------------------

using CollectionsFromScratch;
using CollectionsFromScratch.Heaps;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CollectionsFromScratchTests
{
    [TestClass]
    public class SimpleHeapTests
    {
        [TestMethod]
        public void CanInitializeHeapWithArray()
        {
            var testData = new[] { 5, 4, 3, 2, 1 };

            IHeap<int> minHeap = new SimpleHeap<int>(testData);
        }

        [TestMethod]
        public void WillNotExceedMaxCount()
        {
            var testData = new[] { 5, 4, 3, 2, 1 };

            IHeap<int> minHeap = new SimpleHeap<int>(testData.Length - 1);

            foreach (var item in testData)
            {
                minHeap.Insert(item);
            }
        }
    }
}
