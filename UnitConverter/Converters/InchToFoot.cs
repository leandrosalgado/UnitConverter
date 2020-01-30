using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Text.RegularExpressions;

namespace UnitConverter.Converters
{
    /// <summary>
    /// Converts Inches to Feet and vice-versa
    /// </summary>
    class InchToFoot : BaseConverter
    {
        private List<string> _supportedUnits = new List<string>() { "foot", "feet", "inch", "inches" };

        Dictionary<string, Func<double, double>> _formulaTable = new Dictionary<string, Func<double, double>>()
        {
            // foot/feet
            {"feet|inches",  (double value) => value * 12},
            {"kilofeet|inches",  (double value) =>  value * 12 * 1000},
            {"centifeet|inches",  (double value) =>  value * 12 * 0.01},
            {"milifeet|inches",  (double value) => value * 12 * 0.001 },
            // Inches
            {"inches|feet",  (double value) => value / 12},
            {"kiloinches|feet",  (double value) => (value / 12) * 1000},
            {"centiinches|feet",  (double value) =>  (value / 12) * 0.01 },
            {"miliinches|feet",  (double value) =>  (value / 12) * 0.001 },
        };

        public override List<string> SupportedUnits { get { return _supportedUnits; } }
        public override Dictionary<string, Func<double, double>> FormulaTable { get { return _formulaTable; } }
        public override string GetPlural(string unit)
        {
            return GetUnitPrefix(unit) + (isInch(unit) ? "inches" : "feet");
        }
        public override string GetSingular(string unit)
        {
            return GetUnitPrefix(unit) + (isInch(unit) ? "inch" : "foot");
        }
        public override bool IsSupported(string value)
        {
            return _supportedUnits.Any(u => value.Contains(u));
        }

        private bool isInch(string value)
        {
            return !string.IsNullOrWhiteSpace(value) ? value.Contains("inch") : false;
        }
    }
}
