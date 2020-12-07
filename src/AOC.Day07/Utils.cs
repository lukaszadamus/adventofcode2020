using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

public record Content
{
    private static readonly Regex _rx = new Regex(@"^(?<q>\d+)([\s])(?<c>[\w]+\s[\w]+)$", RegexOptions.Compiled | RegexOptions.IgnoreCase);

    public int Quantity { get; }
    public string Color { get; }

    public Content(string toParse)
    {
        if (!toParse.Equals("no other", StringComparison.InvariantCultureIgnoreCase))
        {
            var m = _rx.Match(toParse);

            Quantity = int.Parse(m.Groups["q"].Value);
            Color = m.Groups["c"].Value;
        }
        else
        {
            Color = "no other";
            Quantity = 0;
        }
    }
}

public static class Extensions
{
    public static string Clean(this string value)
        => value
            .Replace(" bags", "")
            .Replace(" bag", "")
            .Replace(".", "")
            .Replace(", ", ",")
            .Trim();

    public static Dictionary<string, Content[]> GetRules(this string[] lines)
        => lines.Select(x =>
        {
            var rl = x.Clean().Split(" contain ");
            var key = rl[0];
            var value = rl[1].Split(",").Select(x => new Content(x)).ToArray();
            return new { k = key, v = value };
        }).ToDictionary(x => x.k, x => x.v);
}
