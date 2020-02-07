using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Text.RegularExpressions;
using System.Globalization;

namespace UnitConverter.Converters
{
    /// <summary>
    /// Base Converter class to all converters whitin this library:
    /// The idea is to have a simple logic to retrieve a formula and apply it to the input value.
    /// The List of formulas could be loaded from anywhere, for example a class could implement this base class and retrieve all the formulas from a DB.
    /// </summary>
    abstract class BaseConverter : IConverter
    {
        /// <summary>
        /// Supported Units
        /// </summary>
        public abstract List<string> SupportedUnits { get; }
        /// <summary>
        /// Table of formulas.
        /// The dic. key is the pair of "{plural of unit from}|{plural of unit to}"
        /// </summary>
        public abstract Dictionary<string, Func<double, double>> FormulaTable { get; }
        /// <summary>
        /// Gets the plural of the unit.
        /// </summary>
        /// <param name="unit"></param>
        /// <returns></returns>
        public abstract string GetPlural(string unit);
        /// <summary>
        /// Gets the singular of the given unit
        /// </summary>
        /// <param name="unit"></param>
        /// <returns></returns>
        public abstract string GetSingular(string unit);
        /// <summary>
        /// Checks if unit is supported for convertion
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public abstract bool IsSupported(string value);
        /// <summary>
        /// Checks if Converter is able to convert given units.
        /// It uses the IsSupported method.
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        public bool CanConvert(string from, string to)
        {
            return from != to && IsSupported(from) && IsSupported(to);
        }
        /// <summary>
        /// Applies the conversion formula and format output
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        public string Convert(UnitValue from, string to)
        {
            if (string.IsNullOrWhiteSpace(to)) return "";
            if(!double.TryParse(from.Value, NumberStyles.Any, CultureInfo.InvariantCulture, out var value))
            {
                throw new ConversionNotSupportedException();
            }

            if (value == 0) return FomartOutput(value, to);


            var formula = GetFormula(from.UnitText, to);
            
            if(formula == null)
            {
                throw new ConversionNotSupportedException();
            }
            
            var result = formula(value);

            return FomartOutput(result, to);
        }

        /// <summary>
        /// Gets the formula from the table of formulas
        /// </summary>
        /// <param name="unitFrom"></param>
        /// <param name="unitTo"></param>
        /// <returns></returns>
        public virtual Func<double, double> GetFormula(string unitFrom, string unitTo)
        {
            FormulaTable.TryGetValue($"{GetPlural(unitFrom)}|{GetPlural(unitTo)}", out var formula);
            return formula;
        }

        /// <summary>
        /// Gets the unit prefix. e.g.: kilometre => kilo
        /// </summary>
        /// <param name="unit"></param>
        /// <returns></returns>
        protected string GetUnitPrefix(string unit)
        {
            var regex = new Regex("(" + String.Join("|", SupportedUnits.Select(Regex.Escape)) + ")$");
            return regex.Replace(unit, "");
        }
        /// <summary>
        /// Formats the result of the conversion
        /// </summary>
        /// <param name="value"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        protected string FomartOutput(double value, string to)
        {
            bool isPlural = value > 1;
            string unitPrefix;
            unitPrefix = isPlural ? GetPlural(to) : GetSingular(to);
            return $"{Math.Round(value, 2).ToString("0.00", CultureInfo.InvariantCulture)} {unitPrefix}";
        }
    }
}
