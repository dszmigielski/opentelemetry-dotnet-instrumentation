using System;

namespace OpenTelemetry.Instrumentation.RuntimeMetrics
{
    internal interface IRuntimeMetricsListener : IDisposable
    {
        void Refresh();
    }
}
