using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TaskCountOccurence;

namespace _040.CountOccurenceTest
{
    [TestClass]
    public class CountOccurenceTests
    {
        //unit tests of CountOccurenceOfNum.CountOccurenceOfNumInArray() method from previous exercise
        [TestMethod]
        public void TestMethod1()
        {
            int[] arr = { 2, 1, 1, 1, 1, 2 };
            int counter = CountOccurenceOfNum.CountOccurenceOfNumInArray(arr, 2);
            Assert.AreEqual(counter, 2);
        }

        [TestMethod]
        public void TestMethod2()
        {
            int[] arr = {2,2,2,2,2,2};
            int counter = CountOccurenceOfNum.CountOccurenceOfNumInArray(arr, 2);
            Assert.AreEqual(counter, 6);
        }

        [TestMethod]
        public void TestMethod3()
        {
            int[] arr = {1,1,1,1,1,1};
            int counter = CountOccurenceOfNum.CountOccurenceOfNumInArray(arr, 2);
            Assert.AreEqual(counter, 0);
        }


    }
}
