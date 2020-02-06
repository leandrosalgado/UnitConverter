using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitConverter;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitConverter.Tests
{
    [TestClass()]
    public class UnitConverterTests_InchToFoot
    {
        private decimal resultValue = 8.33333M;
        [TestMethod]
        public void Convert_KiloinchesToFoot()
        {
            var result = UnitConverter.Convert("100 kiloinches", "feet");
            var expectedValue = Math.Round((resultValue * 1000), 2) + " feet";
            Assert.IsTrue(String.Equals(expectedValue, result, StringComparison.InvariantCultureIgnoreCase));
        }
        [TestMethod]
        public void Convert_InchToFoot()
        {
            var result = UnitConverter.Convert("100 inches", "feet");
            Assert.AreEqual("8.33 feet", result);
        }

        [TestMethod]
        public void Convert_CentiinchToFoot()
        {
            var result = UnitConverter.Convert("100 centiinches", "feet");
            var expectedResult = Math.Round((resultValue * 0.01M), 2) + " foot";
            Assert.IsTrue(string.Equals(expectedResult, result, StringComparison.InvariantCultureIgnoreCase));
        }
    }
}