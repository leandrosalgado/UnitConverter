using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Text.RegularExpressions;

namespace UnitConverter.Converters
{
    /// <summary>
    /// Converts metres to inches and vice-versa
    /// </summary>
    class MetreToInch : BaseConverter
    {
        private List<string> _supportedUnits = new List<string>() { "metre", "metres", "inch", "inches" };

        Dictionary<string, Func<double, double>> _formulaTable = new Dictionary<string, Func<double, double>>()
        {
            // inches
            {"inches|metres", (value) => value * 0.0254 },
            {"inches|centimetres", (value) => value * 2.54 },
            {"inches|milimetres", (value) => value * 25.4 },
            {"inches|kilometres", (value) => value * 0.0000254 },
            // Kiloinches
            {"kiloinches|metres", (value) => (value * 1000) * 0.0254},
            {"kiloinches|centimetres", (value) => (value * 1000) * 2.54},
            {"kiloinches|milimetres", (value) => (value * 1000) * 25.4},
            {"kiloinches|kilometres", (value) => (value * 1000) * 0.0000254 },
            // inches => Kiloinches
            {"kiloinches|inches", (value) => value * 1000},
            {"inches|kiloinches", (value) => value / 1000},
            // metres
            {"metres|inches", (value) => value * 39.3701 },
            {"kilometres|inches", (value) => ((value * 1000) * 39.3701)  },
            {"centimetres|inches", (value) => ((value * 0.01) * 39.3701)},
            {"milimetres|inches", (value) => (value * 0.001) * 39.3701},
        };
        public override List<string> SupportedUnits { get { return _supportedUnits; } }
        public override Dictionary<string, Func<double, double>> FormulaTable { get { return _formulaTable; } }
        public override string GetPlural(string unit)
        {
            return GetUnitPrefix(unit) + (IsMetre(unit) ? "metres" : "inches");
        }
        public override string GetSingular(string unit)
        {
            return GetUnitPrefix(unit) + (IsMetre(unit) ? "metre" : "inch");
        }
        public override bool IsSupported(string value)
        {
            return _supportedUnits.Any(u => value.Contains(u));
        }

        private bool IsMetre(string value)
        {
            return !string.IsNullOrWhiteSpace(value) ? value.Contains("metre") : false;
        }
    }
}
