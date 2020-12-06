using System;
using System.Threading.Tasks;
using AOC.Shared;
using Serilog;

namespace AOC.Day04
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
            return Run(lines, PassportValidator.IsValid, "Day04.A");
        }

        public async Task<int> RunB(string input)
        {
            return RunB(await InputHelper.ToLines(input));
        }

        public int RunB(string[] lines)
        {
            return Run(lines, PassportValidator.IsValidEnhanced, "Day04.B");
        }

        private int Run(string[] lines, Func<Passport, bool> validator, string label)
        {
            var passport = new Passport();
            var validNo = 0;
            var scannedNo = 0;            
            using var _ = new DiagnosticHelper(label);

            var groups = InputHelper.GroupLines(lines, (x) => string.IsNullOrWhiteSpace(x));

            foreach(var g in groups)
            {
                foreach(var gl in g)
                {
                    Scanner.ScanAndUpdate(gl, passport);
                }
                
                var isValid = validator(passport);
                if (isValid)
                {
                    validNo++;
                }
                scannedNo++;
                _logger.Verbose("Passport #{scannedNo} {passport} valid:{isValid}", scannedNo, passport, isValid);

                passport = new Passport();
            }            

            _logger.Information("Number of valid passports: {validNo} scanned: {scannedNo}", validNo, scannedNo);

            return validNo;
        }
    }
}
