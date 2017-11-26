using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LibraryFor1b;

namespace Task1b.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CheckCorrectness()
        {
            var e = 0.0000000001;
            var x = -0.75;
            var result = TestClass1b.FindValue(e, x);
            Assert.AreEqual(5000000002, (long)(result[0] * 10000000000));//0.5000000002
        }
    }
}
