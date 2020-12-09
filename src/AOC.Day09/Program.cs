using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

var numbers = File.ReadAllLines("input.txt")
    .Select(x => long.Parse(x))
    .ToList();

var a = SolveA(numbers, 25);
Console.WriteLine($"A: {a}");

var b = SolveB(numbers, a);
Console.WriteLine($"b: {b}");

long SolveA(List<long> numbers, int preambleLength)
    => numbers
        .Skip(preambleLength)
        .Select((x, i) => new { f = FindA(x, numbers.Skip(i).Take(preambleLength).ToList()), n = x })
        .First(x => !x.f).n;

long? SolveB(List<long> numbers, long toFind)
    => numbers
        .Select((x, i) => new { f = FindB(i, toFind, numbers)})
        .First(x => x.f is not null).f;

bool FindA(long number, List<long> numbers)
{
    for (int i = 0; i < numbers.Count; i++)
    {
        for (int j = i + 1; j < numbers.Count; j++)
        {
            if (numbers[i] + numbers[j] == number) return true;
        }
    }
    return false;
}

long? FindB(int start, long toFind, List<long> numbers)
{
    var slice = new List<long>{ numbers[start] };

    for(int i=start+1; i<numbers.Count; i++)
    {
        if(slice.Sum(x => x) < toFind)
        {
            slice.Add(numbers[i]);
        }
    }

    return slice.Sum(x => x) == toFind ? slice.Max() + slice.Min() : null;
}
