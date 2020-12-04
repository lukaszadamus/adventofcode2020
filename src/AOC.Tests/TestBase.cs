using Serilog;
using Xunit.Abstractions;

namespace AOC.Tests
{
    public class TestBase
    {        
        private readonly ITestOutputHelper _output;

        public TestBase(ITestOutputHelper output)
        {
            _output = output ?? throw new System.ArgumentNullException(nameof(output));
            
            Log.Logger = new LoggerConfiguration()
                        .MinimumLevel.Verbose()
                        .WriteTo.TestOutput(output, Serilog.Events.LogEventLevel.Verbose)
                        .CreateLogger();
        }        
    }
}
