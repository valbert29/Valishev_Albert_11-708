using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Semestr1;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CheckCorrectAdd()
        {
            var list = new FigureList();
            for (int i = 0; i < 4; i++)
            {
                list.Add(new Figure(1, 1, 1, 1, 1, 1), 0);
            }
            Assert.AreEqual(1, list.Count());
        }

        [TestMethod]
        public void CheckEncode()//в файле 4 элемента было, проверял по длине, не додумался по-другому
        {
            var myList = new FigureList();
            var list = new Do();
            list.MyList = myList;
            list.Encode();
            Assert.AreEqual(4, myList.Count());
        }

        [TestMethod]
        public void CheckDecode()
        {
            var myList = new FigureList();
            var list = new Do();
            list.MyList = myList;
            var rnd = new Random();
            for (int i = 0; i < 7; i++)
            {
                myList.Add(new Figure(rnd.Next(1, 4), rnd.Next(0, 6), rnd.Next(0, 6),
    rnd.Next(0, 4), rnd.Next(0, 4), rnd.Next(0, 4)), i);
            }
            list.Decode();
            Assert.AreEqual(0, myList.Count());
        }

        [TestMethod]
        public void CheckRemove()
        {
            var myList = new FigureList();
            var rnd = new Random();
            for (int i = 0; i < 7; i++)
            {
                myList.Add(new Figure(1, i, 0, 0, 0, 0), 0);
            }
            myList.Remove(new Figure(1, 0, 0, 0, 0, 0));
            Assert.AreEqual(6, myList.Count());
        }

        [TestMethod]
        public void CheckRectangle()
        {
            var myList = new FigureList();
            var list = new Do();
            list.MyList = myList;
            var rnd = new Random();
            for (int i = 0; i < 7; i++)
            {
                myList.Add(new Figure(2, rnd.Next(0, 6), rnd.Next(0, 6),
    rnd.Next(0, 4), rnd.Next(0, 4), rnd.Next(0, 4)), i);
            }
            for (int i = 0; i < 2; i++)
            {
                myList.Add(new Figure(2, i, i, i, i, rnd.Next(0, 8)), i);
            }
            var newLine = list.LinesToRectangle();
            Figure item = newLine.head;
            var n = -1;
            while (item!=null)
            {
                if (item.Type != 1) n = 1;
                item = item.Next;
            }
            Assert.AreEqual(-1, n);
        }






    }
}
