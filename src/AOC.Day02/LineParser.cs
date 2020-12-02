using System;
using System.Text.RegularExpressions;
using Serilog;

namespace AOC.Day02
{
    public class LineParser
    {
        private readonly ILogger _logger = Log.ForContext<LineParser>();
        private readonly Regex _rx = new Regex(@"^(?<min>\d+)([-])(?<max>\d+)(\s?)(?<character>\w?)([:])(\s?)(?<password>\w+)$", RegexOptions.Compiled | RegexOptions.IgnoreCase);

        public (Policy policy, string password) Parse(string line)
        {
            try
            {
                var m = _rx.Match(line);

                var min = byte.Parse(m.Groups["min"].Value);
                var max = byte.Parse(m.Groups["max"].Value);
                var character = m.Groups["character"].Value[0];
                var password = m.Groups["password"].Value;

                return (new Policy(min, max, character), password);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Can't parse line: {line}", line);
                return (null, null);
            }
        }
    }
}
