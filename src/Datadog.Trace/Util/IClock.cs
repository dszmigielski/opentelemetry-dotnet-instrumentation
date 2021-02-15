using System;

namespace OpenTelemetry.Instrumentation.Util
{
    internal interface IClock
    {
        DateTime UtcNow { get; }
    }
}
