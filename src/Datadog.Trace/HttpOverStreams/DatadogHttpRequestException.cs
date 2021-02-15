using System;

namespace OpenTelemetry.Instrumentation.HttpOverStreams
{
    internal class DatadogHttpRequestException : Exception
    {
        public DatadogHttpRequestException(string message)
            : base(message)
        {
        }
    }
}
