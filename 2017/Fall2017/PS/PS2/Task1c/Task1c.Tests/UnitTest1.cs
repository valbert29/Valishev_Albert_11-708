using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LibraryFor1c;

namespace Task1c.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CheckCorrectness()
        {
            var e = 0.0000000001;
            var x = 1;
            var result = TestClassFor1c.CalculateGraduatedNum(e, x);
            Assert.AreEqual(29999999999, (long)(result[0] * 10000000000));
        }
    }
}
