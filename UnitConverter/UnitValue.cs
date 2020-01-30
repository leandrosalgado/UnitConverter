using System;
using System.Collections.Generic;
using System.Text;

namespace UnitConverter
{
    /// <summary>
    /// Class which represents the source Unit to be converted
    /// </summary>
    public class UnitValue
    {
        /// <summary>
        /// Unit value without unit text
        /// </summary>
        public string Value { get; set; }
        /// <summary>
        /// Unit text. e.g.: metre, foot, inch
        /// </summary>
        public string UnitText { get; set; }

        /// <summary>
        /// Creates a new instace of UnitValue. 
        /// </summary>
        /// <param name="value">The value must followed the format "{value} {unit}"</param>
        public UnitValue(string value)
        {
            if (String.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException($"Value cannot be empty", nameof(value));
            }
            // TODO: Refactor this code to use lambda expression for validation.
            var auxArray = value.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            if (auxArray.Length > 1) {
                Value = auxArray[0]; 
                UnitText = auxArray[auxArray.Length - 1];
            } else // If it isn't possible to map the input to the properties an exception is thrown
            {
                throw new ConversionNotSupported();
            }
        }
    }
}
