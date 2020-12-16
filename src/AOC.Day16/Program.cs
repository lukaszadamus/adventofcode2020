using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AOC.Day16;
using AOC.Shared;

Configure.Logging();

var input = new Input(File.ReadAllLines("input.txt"));

var a = SolveA(input);
Console.WriteLine($"A: {a}");

var b = SolveB(input);
Console.WriteLine($"B: {b}");

int SolveA(Input input)
{
    using var _ = new DiagnosticHelper("SolveA");
    return input.NearbyTickets
        .SelectMany(x => x)
        .Where(x => !input.Rules.IsValidNumber(x))
        .Sum();
}    

long SolveB(Input input)
{
    using var _ = new DiagnosticHelper("SolveB");

    var candidates = new Dictionary<string, List<int>>();

    foreach (var r in input.Rules.ValidRanges)
    {
        var range = input.Rules.ValidRanges[r.Key];

        for (var i = 0; i < input.ValidPivot.Length; i++)
        {
            if (input.ValidPivot[i].Any(x => !range.Contains(x)))
            {
                continue;
            }
            if (!candidates.ContainsKey(r.Key))
            {
                candidates.Add(r.Key, new List<int>());
            }
            candidates[r.Key].Add(i);
        }
    }

    var fields = new Dictionary<string, int>();

    while (candidates.Any(x => x.Value.Count > 0))
    {
        var foo = candidates.OrderBy(x => x.Value.Count).Where(x => x.Value.Count == 1);
        var toReduce = new HashSet<int>();
        foreach (var c in foo)
        {
            fields.Add(c.Key, c.Value[0]);
            toReduce.Add(c.Value[0]);
        }

        candidates.Select(x => x.Value).ToList().ForEach((x) =>
        {
            x.RemoveAll(y => toReduce.Contains(y));
        });

    }
    var indexes = fields
        .Where(x => x.Key.StartsWith("departure"))
        .Select(x => x.Value)
        .ToHashSet();

    return input.Ticket
        .Select((x, i) => new { i, v = (long)x })
        .Where(x => indexes.Contains(x.i))
        .Select(x => x.v)
        .Aggregate(1L, (acc, x) => acc * x);
}
