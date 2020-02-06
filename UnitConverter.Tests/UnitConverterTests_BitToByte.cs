using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitConverter;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitConverter.Tests
{
    [TestClass()]
    public class UnitConverterTests_BitToByte
    {
        [TestMethod]
        public void Convert_BitsToByte()
        {
            var result = UnitConverter.Convert("3000 bits", "byte");
            Assert.AreEqual("375.00 bytes", result);
        }
        [TestMethod]
        public void Convert_BitsToKilobyte()
        {
            var result = UnitConverter.Convert("3000 bits", "kilobyte");
            Assert.AreEqual("0.37 kilobyte", result);
        }
        [TestMethod]
        public void Convert_Bits_To_gigabyte()
        {
            var result = UnitConverter.Convert("3000000000000 bits", "gigabyte");


            Assert.IsTrue(string.Equals("349.25 gigabytes", result, StringComparison.InvariantCultureIgnoreCase));
        }
    }
}