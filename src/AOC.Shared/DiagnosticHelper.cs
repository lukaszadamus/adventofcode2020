using System;
using System.Diagnostics;
using Serilog;

namespace AOC.Shared
{    
    public sealed class DiagnosticHelper : IDisposable
    {
        private readonly string _operation;
        private readonly ILogger _logger = Log.ForContext<DiagnosticHelper>();
        private readonly Stopwatch _sw;        
        public DiagnosticHelper(string operation)
        {
            _operation = operation;
            _sw = Stopwatch.StartNew();
        }

        public void Dispose()
        {            
            Stop();
            LogTime();
        }

        public void LogTime()
        {
            _logger.Information("{operation} execution time {elapsedMilliseconds}ms", _operation, _sw.ElapsedMilliseconds);
        }

        public void Stop()
        {
            _sw.Stop();
        }         
    }
}
