using System.Threading.Tasks;
using AOC.Shared;
using Serilog;

namespace AOC.Day03
{
    public class Solver
    {
        private readonly ILogger _logger = Log.ForContext<Solver>();
        private readonly char _tree = '#';

        public long RunA(string[] lines, Point start, Point next)
        {
            using var _ = new DiagnosticHelper("Day03.A");
            var map = new Map();
            map.Load(lines);

            return Run(map, start, next);
        }

        public async Task<long> RunA(string input, Point start, Point next)
        {
            using var _ = new DiagnosticHelper("Day03.A");
            var map = new Map();
            await map.Load(input);

            return Run(map, start, next);
        }

        public long RunB(string[] lines, Point start, Point[] nextPoints)
        {
            using var _ = new DiagnosticHelper("Day03.B");
            var map = new Map();
            map.Load(lines);

            return Run(map, start, nextPoints);
        }

        public async Task<long> RunB(string input, Point start, Point[] nextPoints)
        {
            using var _ = new DiagnosticHelper("Day03.B");
            var map = new Map();
            await map.Load(input);
            
            return Run(map, start, nextPoints);
        }

        public long Run(Map map, Point start, Point[] nextPoints)
        {            
            var answer = 1L;

            foreach (var next in nextPoints)
            {
                answer *= Run(map, start, next);
            }

            _logger.Information("Day03.B answer: {answer}", answer);

            return answer;
        }

        private long Run(Map map, Point start, Point next)
        {
            var treesNo = 0L;

            var current = start;
            var (dx, dy) = StepNormalizer.Normalize(next);

            while (current.Y < map.Height)
            {
                if (map.GetSquare(current).Symbol == _tree)
                {
                    treesNo++;
                }

                var x = current.X + dx;
                var y = current.Y + dy;
                if (x >= map.Width)
                {
                    x -= map.Width;
                }

                current = new Point(x, y);
            }

            _logger.Information("Number of trees: {validNo} Slope: from {start} to {next}", treesNo, start, next);

            return treesNo;
        }
    }
}
