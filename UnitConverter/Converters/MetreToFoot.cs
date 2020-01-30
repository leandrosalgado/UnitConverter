using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Text.RegularExpressions;

namespace UnitConverter.Converters
{
    /// <summary>
    /// Converts metres to feet and vice-versa
    /// </summary>
    class MetreToFoot : BaseConverter
    {
        private List<string> _supportedUnits = new List<string>() { "metre", "metres", "foot", "feet" };

        Dictionary<string, Func<double, double>> _formulaTable = new Dictionary<string, Func<double, double>>()
        {
            // feet
            {"feet|metres", (value) => value * 0.3048 },
            {"feet|centimetres", (value) => value * 30.48 },
            {"feet|kilometres", (value) => value * 0.0003048 },
            {"feet|milimetres", (value) => value * 304.8 },
            {"kilofeet|kilometres", (value) => value * 0.3048 },
            {"kilofeet|metres", (value) => value * 304.8 },
            {"kilofeet|centimetres", (value) => value * 304.8 * 100},
            {"kilofeet|milimetres", (value) => value * 304.8 * 1000},
            // metres
            {"metres|feet", (value) => value * 3.28084 },
            {"kilometres|feet", (value) => ((value * 1000) * 3.28084)  },
            {"centimetres|feet", (value) => ((value * 0.01) * 3.28084)},
            {"milimetres|feet", (value) => (value * 0.001) * 3.28084},

            // TODO: move to its own converter
            {"kilofeet|feet", (value) => value * 1000},
            {"feet|kilofeet", (value) => value / 1000},
            
            // TODO: Move to its own converter
            {"metres|centimetres", (value) => value / 100 },
            {"metres|milimetres", (value) => value / 1000 },
            {"metres|kilometres", (value) => value * 1000 },
            {"kilometres|metres", (value) => value * 1000 },
            {"kilometres|centimetres", (value) => value * 100000 },
            {"kilometres|milimetres", (value) => value * 1000000},
            {"centimetres|metres", (value) => value / 100 },
            {"centimetres|kilometres", (value) => value / 100000 },
            {"centimetres|milimetres", (value) => value * 10 },
            {"milimetres|metres", (value) => value / 1000 },
            {"milimetres|centimetres", (value) => value / 10 },
            {"milimetres|kilometres", (value) => value / 1000000 },
        };
        public override List<string> SupportedUnits { get { return _supportedUnits; } }
        public override Dictionary<string, Func<double, double>> FormulaTable { get { return _formulaTable; } }
        public override string GetPlural(string unit)
        {
            return GetUnitPrefix(unit) + (IsMetre(unit) ? "metres" : "feet");
        }
        public override string GetSingular(string unit)
        {
            return GetUnitPrefix(unit) + (IsMetre(unit) ? "metre" : "foot");
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
