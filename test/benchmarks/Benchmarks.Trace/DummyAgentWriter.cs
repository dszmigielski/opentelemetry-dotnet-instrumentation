using System;
using System.Threading.Tasks;
using OpenTelemetry.Instrumentation;
using OpenTelemetry.Instrumentation.Agent;

namespace Benchmarks.Trace
{
    class DummyAgentWriter : IAgentWriter
    {
        private static readonly Task<bool> PingTask = Task.FromResult(true);

        public Task FlushAndCloseAsync()
        {
            return Task.CompletedTask;
        }

        public void SetApiBaseEndpoint(Uri uri)
        {
        }

        public Task FlushTracesAsync()
        {
            return Task.CompletedTask;
        }

        public void OverrideApi(IApi api)
        {
        }

        public Task<bool> Ping()
        {
            return PingTask;
        }

        public void WriteTrace(Span[] trace)
        {
        }
    }
}
