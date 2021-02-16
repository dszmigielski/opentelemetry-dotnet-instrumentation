using BenchmarkDotNet.Attributes;
using Datadog.Trace.BenchmarkDotNet;
using OpenTelemetry.Instrumentation;
using OpenTelemetry.Instrumentation.Configuration;
using OpenTelemetry.Instrumentation.ExtensionMethods;

namespace Benchmarks.Trace
{
    /// <summary>
    /// Span benchmarks
    /// </summary>
    [DatadogExporter]
    [MemoryDiagnoser]
    public class SpanBenchmark
    {
        private static readonly Tracer Tracer;

        static SpanBenchmark()
        {
            var settings = new TracerSettings
            {
                TraceEnabled = false,
                StartupDiagnosticLogEnabled = false
            };

            Tracer = new Tracer(settings, new DummyAgentWriter(), null, null, null);
        }

        /// <summary>
        /// Starts and finishes span benchmark
        /// </summary>
        [Benchmark]
        public void StartFinishSpan()
        {
            Span span = Tracer.StartSpan("operation");
            span.SetTraceSamplingPriority(SamplingPriority.UserReject);
            span.Finish();
        }

        /// <summary>
        /// Starts and finishes an scope with span benchmark
        /// </summary>
        [Benchmark]
        public void StartFinishScope()
        {
            using (Scope scope = Tracer.StartActive("operation"))
            {
                scope.Span.SetTraceSamplingPriority(SamplingPriority.UserReject);
            }
        }
    }
}
