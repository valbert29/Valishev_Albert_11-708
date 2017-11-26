using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LibraryFor1a;

namespace Test.Task1a
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CheckValueCorrectness()
        {
            var e = 0.0000000001;
            var result = ClassFor1a.FindValueAndStep(e);
            Assert.AreEqual(5483113556, (long)(result[0] * 10000000000)); //0.5483113556
        }
    }
}
