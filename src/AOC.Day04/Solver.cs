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
            bool isValid;
            using var _ = new DiagnosticHelper(label);
            foreach (var line in lines)
            {
                if (Scanner.ScanAndUpdate(line, passport))
                {
                    isValid = validator(passport);
                    if (isValid)
                    {
                        validNo++;
                    }
                    scannedNo++;
                    _logger.Verbose("Passport #{scannedNo} {passport} valid:{isValid}", scannedNo, passport, isValid);

                    passport = new Passport();
                }
            }

            //no new line at the end of the file
            isValid = validator(passport);
            if (isValid)
            {
                validNo++;
            }
            scannedNo++;
            _logger.Verbose("Passport #{scannedNo} {passport} valid:{isValid}", scannedNo, passport, isValid);

            _logger.Information("Number of valid passports: {validNo} scanned: {scannedNo}", validNo, scannedNo);

            return validNo;
        }
    }
}
