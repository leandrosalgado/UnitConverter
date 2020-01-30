using System;
using System.Collections.Generic;
using System.Text;

namespace UnitConverter
{
    public class ConversionNotSupported : Exception
    {
        public ConversionNotSupported() : base("Conversion not supported.") { }
    }
}
