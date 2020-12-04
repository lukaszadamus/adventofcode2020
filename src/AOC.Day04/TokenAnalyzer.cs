using System;
using Serilog;

namespace AOC.Day04
{
    public static class TokenAnalyzer
    {
        private static readonly ILogger _logger = Log.ForContext("loggerName", nameof(TokenAnalyzer));

        public static (string token, string value) Parse(string token, char splitBy = ':')
        {
            if (token is null)
            {
                throw new ArgumentNullException(nameof(token));
            }

            var parts = token.Split(splitBy);

            if (parts.Length != 2)
            {
                _logger.Warning("Can't parse token: {token}", token);
            }

            return (parts[0], parts[1]);
        }
    }
}
