using System.Threading.Tasks;
using OpenTelemetry.Instrumentation.Agent.MessagePack;

namespace OpenTelemetry.Instrumentation.Agent
{
    internal interface IApiRequest
    {
        void AddHeader(string name, string value);

        Task<IApiResponse> PostAsync(Span[][] traces, FormatterResolverWrapper formatterResolver);
    }
}
