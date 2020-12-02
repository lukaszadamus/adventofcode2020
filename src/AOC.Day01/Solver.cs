using AOC.Shared;
using Serilog;

namespace AOC.Day01
{
    public class Solver
    {
        private readonly ILogger _logger = Log.ForContext<Solver>();

        public int RunA(int[] expenses)
        {
            using var _ = new DiagnosticHelper("Day01.A");
            var count = expenses.Length;
            for (int i = 0; i < count; i++)
            {
                for (int j = i + 1; j < count; j++)
                {
                    if (expenses[i] + expenses[j] == 2020)
                    {
                        _logger.Information("{A} * {B} = {C}", expenses[i], expenses[j], expenses[i] * expenses[j]);
                        return expenses[i] * expenses[j];
                    }
                }
            }
            return 0;
        }

        public int RunB(int[] expenses)
        {
            using var _ = new DiagnosticHelper("Day01.B");
            var count = expenses.Length;
            for (int i = 0; i < count; i++)
            {
                for (int j = i + 1; j < count; j++)
                {
                    for (int k = j + 1; k < count; k++)
                    {
                        if (expenses[i] + expenses[j] + expenses[k] == 2020)
                        {
                            _logger.Information("{A} * {B} * {C} = {D}", expenses[i], expenses[j], expenses[k], expenses[i] * expenses[j] * expenses[k]);
                            return expenses[i] * expenses[j] * expenses[k];
                        }
                    }
                }
            }
            return 0;
        }
    }
}
