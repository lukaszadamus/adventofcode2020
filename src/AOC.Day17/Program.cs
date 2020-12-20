using System;
using System.IO;
using AOC.Day17;
using AOC.Shared;

Configure.Logging();

var energySource = new EnergySource(File.ReadAllLines("input.txt"), 6);
var simulator = new Simulator(energySource);

var a = SolveA(simulator);
Console.WriteLine($"A: {a}");

energySource = new EnergySource(File.ReadAllLines("input.txt"), 6);
simulator = new Simulator(energySource);

var b = SolveB(simulator);
Console.WriteLine($"B: {b}");

int SolveA(Simulator simulator)
{
    using var _ = new DiagnosticHelper("SolveA");
    simulator.PerformCycle3D(6);   
    return simulator.Active;
}

int SolveB(Simulator simulator)
{
    using var _ = new DiagnosticHelper("SolveB");
    simulator.PerformCycle4D(6);
    return simulator.Active;
}
