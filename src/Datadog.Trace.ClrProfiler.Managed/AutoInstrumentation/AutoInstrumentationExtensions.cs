using System;
using System.Runtime.CompilerServices;
using OpenTelemetry.Instrumentation;

namespace Datadog.Trace.ClrProfiler.AutoInstrumentation
{
    internal static class AutoInstrumentationExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void DisposeWithException(this Scope scope, Exception exception)
        {
            if (scope != null)
            {
                try
                {
                    if (exception != null)
                    {
                        scope.Span?.SetException(exception);
                    }
                }
                finally
                {
                    scope.Dispose();
                }
            }
        }
    }
}
