using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AOC.Shared;
using Serilog;

namespace AOC.Day06
{
    public class Solver
    {
        private readonly ILogger _logger = Log.ForContext<Solver>();

        public async Task<int> RunA(string input)
        {
            return RunA(await InputHelper.ToLines(input));
        }

        public int RunA(string[] lines)
        {
            static int Count(string group)
            {
                return group.Distinct().Count();
            }

            using var _ = new DiagnosticHelper("Day06.A");

            var groups = InputHelper.GroupLines(lines, (x) => string.IsNullOrWhiteSpace(x));
            var sum = 0;
            var count = 0;
            foreach (var g in groups)
            {
                var inlineGroup = string.Join("", g).Replace(Environment.NewLine, "");
                count = Count(inlineGroup);
                sum += count;
                _logger.Verbose("Group loaded: {inlineGroup} distinc count: {count}", inlineGroup, count);
            }

            _logger.Information("Sum of YES answers: {sum}", sum);

            return sum;
        }

        public async Task<int> RunB(string input)
        {
            return RunB(await InputHelper.ToLines(input));
        }

        public int RunB(string[] lines)
        {
            using var _ = new DiagnosticHelper("Day06.B");

            var groups = InputHelper.GroupLines(lines, (x) => string.IsNullOrWhiteSpace(x));
            var sum = 0;
            foreach (var g in groups)
            {
                IEnumerable<char> intersect = null;
                foreach(var gl in g)
                {
                    if(intersect is not null)
                    {
                        intersect = intersect.Intersect(gl);
                    }
                    else
                    {
                        intersect = gl.AsEnumerable();
                    }
                }                
                sum += intersect.Distinct().Count();
                _logger.Verbose("Group intersect: {intersect} distinc count: {count}", intersect, intersect.Distinct().Count());
            }

            _logger.Information("Sum of YES answers: {sum}", sum);

            return sum;
        }
    }
}
