using System;

namespace OpenTelemetry.Instrumentation.Abstractions
{
    internal interface IScope : IDisposable
    {
        ISpan Span { get; }
    }
}
