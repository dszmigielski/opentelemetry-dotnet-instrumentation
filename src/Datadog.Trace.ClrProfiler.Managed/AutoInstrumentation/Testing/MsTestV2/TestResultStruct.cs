using System;
using OpenTelemetry.Instrumentation.DuckTyping;

namespace Datadog.Trace.ClrProfiler.AutoInstrumentation.Testing.MsTestV2
{
    /// <summary>
    /// TestResult ducktype struct
    /// </summary>
    [DuckCopy]
    public struct TestResultStruct
    {
        /// <summary>
        /// Test failure exception
        /// </summary>
        public Exception TestFailureException;
    }
}
