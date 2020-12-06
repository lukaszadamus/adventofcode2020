using System;
using System.IO;
using System.Linq;

var nl = Environment.NewLine;

var input = File
    .ReadAllText("input.txt")
    .Split($"{nl}{nl}");

var a = input
    .Sum(x => x.Replace(nl, "")
        .Distinct()
        .Count());

var b = input
    .Sum(x => x.Split(nl)
        .Aggregate((a, b) => string.Concat(a.Intersect(b)))
        .Distinct()
        .Count());

Console.WriteLine($"A:{a}");
Console.WriteLine($"B:{b}");
