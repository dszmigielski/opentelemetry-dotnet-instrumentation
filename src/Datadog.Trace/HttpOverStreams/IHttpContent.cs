using System.IO;
using System.Threading.Tasks;

namespace OpenTelemetry.Instrumentation.HttpOverStreams
{
    internal interface IHttpContent
    {
        long? Length { get; }

        Task CopyToAsync(Stream destination, int? bufferSize);
    }
}
