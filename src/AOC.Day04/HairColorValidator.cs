using System.Text.RegularExpressions;

namespace AOC.Day04
{
    public static class HairColorValidator
    {
        private static readonly Regex _rx = new Regex(@"^[#?][0-9,a-f]{6}$", RegexOptions.Compiled | RegexOptions.IgnoreCase);

        public static bool IsValid(string value)
        {
            return _rx.Match(value).Success;
        }
    }
}
