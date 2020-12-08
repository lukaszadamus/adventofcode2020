using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AOC.Shared;

Configure.Logging();
Dictionary<string, Content[]> input;

using (var _ = new DiagnosticHelper("Read data"))
{
    input = File.ReadAllLines("input.txt").GetRules();
}

var a = SolveA(input, "shiny gold");
var b = SolveB(input, "shiny gold");

Console.WriteLine($"A:{a}");
Console.WriteLine($"B:{b}");

int SolveA(Dictionary<string, Content[]> input, string colorToCheck)
{
    using var _ = new DiagnosticHelper("Day07.A");
    var count = 0;

    foreach (var rule in input)
    {
        var queue = new Queue<string>();
        queue.Enqueue(rule.Key);

        var found = false;
        while (queue.Count > 0)
        {
            found = false;

            var current = queue.Dequeue();

            var colors = input[current].Select(x => x.Color);

            if (colors.Any(x => x == colorToCheck))
            {
                found = true;
                queue.Clear();
            }
            else
            {
                foreach (var next in colors.Where(x => x != "no other"))
                {
                    queue.Enqueue(next);
                }
            }
        }
        count += found ? 1 : 0;
    }

    return count;
}

int SolveB(Dictionary<string, Content[]> input, string colorToCheck)
{
    using var _ = new DiagnosticHelper("Day07.B");
    var count = 0;

    var queue = new Queue<(string, int)>();
    queue.Enqueue((colorToCheck, 1));

    while (queue.Count > 0)
    {
        var (currentColor, f) = queue.Dequeue();

        if (currentColor == "no other")
        {
            count += f * 1;
        }
        else
        {
            var content = input[currentColor];            
            count += f * content.Sum(x => x.Quantity);

            foreach (var next in content)
            {
                queue.Enqueue((next.Color, f * next.Quantity));
            }
        }
    }

    return count;
}
