using AOC.Day03;
using AOC.Shared;

Configure.Logging();

var solver = new Solver();
var start = new Point(0, 0);

var next = new Point(3, 1);
solver.RunA(await InputHelper.Lines("input.txt"), start, next);

var nextSteps = new[] { new Point(1, 1), new Point(3, 1), new Point(5, 1), new Point(7, 1), new Point(1, 2) };
solver.RunB(await InputHelper.Lines("input.txt"), start, nextSteps);
