using AOC.Day05;
using AOC.Shared;

Configure.Logging();

var solver = new Solver();

solver.RunA(await InputHelper.Lines("input.txt"));
solver.RunB(await InputHelper.Lines("input.txt"));
