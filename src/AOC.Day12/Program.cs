using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AOC.Day12;

var instructions = File.ReadAllLines("input.txt").ToList();

var a = SolveA(instructions);
Console.WriteLine($"A: {a}");

var b = SolveB(instructions);
Console.WriteLine($"B: {b}");

long SolveA(List<string> instructions)
{
    var ship = new Ship('E');

    instructions.ForEach(x => ship.Move(x));

    return Math.Abs(ship.Current.X) + Math.Abs(ship.Current.Y);
}

long SolveB(List<string> instructions)
{
    var ship = new Ship('E', new Location(10,1));

    instructions.ForEach(x => ship.MoveWaypoint(x));

    return Math.Abs(ship.Current.X) + Math.Abs(ship.Current.Y);
}
