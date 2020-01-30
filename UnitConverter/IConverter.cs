using System;
using System.Collections.Generic;
using System.Text;

namespace UnitConverter
{
    public interface IConverter
    {
        /// <summary>
        /// Checks if units can be converted by converter
        /// </summary>
        /// <param name="from">Unit from (e.g.: meters, feet, inches))</param>
        /// <param name="to">Unit to (e.g.: meters, feet, inches)</param>
        /// <returns></returns>
        public bool CanConvert(string from, string to);
        public string Convert(UnitValue value, string to);
    }
}
