using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitConverter;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitConverter.Tests
{
    [TestClass()]
    public class UnitConverterTests_MetreToInch
    {
        [TestMethod]
        public void Convert_KilometresToInch()
        {
            var result = UnitConverter.Convert("4 kilometres", "inch");
            Assert.AreEqual("157480.40 inches", result);
        }
        [TestMethod]
        public void Convert_MetresToInch()
        {
            var result = UnitConverter.Convert("4 metres", "inch");
            Assert.AreEqual("157.48 inches", result);
        }
        [TestMethod]
        public void Convert_CentimetreToInch()
        {
            var result = UnitConverter.Convert("4 Centimetre", "inch");
            Assert.AreEqual("1.57 inches", result);
        }
        [TestMethod]
        public void Convert_MilimetreToInch()
        {
            var result = UnitConverter.Convert("4 Milimetre", "inch");
            Assert.AreEqual("0.16 inch", result);
        }
        [TestMethod]
        public void Convert_InchToKilometers()
        {
            var result = UnitConverter.Convert("1000 inch", "kilometres");
            Assert.AreEqual("0.03 kilometre", result);
        }

        [TestMethod]
        public void Convert_InchToMeters()
        {
            var result = UnitConverter.Convert("1000 inch", "metres");
            Assert.AreEqual("25.40 metres", result);
        }

        [TestMethod]
        public void Convert_InchToCentimeters()
        {
            var result = UnitConverter.Convert("1000 inch", "centimetres");
            Assert.AreEqual("2540.00 centimetres", result);
        }

        [TestMethod]
        public void Convert_InchToMilimeters()
        {
            var result = UnitConverter.Convert("1000 inch", "milimetres");
            Assert.AreEqual("25400.00 milimetres", result);
        }

        [TestMethod]
        public void Convert_Kiloinches_To_Metres()
        {
            var result = UnitConverter.Convert("3 kiloinches", "metres");
            Assert.AreEqual("76.20 metres", result);
        }
    }
}