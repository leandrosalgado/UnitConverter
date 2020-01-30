using System;
using System.Collections.Generic;
using System.Text;

namespace UnitConverter.Tests
{
    public class TestConverter : IConverter
    {
        public bool CanConvert(string from, string to)
        {
            return from == "testfrom" && to == "testto";
        }

        public string Convert(UnitValue value, string to)
        {
            return "Test converter works!";
        }
    }
}
