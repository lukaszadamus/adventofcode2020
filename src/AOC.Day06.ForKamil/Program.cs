using System;
using System.IO;
using System.Linq;

var input = File
    .ReadAllText("input.txt")
    .Split($"{Environment.NewLine}{Environment.NewLine}");

var a = input
    .Sum(x => x.Replace(Environment.NewLine, "")
        .Distinct()
        .Count());

var b = input
    .Sum(x => x.Split(Environment.NewLine)
        .Aggregate((a, b) => string.Concat(a.Intersect(b)))
        .Distinct()
        .Count());

Console.WriteLine($"A:{a}");
Console.WriteLine($"B:{b}");
