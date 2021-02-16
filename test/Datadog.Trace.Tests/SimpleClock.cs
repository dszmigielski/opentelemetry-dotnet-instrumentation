using System;
using OpenTelemetry.Instrumentation.Util;

namespace Datadog.Trace.Tests
{
    internal class SimpleClock : IClock
    {
        public DateTime UtcNow { get; set; } = DateTime.UtcNow;
    }
}
