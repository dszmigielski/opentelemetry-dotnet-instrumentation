using System.Threading.Tasks;

namespace OpenTelemetry.Instrumentation.Agent
{
    internal interface IAgentWriter
    {
        void WriteTrace(Span[] trace);

        Task<bool> Ping();

        Task FlushTracesAsync();

        Task FlushAndCloseAsync();
    }
}
