using System;
using System.Collections.Generic;
using System.Linq;
using AOC.Day20;

var input = new Input("input.txt");

var a = SolveA(input);
Console.WriteLine($"A: {a}");

var b = SolveB(input);
Console.WriteLine($"B: {b}");

long SolveA(Input input)
{
    var edgesToTiles = new Dictionary<int, List<int>>();

    input.Tiles
        .SelectMany(x => x.Edges)
        .Distinct()
        .ToList()
        .ForEach((x) =>
        {
            edgesToTiles.Add(x, input.Tiles.Where(t => t.Edges.Contains(x)).Select(t => t.Id).ToList());
        });

    var corners = new List<int>();

    foreach (var tile in input.Tiles)
    {
        var pairs = new List<int>();
        foreach (var egde in tile.Edges)
        {
            if (edgesToTiles[egde].Count == 2)
            {
                pairs.Add(egde);
            }
        }
        if (pairs.Count == 4)
        {
            corners.Add(tile.Id);
        }
    }

    return corners.Aggregate(1L, (acc, x) => acc * x);
}

int SolveB(Input input)
{
    return 0;
}
