using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Text.RegularExpressions;

namespace UnitConverter.Converters
{
    /// <summary>
    /// Converts bits to bytes and vice-versa
    /// </summary>
    class BitToByte : BaseConverter
    {
        private List<string> _supportedUnits = new List<string>() { "bit", "bits", "byte", "bytes" };

        private Dictionary<string, Func<double, double>> _formulaTable = new Dictionary<string, Func<double, double>> (StringComparer.InvariantCultureIgnoreCase)
        {
            // bits
            {"bits|bytes",  (double value) => value / 8},
            {"bits|gigabits",  (double value) => value / 1073741824},
            {"bits|gigabytes",  (double value) => value / 8589934592},
            {"bits|kilobits",  (double value) => value / 1024},
            {"bits|kilobytes",  (double value) => value / 8192},
            {"bits|megabits",  (double value) => value / 1048576},
            {"bits|megabytes",  (double value) => value / 8388608 },
            {"bits|petabits",  (double value) => value / 1125899906842620 },
            {"bits|petabytes",  (double value) => value / 9007199254740990 },
            {"bits|terabits",  (double value) => value / 1099511627776 },
            {"bits|terabytes",  (double value) => value / 8796093022208 },
            // Bytes
            {"bytes|bits",  (double value) => value * 8},
            {"bytes|gigabits",  (double value) => value / 134217728},
            {"bytes|gigabytes",  (double value) => value / 1073741824 },
            {"bytes|kilobits",  (double value) => value / 128 },
            {"bytes|kilobytes",  (double value) => value / 1024 },
            {"bytes|megabits",  (double value) => value / 131072 },
            {"bytes|megabytes",  (double value) => value / 1048576 },
            {"bytes|petabits",  (double value) => value / 140737488355328 },
            {"bytes|petabytes",  (double value) => value / 1125899906842620  },
            {"bytes|terabits",  (double value) => value / 137438953472 },
            {"bytes|terabytes",  (double value) => value / 1099511627776 },
            // Gigabits
            {"gigabits|bits",  (double value) => value * 1073741824 },
            {"gigabits|bytes",  (double value) => value * 134217728 },
            // TODO: Add more formulasd
        };

        public override List<string> SupportedUnits { get { return _supportedUnits; } }
        public override Dictionary<string, Func<double, double>> FormulaTable { get { return _formulaTable; } }
        public override string GetPlural(string unit)
        {
            return GetUnitPrefix(unit) + (IsByte(unit) ? "bytes" : "bits");
        }
        public override string GetSingular(string unit)
        {
            return GetUnitPrefix(unit) + (IsByte(unit) ? "byte" : "bit");
        }
        public override bool IsSupported(string value)
        {
            return _supportedUnits.Any(u => value.Contains(u));
        }

        private bool IsByte(string value)
        {
            return !string.IsNullOrWhiteSpace(value) ? value.Contains("byte") : false;
        }
    }
}
