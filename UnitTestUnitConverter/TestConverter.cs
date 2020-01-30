using System;
using System.Collections.Generic;
using System.Text;
using UnitConverter;

namespace UnitTestUnitConverter
{
    public class TestConverter : UnitConverter.IConverter
    {
        public bool CanConvert(string from, string to)
        {
            return from == "testFrom" && to == "testTo";
        }

        public string Convert(UnitValue value, string to)
        {
            return "Test converter works!";
        }
    }
}
