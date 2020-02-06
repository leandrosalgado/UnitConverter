using System;
using System.Collections.Generic;
using System.Linq;

namespace UnitConverter
{
    /// <summary>
    /// Utility Class to convert units
    /// 
    /// </summary>
    public class UnitConverter
    {
        /// <summary>
        /// Convert units:
        ///     e.g.: UnitConverter.Convert("3 kiloinches", "meter") -> "76.20 metres"
        /// </summary>
        /// <param name="from">Value to be converted, the format must be "{value} {unit}"</param>
        /// <param name="to">To which unit value has to be converted, the format must be "{unit}"</param>
        /// <returns></returns>
        public static string Convert(string from, string to)
        {
            if(string.IsNullOrWhiteSpace(from))
            {
                throw new ArgumentException("Invalid parameter value.", nameof(from));
            }
            if (string.IsNullOrWhiteSpace(to))
            {
                throw new ArgumentException("Invalid parameter value.", nameof(to));
            }
            // Extract units from parameter
            var fromUnit = new UnitValue(FormatInputString(from));
            var toUnit = FormatInputString(to);

            // Retrieves converter instance
            var converter = Utils.Converter.GetConverter(fromUnit.UnitText, toUnit);

            // If none converter found throw Execption ConverterNotRegisteredException
            if (converter == null)
            {
                throw new ConverterNotRegisteredException();
            }

            return converter.Convert(fromUnit, toUnit);
        }

        /// <summary>
        /// Register a new Converter
        /// </summary>
        /// <param name="converter">Object instace which implemets IConverter interface</param>
        public static void RegisterConverter(IConverter converter)
        {
            /// This method could've been implemented in this class but I decided to keep this class as lean as possible
            Utils.Converter.RegisterConverter(converter);
        }
        /// <summary>
        /// Removes Converter from list of Converters.
        /// This method won't perform any action if converter isn't found
        /// </summary>
        /// <param name="converter"></param>
        public static void UnregisterConverter(IConverter converter)
        {
            /// This method could've been implemented in this class but I decided to keep this class as lean as possible
            Utils.Converter.UnregisterConverter(converter);
        }

        /// <summary>
        /// Ensures input is always lower case and trimmed
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private static string FormatInputString(string value)
        {
            return value?.ToLower().Trim();
        }
    }
}
