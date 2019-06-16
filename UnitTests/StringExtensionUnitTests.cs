using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WindowsForms1;

namespace UnitTests
{
    [TestClass]
    public class ExtensionsTests
    {
        [TestMethod]
        public void IsAnIntegerTest1()
        {
            string Number1 = "5";
             Assert.IsTrue(Number1.IsAnInteger());
        }
        [TestMethod]
        public void IsAnIntegerTest2()
        { 
        string Number2 = "5.0";
        Assert.IsFalse(Number2.IsAnInteger());
        }
        [TestMethod]
        public void IsAnIntegerTest3()
        {
            string Number3 = " 2 ";
            Assert.IsTrue(Number3.IsAnInteger());

        }
        [TestMethod]
        public void IsAnIntegerTest4()
        {
            string Number4 = "2L";
            Assert.IsFalse(Number4.IsAnInteger());

        }

        [TestMethod]
        public void IsAFractionTest1()
        {
            string aFraction = "2/3";
            Assert.IsTrue(aFraction.IsAFraction());
        }
        [TestMethod]
        public void IsAFractionTest2()
        {
            string aFraction2 = " 2/3 ";
            Assert.IsTrue(aFraction2.IsAFraction());

        }
        [TestMethod]
        [ExpectedException(typeof(NotAFractionException))]
        public void IsAFractionTest3()
        {
            string aFraction3 = "2/3 L";
            aFraction3.IsAFraction();
        }
        [TestMethod]
        [ExpectedException(typeof(NotAFractionException))]
        public void IsAFraction4()
        {
            string aFraction4 = "2/3 1";
            Assert.IsFalse(aFraction4.IsAFraction());
        }

        [TestMethod]
        public void ConvertFractionToDecimalTest1()
        {
            string fraction1 = "2/3";
            double expected = 2.0 / 3.0;
            Assert.AreEqual(expected, fraction1.ConvertFractionToDecimal());

        }

        [TestMethod]
        [ExpectedException(typeof(NotAFractionException))]
        public void ConvertFractionToDecimalTest2()
        {
            string fraction2 = "2/3 L";
            fraction2.ConvertFractionToDecimal();
        }
        [TestMethod]
        public void ConvertFractionToDecimalTest3()
        {
            string fraction3 = "2 / 3";
            double expected = 2.0 / 3.0;
            Assert.AreEqual(expected, fraction3.ConvertFractionToDecimal());
        }

        [TestMethod]
        public void GetWholeAndFractionalPartsTest1()
        {
            string number1 = "5 1/2";
            List<string> expected = new List<string>();
            expected.Add("5");
            expected.Add("1/2");
            List<string> actual = number1.GetWholeAndFractionalParts();
            for (int i = 0; i < 2; i++)
            {
                Assert.AreEqual(actual[i], expected[i]);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(NotAMixedNumberException))]
        public void GetWholeAndFractionalPartsTest2()
        {
            string number2 = "5 2 1";
            number2.GetWholeAndFractionalParts();

        }
        [TestMethod]
        public void GetWholeAndFractionalPartsTest3()
        {
            string number3 = "5 1/2L";
            List<string> actual = number3.GetWholeAndFractionalParts();
            List<string> expected = new List<string>();
            expected.Add("5");
            expected.Add("1/2L");
            for (int i = 0; i < 2; i++)
            {
                Assert.AreEqual(actual[i], expected[i]);
            }
        }


    }
}
