using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitConverter;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitConverter.Tests
{
    [TestClass()]
    public class UnitConverterTests_MetreToFoot
    {
        [TestMethod]
        public void Convert_KilometresToFoot()
        {
            var result = UnitConverter.Convert("0.4 kilometre", "feet");
            Assert.AreEqual("1312.34 feet", result);
        }
        [TestMethod]
        public void Convert_MetresToFoot()
        {
            var result = UnitConverter.Convert("400 metres", "feet");
            Assert.AreEqual("1312.34 feet",result);
        }
        [TestMethod]
        public void Convert_CentimetreToFoot()
        {
            var result = UnitConverter.Convert("40000 Centimetre", "feet");
            Assert.AreEqual("1312.34 feet", result);
        }
        [TestMethod]
        public void Convert_MilimetreToFoot()
        {
            var result = UnitConverter.Convert("400000 Milimetre", "feet");
            Assert.AreEqual("1312.34 feet", result);
        }
        [TestMethod]
        public void Convert_FeetoKilometers()
        {
            var result = UnitConverter.Convert("1312.34 feet", "kilometres");
            Assert.AreEqual("0.40 kilometre", result);
        }

        [TestMethod]
        public void Convert_FeetoMeters()
        {
            var result = UnitConverter.Convert("1312.34 feet", "metres");
            Assert.AreEqual("400.00 metres", result);
        }

        [TestMethod]
        public void Convert_FeetoCentimeters()
        {
            var result = UnitConverter.Convert("1312.34 feet", "centimetres");
            Assert.AreEqual("40000.12 centimetres", result);
        }
        [TestMethod]
        public void Convert_Kilofeet_To_Metres()
        {
            var result = UnitConverter.Convert("1 kilofeet", "metres");
            Assert.AreEqual("304.80 metres", result);
        }

        [TestMethod]
        public void Convert_Kilofeet_To_Centimetres()
        {
            var result = UnitConverter.Convert("1 kilofeet", "centimetres");
            Assert.AreEqual("30480.00 centimetres", result);
        }

        [TestMethod]
        public void Convert_kilofeet_To_Milimetres()
        {
            var result = UnitConverter.Convert("1 kilofeet", "milimetres");
            Assert.AreEqual("304800.00 milimetres", result);
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