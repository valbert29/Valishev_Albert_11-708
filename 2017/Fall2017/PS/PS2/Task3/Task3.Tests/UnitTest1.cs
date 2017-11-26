using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Solve.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestLeftRectangle()
        {
            var n = 1000000;
            var a = 0;
            var b = 1.5;
            var leftRectangle = TestClass3.CalculateLeftRectangle(n, a, b);
            Assert.AreEqual((int)(leftRectangle * 100000) - 168937, 0);
        }

        [TestMethod]
        public void TestRightRectangle()
        {
            var n = 1000000;
            var a = 0;
            var b = 1.5;
            var rightRectangle = TestClass3.CalculateRightRectangle(n, a, b);
            Assert.AreEqual((int)(rightRectangle * 100000) - 168937, 0);
        }

        [TestMethod]
        public void TestTrapeze()
        {
            var n = 1000000;
            var a = 0;
            var b = 1.5;
            var trapeze = TestClass3.CalculateTrapeze(n, a, b);
            Assert.AreEqual((int)(trapeze * 100000) - 168937, 0);
        }

        [TestMethod]
        public void TestMonteKarlo()
        {
            var n = 100000000;
            var b = 1.5;
            var monteKarlo = TestClass3.CalculateMonteKarlo(n, b);
            Assert.AreEqual((int)(monteKarlo * 1000) - 1689, 0);
        }

        [TestMethod]
        public void TestSimpson()
        {
            var n = 1000000;
            var a = 0;
            var b = 1.5;
            var simpson = TestClass3.CalculateSimpson(n, a, b);
            Assert.AreEqual((int)(simpson * 100000) - 168937, 0);
        }
    }
}