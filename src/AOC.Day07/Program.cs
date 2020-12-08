using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

var rules = File.ReadAllLines("input.txt").GetRules();

Console.WriteLine($"A: {SolveA("shiny gold", rules)}");
Console.WriteLine($"B: {SolveB("shiny gold", rules)}");

int SolveA(string colorToCheck, Dictionary<string, Content[]> rules)
    => rules.Where(x => Find(x.Key, colorToCheck, rules)).Count();

int SolveB(string colorToCheck, Dictionary<string, Content[]> rules)
    => Count(colorToCheck, rules);

bool Find(string color, string colorToCheck, Dictionary<string, Content[]> rules)
{
    var queue = new Queue<string>();
    queue.Enqueue(color);

    while (queue.Count > 0)
    {
        var colors = rules[queue.Dequeue()]
            .Where(x => x.Color != "no other")
            .Select(x => x.Color).ToList();

        if (colors.Any(x => x == colorToCheck))
        {
            return true;
        }

        colors.ForEach(x => queue.Enqueue(x));
    }

    return false;
}

int Count(string colorToCheck, Dictionary<string, Content[]> rules)
{
    var count = 0;

    var queue = new Queue<(string, int)>();
    queue.Enqueue((colorToCheck, 1));

    while (queue.Count > 0)
    {
        var (currentColor, f) = queue.Dequeue();
        if (currentColor == "no other")
        {
            count += f * 1;
        }
        else
        {
            var content = rules[currentColor].ToList();
            count += f * content.Sum(x => x.Quantity);

            content.ForEach(x => queue.Enqueue((x.Color, f * x.Quantity)));
        }
    }

    return count;
}
