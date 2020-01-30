using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitConverter;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitConverter.Tests
{
    [TestClass()]
    public class UnitConverterTests_General
    {
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

        [TestMethod]
        public void Convert_Invalid_Formula()
        {
            Assert.ThrowsException<ConversionNotSupported>(() => UnitConverter.Convert("3000000000000 fdsfsdfbit", "bbyte"));
            Assert.ThrowsException<ConversionNotSupported>(() => UnitConverter.Convert("3000000000000 dbit", "bbyte"));
        }
    }
}