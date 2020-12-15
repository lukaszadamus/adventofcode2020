using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AOC.Day14;

var input = File.ReadAllLines("input.txt")
    .Select(x => ParseLine(x))
    .ToList();

var a = SolveA(input);
Console.WriteLine($"A: {a}");

var b = SolveB(input);
Console.WriteLine($"B: {b}");

ulong SolveA(List<(ulong? address, string value)> input)
{
    var m = new ValueMask();
    var memory = new Dictionary<ulong, ulong>();
    foreach (var (address, value) in input)
    {
        if (address.HasValue)
        {
            memory[address.Value] = m.Apply(ulong.Parse(value));
        }
        else
        {
            m.Set(value);
        }
    }

    return memory.Select(x => x.Value).Aggregate(0ul, (acc, x) => acc + x);
}

ulong SolveB(List<(ulong? address, string value)> input)
{
    var m = new MemoryAddressDecoder();
    var memory = new Dictionary<ulong, ulong>();
    foreach (var (address, value) in input)
    {
        if (address.HasValue)
        {
            foreach(var a in m.Decode(address.Value))
            {
                memory[a] = ulong.Parse(value);
            }
            
        }
        else
        {
            m.Set(value);
        }
    }

    return memory.Select(x => x.Value).Aggregate(0ul, (acc, x) => acc + x);
}

(ulong? address, string value) ParseLine(string line)
{
    var p = line.Split(" = ");
    if (p[0] == "mask")
    {
        return (null, p[1]);
    }
    else
    {
        return (ulong.Parse(p[0].Replace("mem[", "").Replace("]", "")), p[1]);
    }
}
