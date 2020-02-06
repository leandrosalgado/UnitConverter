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
        /// <summary>
        /// Converts value to the chosen unit type.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        public string Convert(UnitValue value, string to);
    }
}
