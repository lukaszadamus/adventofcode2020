using System.Linq;

namespace AOC.Day04
{
    public static class EyeColorValidator
    {
        private static readonly string[] _validColors = new[] { EyeColors.Amber, EyeColors.Blue, EyeColors.Brown, EyeColors.Gray, EyeColors.Green, EyeColors.Hazel, EyeColors.Other };

        public static bool IsValid(string value)
        {
            return _validColors.Contains(value);
        }
    }
}
