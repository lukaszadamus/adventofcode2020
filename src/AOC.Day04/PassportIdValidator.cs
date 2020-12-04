using System.Text.RegularExpressions;

namespace AOC.Day04
{
    public static class PassportIdValidator
    {
        private static readonly Regex _rx = new Regex(@"^[0-9]{9}$", RegexOptions.Compiled | RegexOptions.IgnoreCase);

        public static bool IsValid(string value)
        {
            return _rx.IsMatch(value);
        }
    }
}
