using Serilog;
using Serilog.Sinks.SystemConsole.Themes;

namespace AOC.Shared
{
    public static class Configure
    {
        public static void Logging()
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console(theme: AnsiConsoleTheme.Code)
                .CreateLogger();
        }
    }
}
