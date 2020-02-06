using System;
using System.Collections.Generic;
using System.Text;

namespace UnitConverter
{
    public class ConversionNotSupportedException : Exception
    {
        public ConversionNotSupportedException() : base("Conversion not supported.") { }
    }
}
