using System;
using System.Linq;

namespace AOC.Day04
{
    public static class HeightUnitValidator
    {
        private static readonly string[] _validUnits = new[] { HeightUnits.Cm, HeightUnits.In };

        public static bool IsValid(string value)
        {
            return _validUnits.Contains(value);
        }
    }
}
