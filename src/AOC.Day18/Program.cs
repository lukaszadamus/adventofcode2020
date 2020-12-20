using System;
using System.IO;
using System.Linq;
using AOC.Day18;
using AOC.Shared;

Configure.Logging();

var input = File.ReadAllLines("input.txt");

var a = SolveA(input);
Console.WriteLine($"A: {a}");

var b = SolveB(input);
Console.WriteLine($"B: {b}");

long SolveA(string[] expressions)
    => expressions
    .Select(exp => Tokenizer.GetTokens(exp))
    .Select(exp => ONP.Convert(exp, ONP.Priority))
    .Select(onpExp => ONP.Evaluate(onpExp))
    .Sum();

long SolveB(string[] expressions)
    => expressions
    .Select(exp => Tokenizer.GetTokens(exp))
    .Select(exp => ONP.Convert(exp, ONP.AdvancedMathPriority))
    .Select(onpExp => ONP.Evaluate(onpExp))
    .Sum();
