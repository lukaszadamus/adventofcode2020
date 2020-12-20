using System.Collections.Generic;

namespace AOC.Day18
{
    public class Tokenizer
    {
        public static string[] GetTokens(string line)
        {
            var tokens = line.Split(" ");
            var result = new List<string>();
            foreach (var t in tokens)
            {
                if (t.StartsWith("("))
                {
                    result.AddRange(Open(t));
                }
                else if (t.EndsWith(")"))
                {
                    result.AddRange(Close(t));
                }
                else
                {
                    result.Add(t);
                }
            }
            return result.ToArray();
        }

        private static List<string> Open(string token)
        {
            var local = new List<string>();
            do
            {
                local.Add(token[0].ToString());
                token = token[1..];
            }
            while (token.StartsWith("("));
            if (!string.IsNullOrWhiteSpace(token))
            {
                local.Add(token);
            }
            return local;
        }

        private static List<string> Close(string token)
        {
            var local = new List<string>();
            do
            {
                local.Add(token[^1].ToString());
                token = token[..^1];
            }
            while (token.EndsWith(")"));
            if (!string.IsNullOrWhiteSpace(token))
            {
                local.Add(token);
            }
            local.Reverse();
            return local;
        }
    }
}
