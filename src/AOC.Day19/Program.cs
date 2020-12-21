using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using AOC.Day19;

var input = new Input("input.txt");

var a = SolveA(input);
Console.WriteLine($"A: {a}");

var b = SolveB(input);
Console.WriteLine($"B: {b}");

int SolveA(Input input)
{
    var regex = new Regex($"^{ResolveRegex(0, input)}$", RegexOptions.Compiled);
    return input.Messages.Where(x => regex.IsMatch(x)).Count();   
}

int SolveB(Input input)
{
    input.Rules[8].AlternativeRuleIds = new List<int> { 42, 8 };
    input.Rules[11].AlternativeRuleIds = new List<int> { 42, 11, 31 };

    var r42 = ResolveRegex(42, input);
    var r31 = ResolveRegex(31, input);

    //8: 42 | 42 8 => (42)+
    //11: 42 31 | 42 11 31 (42)+(31)+
    //0: 8 11 => ((42){2,})(31)+
    
    var regex = new Regex($"^(({r42})+)((({r42}){{1}}({r31}){{1}})|(({r42}){{2}}({r31}){{2}})|(({r42}){{3}}({r31}){{3}})|(({r42}){{4}}({r31}){{4}})|(({r42}){{5}}({r31}){{5}})|(({r42}){{6}}({r31}){{6}}))$", RegexOptions.Compiled);

    return input.Messages.Where(x => regex.IsMatch(x)).Count();
}

string ResolveRegex(int ruleId, Input input)
{
    var r = input.Rules[ruleId];

    if (string.IsNullOrEmpty(r.Literal))
    {
        var sb = new StringBuilder();
        
        foreach (var id in r.RuleIds)
        {
            sb.Append($"({ResolveRegex(id, input)})");
        }

        if (r.AlternativeRuleIds != null)
        {
            sb.Append("|");
            foreach (var id in r.AlternativeRuleIds)
            {
                sb.Append($"({ResolveRegex(id, input)})");
            }
        }
                
        return sb.ToString();
    }
    return $"{r.Literal}";
}
