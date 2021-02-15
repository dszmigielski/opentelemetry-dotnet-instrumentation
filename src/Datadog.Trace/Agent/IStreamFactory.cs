using System.IO;

namespace OpenTelemetry.Instrumentation.Agent
{
    internal interface IStreamFactory
    {
        string Info();

        Stream GetBidirectionalStream();
    }
}
