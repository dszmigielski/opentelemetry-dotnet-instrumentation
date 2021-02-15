using System;

namespace OpenTelemetry.Instrumentation
{
    internal interface ITraceContext
    {
        DateTimeOffset UtcNow { get; }

        SamplingPriority? SamplingPriority { get; set; }

        Span RootSpan { get; }

        void AddSpan(Span span);

        void CloseSpan(Span span);

        void LockSamplingPriority();

        TimeSpan ElapsedSince(DateTimeOffset date);
    }
}
