using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

var adapters = File.ReadAllLines("input.txt")
    .Select(x => int.Parse(x))
    .ToList();

adapters = WireUp(adapters);

var a = SolveA(adapters);
Console.WriteLine($"A: {a}");

var b = SolveB(adapters);
Console.WriteLine($"A: {b}");

int SolveA(List<int> adapters)
{
    var diffs = adapters
        .Select((x, i) => i > 0 ? x - adapters[i - 1] : 0)
        .Where(x => x > 0)
        .GroupBy(x => x)
        .Select(g => g.Count());
    return diffs.Max() * diffs.Min();
}

ulong SolveB(List<int> adapters)
{    
    var candidates = Candidates(adapters);
    var groups = Group(candidates);
    ulong count = 1;
    foreach(var g in groups)
    {
        if(g.Count == 3)
        {
            count *= 7;
        }
        else if (g.Count == 2)
        {
            count *= 4;
        }
        else
        {
            count *= 2;
        }
    }
    
    return count;

    static List<List<int>> Group(List<int> candidates)
    {
        var groups = new List<List<int>>();
        var group = new List<int>
        {
            candidates[0]
        };
        groups.Add(group);
        for (var i=1; i<candidates.Count; i++)
        {
            if(candidates[i] - group.Last() == 1)
            {
                group.Add(candidates[i]);
            }
            else
            {
                
                group = new List<int>
                {
                    candidates[i]
                };
                groups.Add(group);
            }
        }

        return groups;        
    }

    static List<int> Candidates(List<int> adapters)
    {        
        var candidates = new List<int>();
        for (var i = 1; i < adapters.Count - 1; i++)
        {
            if (adapters[i + 1] - adapters[i - 1] <= 3)
            {
                candidates.Add(i);
            }
        }        
        return candidates;
    }
}

List<int> WireUp(List<int> adapters)
    => adapters
        .Append(0)
        .Append(adapters.Max() + 3)
        .OrderBy(x => x)
        .ToList();

