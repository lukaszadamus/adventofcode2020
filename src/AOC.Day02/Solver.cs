using AOC.Shared;
using Serilog;

namespace AOC.Day02
{
    public partial class Solver
    {
        private readonly ILogger _logger = Log.ForContext<Solver>();
        
        

        public int RunA(string[] lines)
        {
            var _parser = new LineParser();
            var validNo = 0;

            using var _ = new DiagnosticHelper("Day02.A");            
            foreach (var line in lines)
            {
                var (policy, password) = _parser.Parse(line);

                if (PasswordValidator.IsValid(policy, password))
                {
                    validNo++;
                }
            }
            _logger.Information("Number of valid passwords: {validNo}", validNo);

            return validNo;
        }

        public int RunB(string[] lines)
        {
            var _parser = new TobogganLineParser();
            int validNo = 0;

            using var _ = new DiagnosticHelper("Day02.B");            
            foreach (var line in lines)
            {
                var (policy, password) = _parser.Parse(line);

                if (PasswordValidator.IsValid(policy, password))
                {
                    validNo++;
                }
            }
            _logger.Information("Number of valid passwords: {validNo} (Official Toboggan Corporate Policy)", validNo);

            return validNo;
        }
    }
}
