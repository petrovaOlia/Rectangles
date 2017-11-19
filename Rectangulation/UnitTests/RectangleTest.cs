using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rectangulation.Models;

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
            Assert.IsTrue(rect.IsHitingToBorder(10,10));
            Assert.IsTrue(rect.IsHitingToBorder(10, 30));
            Assert.IsTrue(rect.IsHitingToBorder(30, 10));
            Assert.IsTrue(rect.IsHitingToBorder(30, 30));

            //Внешние границы прямоугольника
            Assert.IsTrue(rect.IsHitingToBorder(8, 20));
            Assert.IsTrue(rect.IsHitingToBorder(32, 20));
            Assert.IsTrue(rect.IsHitingToBorder(20, 8));
            Assert.IsTrue(rect.IsHitingToBorder(20, 32));

            //Внутренниые границы прямоугольника
            Assert.IsTrue(rect.IsHitingToBorder(12, 20));
            Assert.IsTrue(rect.IsHitingToBorder(28, 20));
            Assert.IsTrue(rect.IsHitingToBorder(20, 12));
            Assert.IsTrue(rect.IsHitingToBorder(20, 28));

            //Снаружи прямоугольника
            Assert.IsFalse(rect.IsHitingToBorder(7, 20));
            Assert.IsFalse(rect.IsHitingToBorder(20, 7));
            Assert.IsFalse(rect.IsHitingToBorder(33, 20));
            Assert.IsFalse(rect.IsHitingToBorder(20, 33));

            //Тело прямоугольника
            Assert.IsFalse(rect.IsHitingToBorder(13, 20));
            Assert.IsFalse(rect.IsHitingToBorder(20, 13));
            Assert.IsFalse(rect.IsHitingToBorder(27, 20));
            Assert.IsFalse(rect.IsHitingToBorder(20, 27));
        }
    }
}
