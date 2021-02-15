using System;
using System.Threading.Tasks;

namespace OpenTelemetry.Instrumentation.Agent
{
    internal interface IApi
    {
        Task<bool> SendTracesAsync(Span[][] traces);
    }
}
