using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rectangulation;

namespace UnitTests
{
    [TestClass]
    public class RectangleTest
    {
        [TestMethod]
        public void HitToBordersTest()
        {
            var rect = new Rectangle(10, 10, 20, 20);

            //Углы прямоугольника
            Assert.IsTrue(rect.HitToBorder(10,10));
            Assert.IsTrue(rect.HitToBorder(10, 30));
            Assert.IsTrue(rect.HitToBorder(30, 10));
            Assert.IsTrue(rect.HitToBorder(30, 30));

            //Внешние границы прямоугольника
            Assert.IsTrue(rect.HitToBorder(8, 20));
            Assert.IsTrue(rect.HitToBorder(32, 20));
            Assert.IsTrue(rect.HitToBorder(20, 8));
            Assert.IsTrue(rect.HitToBorder(20, 32));

            //Внутренниые границы прямоугольника
            Assert.IsTrue(rect.HitToBorder(12, 20));
            Assert.IsTrue(rect.HitToBorder(28, 20));
            Assert.IsTrue(rect.HitToBorder(20, 12));
            Assert.IsTrue(rect.HitToBorder(20, 28));

            //Снаружи прямоугольника
            Assert.IsFalse(rect.HitToBorder(7, 20));
            Assert.IsFalse(rect.HitToBorder(20, 7));
            Assert.IsFalse(rect.HitToBorder(33, 20));
            Assert.IsFalse(rect.HitToBorder(20, 33));

            //Тело прямоугольника
            Assert.IsFalse(rect.HitToBorder(13, 20));
            Assert.IsFalse(rect.HitToBorder(20, 13));
            Assert.IsFalse(rect.HitToBorder(27, 20));
            Assert.IsFalse(rect.HitToBorder(20, 27));
        }
    }
}
