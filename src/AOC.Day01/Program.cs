using AOC.Day01;
using AOC.Shared;

Configure.Logging();

var solver = new Solver();
solver.RunA(await InputHelper.LinesAsIntegers("input.txt"));
solver.RunB(await InputHelper.LinesAsIntegers("input.txt"));
