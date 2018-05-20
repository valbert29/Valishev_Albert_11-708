using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Two_ThreeTree;

namespace Two_Three_Tests
{
    [TestClass]
    public class UnitTest1
    {//строится дерево с 2-3 вершинами и минимальный находится в 3 вершине
        [TestMethod]
        public void TestAdd()
        {
            var arr = new int[] { 30, 70, 15, 50, 5, 60, 85, 10, 20, 35, 40, 55, 65, 80, 90 };
            var tree = new TreeNode(5);
            foreach (var e in arr)
                tree.Insert(tree, e);
            var boolean = true;
            foreach (var item in arr)
                if (!tree.values.Contains(item))
                    boolean = false;
            Assert.AreEqual(boolean, true);
            Assert.AreEqual(arr.Length, tree.values.Count);
        }

        [TestMethod]
        public void TestDelete()
        {
            var arr = new int[] { 30, 70, 15, 50, 5, 60, 85, 10, 20, 35, 40, 55, 65, 80, 90 };
            var tree = new TreeNode(5);
            foreach (var e in arr)
            {
                tree.Insert(tree, e);
                tree.Remove(tree, e);
            }
            Assert.AreEqual(0, tree.values.Count);
        }

        [TestMethod]
        public void TestSearch()
        {
            var arr = new int[] { 30, 70, 15, 50, 5, 60, 85, 10, 20, 35, 40, 55, 65, 80, 90 };
            var tree = new TreeNode(5);
            foreach (var e in arr)
            {
                tree.Insert(tree, e);
            }
            Assert.AreEqual(1, tree.Search(tree, 55).Size);
        }

        [TestMethod]
        public void TestSearchMin()
        {
            var arr = new int[] { 30, 70, 15, 50, 5, 60, 85, 10, 20, 35, 40, 55, 65, 80, 90 };
            var tree = new TreeNode(5);
            foreach (var e in arr)
            {
                tree.Insert(tree, e);
            }
            Assert.AreEqual(3, tree.SearchMin(tree).Size);
        }


    }
}
