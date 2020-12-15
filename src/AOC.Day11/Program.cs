using System;
using System.IO;
using AOC.Day11;

var layout = new Layout(File.ReadAllLines("input.txt"));

var a = SolveA(layout);
Console.WriteLine($"A: {a}");

var b = SolveB(layout);
Console.WriteLine($"B: {b}");

int SolveA(Layout layout)
{
    while (true)
    {
        var (next, changes) = Model.RoundA(layout);

        if (changes == 0)
        {
            return next.CountOccupied();
        }

        layout = next;
    }
}

int SolveB(Layout layout)
{
    while (true)
    {
        var (next, changes) = Model.RoundB(layout);

        if (changes == 0)
        {
            return next.CountOccupied();
        }

        layout = next;
    }
}
