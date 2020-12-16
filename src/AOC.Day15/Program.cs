using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AOC.Shared;

Configure.Logging();

var numbers = File.ReadAllText("input.txt")
    .Split(",")
    .Select(x => int.Parse(x))
    .ToArray();

var a = SolveA(numbers, 2020);
Console.WriteLine($"A: {a}");

var b = SolveB(numbers, 30000000);
Console.WriteLine($"B: {b}");

int SolveA(int[] numbers, int round)
{
    using var _ = new DiagnosticHelper("SolveA");
    var numberRounds = numbers
        .Select((x, i) => new { n = x, i = i + 1 })
        .ToDictionary(x => x.n, x => new List<int> { x.i });

    var last = numbers.Last();

    for (var r = numbers.Length + 1; r <= round; r++)
    {
        var foo = numberRounds[last];

        if (foo.Count == 1)
        {
            last = 0;
            numberRounds[last].Insert(0, r);
        }
        else
        {
            last = foo[0] - foo[1];
            if (numberRounds.ContainsKey(last))
            {
                numberRounds[last].Insert(0, r);
            }
            else
            {
                numberRounds.Add(last, new List<int> { r });
            }
        }
    }

    return last;
}

int SolveB(int[] numbers, int round)
{
    var numberRounds = numbers
        .Select((x, i) => new { n = x, i = i + 1 })
        .ToDictionary(x => x.n, x => new int[2] { x.i, x.i });

    var last = numbers.Last();

    using (var _ = new DiagnosticHelper("SolveB"))
    {
        for (var r = numbers.Length + 1; r <= round; r++)
        {
            var foo = numberRounds[last];
            last = foo[0] - foo[1];

            if (numberRounds.ContainsKey(last))
            {
                var bar = numberRounds[last];
                bar[1] = bar[0];
                bar[0] = r;
            }
            else
            {
                numberRounds.Add(last, new int[2] { r, r });
            }
        }
    }
    return last;
}
