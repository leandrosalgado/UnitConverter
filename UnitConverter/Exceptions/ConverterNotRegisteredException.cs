using System;
using System.Collections.Generic;
using System.Text;

namespace UnitConverter
{
    public class ConverterNotRegisteredException : Exception
    {
        public ConverterNotRegisteredException() : base("No converter registered for these units.") { }
    }
}
