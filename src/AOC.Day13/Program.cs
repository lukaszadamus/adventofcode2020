using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

var lines = File.ReadAllLines("input.txt");
var timestamp = int.Parse(lines[0]);
var ids = lines[1].Split(",").Where(x => x != "x").Select(x => int.Parse(x)).ToList();

var a = SolveA(timestamp, ids);
Console.WriteLine($"A: {a}");

int SolveA(int timestamp, List<int> ids)
    => ids
        .Select(x => new { id = x, wait = x - timestamp % x })
        .OrderBy(x => x.wait)
        .Select(x => x.id * x.wait)
        .First();
