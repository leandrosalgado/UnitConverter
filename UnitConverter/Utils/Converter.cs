using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnitConverter.Utils
{
    /// <summary>
    /// Converter Util class. It contains the registered converters and an API to retrieve, register and unregister converters.
    /// </summary>
    static class Converter
    {
        private static List<IConverter> Converters;
        /// <summary>
        /// Initialize the list of converters when this class used for the first time. 
        /// </summary>
        static Converter()
        {
            var type = typeof(IConverter);
            // add converters whithin the library to our private array
            Converters = typeof(UnitConverter).Assembly
                .GetTypes()
                .Where(p => type.IsAssignableFrom(p) && p.IsClass && !p.IsAbstract)
                .Select(t => (IConverter)Activator.CreateInstance(t))
                .ToList();
        }
        /// <summary>
        /// Retrieves converter. 
        /// Example: Utils.Converter("metre", "feet") => returns the first Converter which is capable of converting these units.
        ///
        /// </summary>
        /// <param name="fromUnit">Unit which will be converted</param>
        /// <param name="toUnit">Destination unit</param>
        /// <returns></returns>
        public static IConverter GetConverter(string fromUnit, string toUnit)
        {
            // For simplification I'm considering only the first converter. The code could return a list of converters, though.
            return Converters.FirstOrDefault(c => c.CanConvert(fromUnit, toUnit));
        }

        /// <summary>
        /// Register a new converter
        /// </summary>
        /// <param name="converter"></param>
        public static void RegisterConverter(IConverter converter)
        {
            Converters.Add(converter);
        }
        /// <summary>
        /// Unregister converter
        /// </summary>
        /// <param name="converter"></param>
        public static void UnregisterConverter(IConverter converter)
        {
            var foundConverter = Converters.FirstOrDefault(c => c.GetType() == converter.GetType());
            if(foundConverter != null)
            {
                Converters.Remove(foundConverter);
            }
        }

    }
}
