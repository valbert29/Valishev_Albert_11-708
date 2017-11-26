using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestLibrary;

namespace Ex2.Tests
{
    [TestClass]
    public class UnitTest2
    {
        [TestMethod]
        public void TestEnterData()
        {
            var e = 0.000000001;
            var result = Class.FindCos(e, 0.0);
            Assert.AreEqual(739085133, (int)(result * 1000000000));//0.739085133
        }
    }
}
