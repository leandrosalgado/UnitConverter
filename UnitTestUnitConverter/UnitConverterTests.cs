using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitConverter;
using System;
using System.Collections.Generic;
using System.Text;
using UnitTestUnitConverter;

namespace UnitConverter.Tests
{
    [TestClass()]
    public class UnitConverterTests
    {
        [TestMethod]
        public void Convert_MetresToFeet()
        {
            var result = UnitConverter.Convert("400 metres", "feet");
            Assert.AreEqual(result, "1312.34 feet");
        }
        [TestMethod]
        public void Convert_FeetoMeters()
        {
            var result = UnitConverter.Convert("1312.34 feet", "metres");
            Assert.AreEqual(result, "400 meters");
        }

        [TestMethod]
        public void Convert_InvalidArgumentException()
        {
            Assert.ThrowsException<ArgumentException>(() => UnitConverter.Convert("", null));
        }

        [TestMethod()]
        public void RegisterConverter_RegisterTestConverter()
        {
            var testConverter = new TestConverter();
            UnitConverter.RegisterConverter(testConverter);
            var result = UnitConverter.Convert("400 testFrom", "testTo");
            Assert.AreEqual(result, "Test converter works!");
            UnitConverter.UnregisterConverter(testConverter);
            Assert.ThrowsException<ConverterNotRegisteredException>(() => UnitConverter.Convert("400 testFrom", "testTo"));
        }
    }
}