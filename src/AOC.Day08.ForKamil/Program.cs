using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

var program = File.ReadAllLines("input.txt")
    .Select(x => new Instruction(x))
    .ToList();

Console.WriteLine($"A: {SolveA(program)}");
Console.WriteLine($"B: {SolveB(program)}");

int SolveA(List<Instruction> program)
{
    Exe(program, out var acc);
    return acc;
}

int SolveB(List<Instruction> program)
{    
    for(int i=0; i<program.Count; i++)
    {
        if(Exe(program, out var acc, i))
        {
            return acc;
        }
    }
    return -1;
}

bool Exe(List<Instruction> program, out int acc, int? swap = null)
{
    acc = 0;

    if (swap.HasValue)
    {
        if(program[swap.Value].Op == "acc")
        {
            return false;
        }

        program = new List<Instruction>(program);               
        program[swap.Value] = program[swap.Value] 
            with { Op = program[swap.Value].Op == "nop" ? "jmp" : "nop" };
    }

    var called = program
        .Select(x => false)
        .ToList();
    var i = 0;    

    while (true)
    {
        if (i >= program.Count)
        {
            return true;
        }

        if (called[i])
        {
            return false;
        }

        called[i] = true;

        acc = program[i].Op switch
        {
            "acc" => acc + program[i].Arg,
            _ => acc
        };

        i = program[i].Op switch
        {
            "jmp" => i + program[i].Arg,
            _ => i + 1
        };
    }
}

record Instruction
{
    public string Op { get; init; }
    public int Arg { get; init; }

    public Instruction(string line)
    {
        var data = line.Split(" ");
        Op = data[0];
        Arg = int.Parse(data[1]);
    }
}
