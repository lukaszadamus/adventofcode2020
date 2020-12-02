using System;
using System.Text.RegularExpressions;
using Serilog;

namespace AOC.Day02
{
    public class TobogganLineParser
    {
        private readonly ILogger _logger = Log.ForContext<LineParser>();
        private readonly Regex _rx = new Regex(@"^(?<pos1>\d+)([-])(?<pos2>\d+)(\s?)(?<character>\w?)([:])(\s?)(?<password>\w+)$", RegexOptions.Compiled | RegexOptions.IgnoreCase);

        public (TobogganPolicy policy, string password) Parse(string line)
        {
            try
            {
                var m = _rx.Match(line);

                var pos1 = byte.Parse(m.Groups["pos1"].Value);
                var pos2 = byte.Parse(m.Groups["pos2"].Value);
                var character = m.Groups["character"].Value[0];
                var password = m.Groups["password"].Value;

                return (new TobogganPolicy(pos1, pos2, character), password);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Can't parse line: {line}", line);
                return (null, null);
            }
        }
    }
}
